using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{

    public int framerate = 60;

    // Test prefab to spawn
    public GameObject testPrefab;
    public Camera Main_Camera;


    // Start is called before the first frame update
    void Start()
    {
        // Run the game at the target framerate
        Application.targetFrameRate = framerate;

        

    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.GetMouseButtonDown(0)){
            Vector3 worldPosition = Main_Camera.ScreenToWorldPoint(Input.mousePosition);
            //GameObject newExplosion = Instantiate(testPrefab, worldPosition, Quaternion.identity);

            // Use this to change the explosion color in script
            // ParticleSystem.MainModule settings = newExplosion.GetComponent<ParticleSystem>().main;
            // settings.startColor = new ParticleSystem.MinMaxGradient(Color.yellow);
         }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}
