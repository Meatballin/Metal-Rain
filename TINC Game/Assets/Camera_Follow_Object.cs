using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_Follow_Object : MonoBehaviour
{

    public Transform player;
    public Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    void Start()
    {
        transform.position = player.position + cameraOffset;
    }

    void FixedUpdate ()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y, -10);
        Vector3 finalPosition = player.position + cameraOffset;
        Vector3 lerpPosition = Vector3.Lerp (transform.position, finalPosition, cameraSpeed);
        Vector3 lerpFlatten = new Vector3(lerpPosition.x, lerpPosition.y, -10);

        transform.position = lerpFlatten;
    }
}
