using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearPlatform : MonoBehaviour
{

    public float time = 100;
    public float respawn_time = 500;
    public int tick = 0;
    public int return_tick = 0;
    public bool triggered = false;

    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true){
            tick += 1;
            if (tick >= time/2){
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (tick >= time){
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                tick = 0;
                triggered = false;
            }
        }
        if (gameObject.GetComponent<Collider2D>().enabled == false){
            return_tick += 1;
            if (return_tick >= respawn_time){
                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
                return_tick = 0;
            }
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
