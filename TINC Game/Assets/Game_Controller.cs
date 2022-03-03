using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{

    public int framerate = 60;

    // Start is called before the first frame update
    void Start()
    {
        // Run the game at the target framerate
        Application.targetFrameRate = framerate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
