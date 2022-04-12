using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 120f;
    public int damage = 70;
    public float explosionPower = 3500f;
    public float explosionRadius = 3.25f;
    public Rigidbody2D rb;
    
    public GameObject destroyEffect;
    public GameObject impulseObject;

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        //Destroy bullets after being in world for two seconds
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Entity integration
        if ((hitInfo.GetComponent<Entity>()  != null) && !((hitInfo.gameObject.layer == 8) || (hitInfo.gameObject.layer == 3))){
            Entity entity = hitInfo.GetComponent<Entity>();

            entity.ApplyDamage(damage);
            FindObjectOfType<AudioManager>().Play("RocketExplosion");
            if (destroyEffect != null){
                GameObject newExplosion = Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
                GameObject impulse = Instantiate(impulseObject, gameObject.transform.position, Quaternion.identity);
                impulse.GetComponent<Explosion_Physics>().power = explosionPower;
                impulse.GetComponent<Explosion_Physics>().radius = explosionRadius;
            }
            Destroy(gameObject);
            
                
        }


    }
}
