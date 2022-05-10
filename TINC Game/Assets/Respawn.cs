/*BY::Cebastian Santiago 
 * CS370 Unity 2D Game Project
 * Code Respawns player and has visible 
 * checks points.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour{
    // Start is called before the first frame update
    //varaibles to restart the player to start position
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checkpointsprite;
    public bool checkpointreached;
    public Vector3 respawnpoint;
    public GameObject fallDetector;
    public GameObject player;
    public GameObject worldController;
    public Camera worldCamera;
    // public GameObject weaponUI;
    // public GameObject hearts;
    public LevelManager levelManager;
   
    void Start(){
        //detects the starting position of the player
        respawnpoint = transform.position;
        checkpointsprite = GetComponent<SpriteRenderer>();
        levelManager = FindObjectOfType<LevelManager>();
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
        
        if (collison.tag == "FallDetector"){
            levelManager.Respawn();
           
        }

         if (collison.tag == "checkpoint"){
            respawnpoint = new Vector3(collison.gameObject.transform.position.x - 1.25f, collison.gameObject.transform.position.y, transform.position.z);
          }
        
        
          if(collison.tag == "Player"){
            checkpointsprite.sprite = greenFlag;
            checkpointreached = true;
         }

    }





}
