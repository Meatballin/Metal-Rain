using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour{
    // Start is called before the first frame update
    //varaibles to restart the player to start position
    private Vector3 respawnpoint;
    public GameObject fallDetector;



    void Start(){
        //detects the starting position of the player
        respawnpoint = transform.position;
    }

    // Update is called once per frame
    void Update(){
        
    }

    /// <summary>
    /// Is the FallDetector objects that detects if the user 
    /// fall down and restarts the object player to the starting point
    /// </summary>
    /// <param name="collison"></param>
    private void OnTriggerEnter2D(Collider2D collison){
        if (collison.tag == "FallDetector")
        {
            transform.position = respawnpoint;
        }

        else if (collison.tag == "checkpoint"){
            respawnpoint = transform.position;

        }
    }


}
