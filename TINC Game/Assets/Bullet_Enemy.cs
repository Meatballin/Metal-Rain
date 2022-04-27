using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    public int damage = 70;
    public Rigidbody2D rb;

    public GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy bullets after being in world for five seconds
        Destroy(gameObject, 5f);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision!");

        // Entity integration
        if (collision.gameObject.tag == "Shootable"){
            Entity entity = collision.gameObject.GetComponent<Entity>();
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
        Player_Controller player = collision.gameObject.GetComponent<Player_Controller>();
        if (player != null)
        {
            player.gameObject.GetComponent<Entity>().ApplyDamage(damage);
        }
        if(collision.gameObject.layer == 8)
        {
            GameObject newExplosion = Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("RifleBulletHit");
            Destroy(gameObject);
        }

    }
}
