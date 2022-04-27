using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Scuttler : MonoBehaviour{

    // How hard (and how high) the character will jump
    public float Jump_Power = 2000;
    // How fast the character will accelerate horizontally when controlled
    public float Acceleration = 200;
    // The max speed a player can be accelerated by the player
    public float Max_Horizontal_Speed = 10;
    // The force applied in attempt to stop the player when they are not holding a horizontal movement button
    public float Horizontal_Brake_Force = 40;
    // The maximum fall speed a player can reach 
    public float Max_Fall_Speed = 30;
    // The downward acceleration applied when a player releases all jump buttons
    public float Controlled_Fall_Speed = 60;
    public float MovementSmoothing = 0.8f;
    private float targetHorizontalSpeed = 0f;

    private Rigidbody2D selfBody;
    private Vector2 jump_Force;
    private Vector2 controlledFallForce;
    private Vector2 rightForce;
    private Vector2 leftForce;
    private Vector2 m_Velocity;

    //varaibles to restart the player to start position
    //private Vector3 respawnpoint;
    // public GameObject fallDetector;

    // The following 3 variables are used for queuing jump actions to correct for human error in jump presses
    // Results in smoother feeling controls
    private bool isJumpQueued = false;
    private int jumpQueueTimerMax = 10;
    private int jumpQueueTimer = 10;

    // The layers a player is allowed to jump off of
    public LayerMask Traverseable_Layers;

    public bool ai_jump = false;
    public bool ai_left = false;
    public bool ai_right = false;
    public GameObject attackEffect;
    public float attackRange = 1f;
    public float attackSpeed = 10f;
    public float attackDamage = 1f;
    public float attackTick = 0f;
    public float chaseRadius = 10f;

    public bool shoots_bullets = false;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bullet_speed = 100f;

    // Start is called before the first frame update
    void Start(){
        selfBody = gameObject.GetComponent<Rigidbody2D>();
        jump_Force = new Vector2(0, Jump_Power);
        controlledFallForce = new Vector2(0, -Controlled_Fall_Speed);
        leftForce = new Vector2(-Acceleration, 0);
        rightForce = new Vector2(Acceleration, 0);

    }

    // Checks if there is an object below the player that they may jump off of
    bool IsGrounded() {
        return Physics2D.BoxCast(selfBody.position + (new Vector2(0,-0.75f)), new Vector2(1,0.125f), 0.0f, new Vector2(0, 0), 0.0f, Traverseable_Layers);
    }

    // Update is called once per frame
    void Update(){
        ChasePlayer();
        Jump();
        HorizontalMovement();
        AttackPlayer();
    }

    void Jump(){

        if ((ai_jump == true) & !(IsGrounded()))
        {
            isJumpQueued = true;
            jumpQueueTimer = jumpQueueTimerMax;
        }

        if (jumpQueueTimer > 0)
        {
            jumpQueueTimer += -1;
            if (jumpQueueTimer <= 0)
            {
                isJumpQueued = false;
            }
        }

        if ((ai_jump == true) || (isJumpQueued == true))
        {
            if (IsGrounded())
            {
                selfBody.AddForce(jump_Force);
            }
        }

        if ((selfBody.velocity.y < Max_Fall_Speed) && !(ai_jump == true))
        {
            selfBody.AddForce(controlledFallForce);
        }
    }
    void HorizontalMovement()
    {
        //Smoothing player horizontal movement
        Vector2 targetVelocity = new Vector2(targetHorizontalSpeed, selfBody.velocity.y);
        selfBody.velocity = Vector2.SmoothDamp(selfBody.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

        if (ai_left)
        {
            targetHorizontalSpeed = -Max_Horizontal_Speed;
        }
        if (ai_right)
        {
            targetHorizontalSpeed = Max_Horizontal_Speed;
        }
        
        if(!ai_left & !ai_right)
        {
            targetHorizontalSpeed = 0;
        }

    }



    void ChasePlayer(){
        
        Player_Controller Player = CircleCollider2D.FindObjectOfType<Player_Controller>();
        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
            if (distanceToPlayer < chaseRadius){
                if (transform.position.x > Player.transform.position.x){
                    ai_left = true;
                    ai_right = false;
                }
                if (transform.position.x < Player.transform.position.x){
                    ai_left = false;
                    ai_right = true;
                }
                if (transform.position.y < Player.transform.position.y){
                    ai_jump = true;
                }
                else
                {
                    ai_jump = false;
                }
            }
        }
        
    }

    void AttackPlayer(){

        Player_Controller Player = CircleCollider2D.FindObjectOfType<Player_Controller>();
        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
            if (distanceToPlayer < attackRange){
                attackTick += 1;
                if (attackTick >= attackSpeed){
                    attackTick = 0;
                    if (shoots_bullets == false){
                        firePoint.transform.position =gameObject.transform.position;
                        Player.gameObject.GetComponent<Entity>().ApplyDamage(attackDamage);
                        if (attackEffect != null){
                        Instantiate(attackEffect, Player.transform.position, Quaternion.identity);
                        }
                        
                    }
                    else{
                        Vector2 targetDir = (Player.transform.position - gameObject.transform.position).normalized;
                        Vector2 fire_offset = new Vector2(targetDir.x*1f, targetDir.y*1f);
                        firePoint.transform.position = new Vector2(gameObject.transform.position.x + fire_offset.x, gameObject.transform.position.y + fire_offset.y);

                        GameObject fired_bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        fired_bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(targetDir.x*bullet_speed, targetDir.y*bullet_speed));
                        fired_bullet.GetComponent<Bullet_Enemy>().damage = attackDamage;
                    }
                    
                }
            }
        }

    }


    // This draws the character's IsGrounded collision box in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (new Vector3(0,-0.75f,0)), new Vector2(1,0.125f));
        // Attack range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        // Aggro radius
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }


}
