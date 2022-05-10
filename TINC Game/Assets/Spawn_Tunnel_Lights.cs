using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Tunnel_Lights : MonoBehaviour
{
    public GameObject Tunnel_Light_Prefab_1;

    public int interval = 30;
    private int tick = 0;
    private Quaternion light_rot;
    public GameObject player;
    public Vector2 light_motion; 
    // Start is called before the first frame update
    void Start()
    {
        light_rot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        tick += 1;
        
        if (tick >= interval){
            GameObject last_light = Instantiate(Tunnel_Light_Prefab_1, transform.position, light_rot);
            last_light.GetComponent<Tunnel_Light_Move>().player_tracking = player;
            last_light.GetComponent<Tunnel_Light_Move>().Motion_Vector = light_motion;
            tick = 0;
        }
    }

}

