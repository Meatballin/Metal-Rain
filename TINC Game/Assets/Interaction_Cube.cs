using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Cube : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D selfBody;
    private Vector2 upForce;
    private Vector2 downForce;
    private Vector2 rightForce;
    private Vector2 leftForce;


    // Start is called before the first frame update
    void Start()
    {
        selfBody = gameObject.GetComponent<Rigidbody2D>();
        upForce = new Vector2(0, speed);
        downForce = new Vector2(0, -speed);
        leftForce = new Vector2(-speed, 0);
        rightForce = new Vector2(speed, 0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            selfBody.AddForce(upForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            selfBody.AddForce(downForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
            selfBody.AddForce(leftForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            selfBody.AddForce(rightForce);
        }


    }
}
