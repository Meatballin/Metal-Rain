using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Hivelings : MonoBehaviour
{
    public int interval = 10;
    private int tick = 0;
    public int hive_max = 20;
    public int hive_count = 0;
    public GameObject hiveling;
    public float start_spawning_distance = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick += 1;
        Player_Controller Player = CircleCollider2D.FindObjectOfType<Player_Controller>();

        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);
            if ((tick > interval) & (hive_count < hive_max) & (distanceToPlayer < start_spawning_distance)){
                tick = 0;
                GameObject new_hiveling = Instantiate(hiveling, gameObject.transform.position, gameObject.transform.rotation);
                new_hiveling.GetComponent<Hiveling_Counter>().mother = gameObject;
                hive_count += 1;
            }
        }
        
        
    }
}
