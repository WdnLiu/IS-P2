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

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootInterval;
    }

    private void ShootHay()
    {
        Vector3 spawnPoint = haySpawnpoint.position;
        spawnPoint.z -= 34;
        Instantiate(hayBalePrefab , spawnPoint, Quaternion.identity);
    }

    private void manageMovement()
    {
        int direction = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += 1;
        }

        Vector3 targetPosition = transform.position;
        targetPosition.x = targetPosition.x + direction * 100;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, maxSpeed * Time.deltaTime);

        Vector3 finalPosition = transform.position;
        finalPosition.x = Mathf.Clamp(finalPosition.x, -limit, limit);

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
