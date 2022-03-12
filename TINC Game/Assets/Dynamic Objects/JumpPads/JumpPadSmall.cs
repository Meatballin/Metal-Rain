using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadSmall : MonoBehaviour
{
    private float upwardsForce = 20f;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upwardsForce, ForceMode2D.Impulse);
        }
    }
}
