using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float verticalMovement;
    private float speed = 10f;
    [SerializeField] private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D self;
    
    private void Update()
    {
        //Mathf.Abs(verticalMovement) > 0)
        verticalMovement = Input.GetAxis("Vertical");
        if(isLadder && Input.GetButton("Vertical"))
        {
            isClimbing = true;
        }

       
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            self.gravityScale = 0f;
            self.velocity = new Vector2(self.velocity.x, verticalMovement * speed);
        }
        else
            self.gravityScale = 3f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    /* private void OnTriggerStay(Collider2D collision)
     {
         if(collision.CompareTag("Ladder"))
         {
             isLadder = true;
         }
     }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        isClimbing = false;
    }
}
