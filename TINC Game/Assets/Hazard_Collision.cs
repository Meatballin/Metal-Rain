using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Collision : MonoBehaviour
{
    public float hazardDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<Entity>().ApplyDamage(hazardDamage);
        }
    } 
}
