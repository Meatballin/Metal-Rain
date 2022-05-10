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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick += 1;
        if ((tick > interval) & (hive_count < hive_max)){
            tick = 0;
            GameObject new_hiveling = Instantiate(hiveling, gameObject.transform.position, gameObject.transform.rotation);
            new_hiveling.GetComponent<Hiveling_Counter>().mother = gameObject;
            hive_count += 1;
        }
    }
}
