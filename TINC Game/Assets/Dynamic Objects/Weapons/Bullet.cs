using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public int damage = 70;
    public Rigidbody2D rb;

    public GameObject destroyEffect;

   
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

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        // Entity integration
        if (hitInfo.tag == "Shootable"){
            Entity entity = hitInfo.GetComponent<Entity>();
            if (entity != null)
                {
                    entity.ApplyDamage(damage);
                    if (destroyEffect != null){
                        GameObject newExplosion = Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
                        
                    }
                    Destroy(gameObject);
                }
        }


        //Damage applied to enemy
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(hitInfo.gameObject.CompareTag("Shootable"))
        {
            GameObject newExplosion = Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("RifleBulletHit");
            Destroy(gameObject);
        }
        

    }

}
