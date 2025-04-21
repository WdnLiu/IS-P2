using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    public void DroppedSheep()
    {
        sheepDropped++;

        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
        UIManager.Instance.UpdateSheepDropped();
    }


    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
    
        UIManager.Instance.ShowGameOverWindow();
        SoundManager.Instance.PlayEndGameMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void restartGame()
    {
        sheepSaved = 0;
        sheepDropped = 0;

        sheepSpawner.canSpawn = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIManager.Instance.HideGameOverWindow();
        SoundManager.Instance.PlayBGM();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
