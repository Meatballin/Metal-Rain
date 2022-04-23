using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPack : MonoBehaviour
{
    private const int PLAYER_MAX_HEALTH = 100;
    public int healthToAdd = 35;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Has to be a player collision to execute code or could potentially cause crashes
        if(collision.gameObject.CompareTag("Player"))
        {
            //Grab players entity script
            Entity player = collision.GetComponent<Entity>();
            //only allow player to pick up medkit if his health is below max
            if (!(player.health == PLAYER_MAX_HEALTH))
            {
                player.health += healthToAdd;
                if(player.health > 100)
                {
                    player.health = 100;
                }
                //Medkit sound effect
                FindObjectOfType<AudioManager>().Play("MedKitPickUp");
                //Destroy medkit on pickup
                Destroy(this.gameObject);
            }

        }


    }
}
