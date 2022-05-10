using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel_Light_Move : MonoBehaviour
{
    public Vector2 Motion_Vector;
    public GameObject player_tracking;
    private int destroy_distance = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 current_pos = new Vector2(gameObject.transform.position.x + Motion_Vector.x, gameObject.transform.position.y + Motion_Vector.y);
        gameObject.transform.position = current_pos;

        if (gameObject.transform.position.x < player_tracking.transform.position.x - destroy_distance){
            Destroy(gameObject);
        }
    }
}
