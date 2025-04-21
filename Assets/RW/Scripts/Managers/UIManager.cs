using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text sheepSavedText;
    public Text sheepDroppedText;
    public GameObject gameOverWindow;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved()
    {
        sheepSavedText.text = "Saved Sheep: " + GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = "Dropped Sheep: " + GameStateManager.Instance.sheepDropped.ToString() + "/5";
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

    public void HideGameOverWindow()
    {
        gameOverWindow.SetActive(false);
    }
}
