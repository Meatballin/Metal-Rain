using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpPadLarge : MonoBehaviour
{
    public float upwardsForce = 35f;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            float degree = this.transform.rotation.eulerAngles.z + 90; 
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad)) * upwardsForce), ForceMode2D.Impulse);
        }
    }
}
