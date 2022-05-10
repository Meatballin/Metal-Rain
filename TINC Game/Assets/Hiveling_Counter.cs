using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiveling_Counter : MonoBehaviour
{
    public GameObject mother;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        mother.GetComponent<Spawn_Hivelings>().hive_count += -1;
    }
}
