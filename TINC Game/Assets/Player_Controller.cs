using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{

    // How hard (and how high) the character will jump
    public float Jump_Power = 1300;
    // How fast the character will accelerate horizontally when controlled
    public float Acceleration = 200;
    // The max speed a player can be accelerated by the player
    public float Max_Horizontal_Speed = 10;
    // The force applied in attempt to stop the player when they are not holding a horizontal movement button
    public float Horizontal_Brake_Force = 40;
    // The maximum fall speed a player can reach 
    public float Max_Fall_Speed = 30;
    // The downward acceleration applied when a player releases all jump buttons
    public float Controlled_Fall_Speed = 30;

    private Rigidbody2D selfBody;
    private Vector2 jump_Force;
    private Vector2 controlledFallForce;
    private Vector2 rightForce;
    private Vector2 leftForce;

    // The following 3 variables are used for queuing jump actions to correct for human error in jump presses
    // Results in smoother feeling controls
    private bool isJumpQueued = false;
    private int jumpQueueTimerMax = 10;
    private int jumpQueueTimer = 10;

    // The layers a player is allowed to jump off of
    public LayerMask Traverseable_Layers;



    // Start is called before the first frame update
    void Start()
    {
        selfBody = gameObject.GetComponent<Rigidbody2D>();
        jump_Force = new Vector2(0, Jump_Power);
        controlledFallForce = new Vector2(0, -Controlled_Fall_Speed);
        leftForce = new Vector2(-Acceleration, 0);
        rightForce = new Vector2(Acceleration, 0);
    }

    // Checks if there is an object below the player that they may jump off of
    bool IsGrounded() {
        return Physics2D.BoxCast(selfBody.position + (new Vector2(0,-1.0625f)), new Vector2(1,0.125f), 0.0f, new Vector2(0, 0), 0.0f, Traverseable_Layers);
    }



    // Update is called once per frame
    void Update()
    {

        

        if ((Input.GetKeyDown(KeyCode.W)) & !(IsGrounded())) {
            isJumpQueued = true;
            jumpQueueTimer = jumpQueueTimerMax;
        }

        if (jumpQueueTimer > 0) {
            jumpQueueTimer += -1;
            if (jumpQueueTimer <= 0){
                isJumpQueued = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.W)) || ((Input.GetKeyDown("space")) || isJumpQueued == true))
        {
            if (IsGrounded()) {
                selfBody.AddForce(jump_Force);
            }  
        } 
        
        if ((selfBody.velocity.y < Max_Fall_Speed) & (!(Input.GetKey(KeyCode.W)) & !(Input.GetKey("space"))))
        {
            selfBody.AddForce(controlledFallForce);
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (selfBody.velocity.x > -Max_Horizontal_Speed) {
                selfBody.AddForce(leftForce);
            }
        } else if (selfBody.velocity.x < -0.1){
            selfBody.AddForce(new Vector2(Horizontal_Brake_Force, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (selfBody.velocity.x < Max_Horizontal_Speed) {
                selfBody.AddForce(rightForce); 
            }
        } else if (selfBody.velocity.x > 0.1){
            selfBody.AddForce(new Vector2(-Horizontal_Brake_Force, 0));
        }

        if (Input.GetKey(KeyCode.S)){
            selfBody.AddForce(controlledFallForce);
        }


    }


    // This draws the character's IsGrounded collision box in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (new Vector3(0,-1.0625f,0)), new Vector2(1,0.125f));
    }


}
