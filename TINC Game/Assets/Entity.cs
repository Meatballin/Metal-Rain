using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool is_immortal = false;
    public float health = 100;
    public GameObject deathEffect;
    public GameObject collisionEffect;

    private float damageConstant = 1;
    public float impactResistance = 0;
 
    void Start()
    {
        // Called on start!
    }


    void OnCollisionEnter2D(Collision2D collision) {
        Vector3 impactVelocity = collision.relativeVelocity;
        GameObject collisionPartner = collision.gameObject;

        // Return zero or the damage, whichever is higher
        float magnitude = Mathf.Max(0f, impactVelocity.magnitude - impactResistance);
        // Calculate damage and apply it
        float damage = magnitude * damageConstant;

        // If there is a collision effect produce it
        if ((damage > 0) && (collisionEffect != null)){
            Vector2 colPosition = collision.GetContact(0).point;
            Instantiate(collisionEffect, colPosition, Quaternion.identity);
        }

        ApplyDamage(damage);
        // Debug
        // Debug.Log("COLLISION DAMAGE: " + damage);
    }

    public void ApplyDamage(float damage)
    {

        if (is_immortal == false){
           health -= damage;
            if (health <= 0)
            {
                OnDestruction();
            }
        }
        
    }

    void OnDestruction()
    {
        if (deathEffect != null){
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    
}
