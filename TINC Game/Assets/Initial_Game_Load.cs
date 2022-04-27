using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initial_Game_Load : MonoBehaviour
{
    public AudioManager music_controller;
    // Start is called before the first frame update
    void Start()
    {
        if (music_controller != null){
            music_controller.Play("Menu_Music");
        }
        SceneManager.LoadScene("Start Screen");
    }

}
