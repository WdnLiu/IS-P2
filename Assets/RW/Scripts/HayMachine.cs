using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float maxSpeed = 35f;
    private float currSpeed = 0f;
    private float limit = 22f;
    private float speed = 0.5f;

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

        // if (direction != 0)
        // {
        //     currSpeed = Mathf.SmoothDamp(currSpeed, maxSpeed, ref speed, 0.3f);
        // }
        // else
        // {
        //     currSpeed = Mathf.SmoothDamp(currSpeed, 0f, ref speed, 0.3f);
        // }

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x + direction * currSpeed * Time.deltaTime, -limit, limit);

        transform.position = Vector3.SmoothDamp(transform.position, position, maxSpeed * Time.deltaTime);
    }
}
