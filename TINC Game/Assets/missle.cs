using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class missle : MonoBehaviour{
    // Start is called before the first frame update
    public Transform target;
    private Rigidbody2D rb;
    public GameObject explosion;
    public float speed = 20f;
    public float rotatespeed = 200f;
    public float damage = 40f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
     void FixedUpdate(){
            Vector2 dir = (Vector2)target.position - rb.position;
            dir.Normalize();
            float change =  Vector3.Cross(dir, transform.up).z;
            rb.angularVelocity = -change * rotatespeed;
            rb.velocity = transform.up * speed;
     }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            Instantiate(explosion, transform.position, transform.rotation);
            collision.GetComponent<Entity>().health += -damage;
            Destroy(gameObject);
        }
        if((collision.tag == "Shootable" || collision.tag == "Bullet" || collision.tag == "Rocket") & (collision.GetComponent<Enemy_Scuttler>() == null)){
            Instantiate(explosion, transform.position, transform.rotation);
            if (collision.tag == "Bullet" || collision.tag == "Rocket"){
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

        
    }
}
