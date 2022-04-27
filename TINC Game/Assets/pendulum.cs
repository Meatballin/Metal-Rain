using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour
{
    Rigidbody2D rgb2d;

    public float moveSpeed;
    public float leftShift;
    public float rightShift;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void ChangeInDirection()
    {
        if(transform.rotation.z > rightShift)
        {
            movingClockwise = false;
        }

        if (transform.rotation.z < leftShift)
        {
            movingClockwise = true;
        }
    }
    
    public void Movement()
    {
        ChangeInDirection();

        if (movingClockwise)
        {
            rgb2d.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rgb2d.angularVelocity = -1 * moveSpeed;
        }
    }
}
