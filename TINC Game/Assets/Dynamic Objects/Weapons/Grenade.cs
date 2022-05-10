using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 100;
    public float explosionPower = 3500f;
    public float explosionRadius = 3.25f;
    public Rigidbody2D rb;
    public int bounceNumber = 0;

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
        Destroy(gameObject, 2.8f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3.5f);
        int count = 0;
        // AOE damage integration
        if ((hitInfo.GetComponent<Entity>() != null) && !((hitInfo.gameObject.layer == 8) || (hitInfo.gameObject.layer == 3)))
        {

            foreach (Collider2D enemies in hits)
            {
                //First entity that is hit will take full damage.
                //Anything after is splash damage (half)
                if (enemies.CompareTag("Shootable") && count == 0)
                {
                    Entity entity = enemies.gameObject.GetComponent<Entity>();
                    entity.ApplyDamage(damage);
                }
                //Splash damage to anything that isn't directly hit
                if (enemies.CompareTag("Shootable") && count != 0)
                {
                    Entity entity = enemies.gameObject.GetComponent<Entity>();
                    entity.ApplyDamage(damage / 2);
                }
                count++;

            }


            FindObjectOfType<AudioManager>().Play("RocketExplosion");

            if (destroyEffect != null)
            {
                GameObject newExplosion = Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
                GameObject impulse = Instantiate(impulseObject, gameObject.transform.position, Quaternion.identity);
                impulse.GetComponent<Explosion_Physics>().power = explosionPower;
                impulse.GetComponent<Explosion_Physics>().radius = explosionRadius;
            }
            Destroy(gameObject);

        }

        

    }
}
