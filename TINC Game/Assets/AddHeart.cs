using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            if (collision.GetComponent<Lives>().life < 6){
                collision.GetComponent<Lives>().add();
                Destroy(this.gameObject);
            }
        }
    }
}
