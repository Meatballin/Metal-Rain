using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Bias_Anchor : MonoBehaviour
{
    public Camera cam;
    public Transform player_object;
    private Vector2 anchor_point;
    public int camera_bias_constant = 4;
    // private int weight_count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);

        // anchor_point.x = player_object.position.x;
        // anchor_point.y = player_object.position.y;

        // for (int i = 0; i < camera_bias_constant; i++){
        //     anchor_point.x += player_object.position.x;
        //     anchor_point.y += player_object.position.y;
        //     weight_count += 1;
        // }
        // anchor_point.x += worldPoint2d.x;
        // anchor_point.y += worldPoint2d.y;
        // weight_count += 1;

        // anchor_point.x = anchor_point.x / weight_count;
        // anchor_point.y = anchor_point.y / weight_count;

        anchor_point.x = ((player_object.position.x * (camera_bias_constant -1)) + worldPoint2d.x) / camera_bias_constant;
        anchor_point.y = ((player_object.position.y * (camera_bias_constant -1)) + worldPoint2d.y) / camera_bias_constant;

        gameObject.transform.position = new Vector2(anchor_point.x, anchor_point.y);

        // weight_count = 0;
    }
}
