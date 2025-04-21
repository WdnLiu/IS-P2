using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float maxSpeed = 750f;
    public Vector3 velocity = Vector3.zero;
    private float limit = 22f;

    public GameObject hayBalePrefab ; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint ; //The point from which the hay will to be shot.
    public float shootInterval ; //The smallest amount of time between shots
    private float shootTimer ; //A timer that to keep track whether the machine can shoot

    public float currentInput = 0f;
    public float smoothInputVelocity = 0f;
    private float smoothInputSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootInterval;
    }

    private void ShootHay()
    {
        SoundManager.Instance.PlayShootClip();
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

    private void manageMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        currentInput = Mathf.SmoothDamp(currentInput, horizontalInput, ref smoothInputVelocity, smoothInputSpeed);
        
        Vector3 finalPosition = transform.position;
        finalPosition.x = Mathf.Clamp(finalPosition.x + currentInput * maxSpeed * Time.deltaTime, -limit, limit);

        transform.position = finalPosition;
    }

    private void manageProjectiles()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (shootTimer > shootInterval))
        {
            ShootHay();
            shootTimer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        manageMovement();
        manageProjectiles();
    }
}
