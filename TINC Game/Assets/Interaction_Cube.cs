using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Cube : MonoBehaviour
{
    public float speed = 10;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D selfBody = gameObject.GetComponent<Rigidbody2D>();
        Vector2 upForce = new Vector2(0, speed);
        Vector2 downForce = new Vector2(0, -speed);
        Vector2 leftForce = new Vector2(-speed, 0);
        Vector2 rightForce = new Vector2(speed, 0);


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
