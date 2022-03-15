using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float verticalMovement;
    private float speed = 10f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D self;

    private void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(verticalMovement) > 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        isClimbing = false;
    }
}
