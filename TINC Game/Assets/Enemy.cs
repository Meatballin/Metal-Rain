using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    //public ParticleSystem explodeParticle;

    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
            //Instantiate(explodeParticle, transform.position, explodeParticle.transform.rotation);
        }

    }

    /*
    void EnemyDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explodeParticle, transform.position, explodeParticle.transform.rotation);
        }

            
    }
    */

    /*
    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */
}
