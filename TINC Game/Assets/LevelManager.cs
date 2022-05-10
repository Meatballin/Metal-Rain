using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public float respawnDelay;
    public Respawn respawn;
    public Player_Controller controller;
    public GameObject player;
    // Start is called before the first frame update
    void Start(){
        respawn = FindObjectOfType<Respawn>();
        controller = FindObjectOfType<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn(){
        StartCoroutine("RespawnCoroutine");

    }

    public IEnumerator RespawnCoroutine(){
        controller.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        player.gameObject.transform.position = player.gameObject.GetComponent<Respawn>().respawnpoint;
        controller.gameObject.SetActive(true);
    }

}
