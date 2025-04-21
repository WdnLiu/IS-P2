using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float maxSpeed = 750f;
    public Vector3 velocity = Vector3.zero;
    private float limit = 22f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
