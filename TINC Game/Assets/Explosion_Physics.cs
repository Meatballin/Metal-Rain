using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Physics : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            if (hit.gameObject.GetComponent<Rigidbody2D>() != null){
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

                Vector2 explosion_dir = new Vector2(rb.position.x - transform.position.x, rb.position.y - transform.position.y);
                explosion_dir.Normalize();

                if (rb != null){
                    rb.AddForce(explosion_dir * power);
                }
            }
            
                
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
