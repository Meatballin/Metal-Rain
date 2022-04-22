using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public GameObject Heart1 , Heart2 , Heart3;
    public int life;
    // Start is called before the first frame update
    void Start(){
        life = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3 .gameObject.SetActive(true); 
    }

    void Update()
    {

        switch (life){
            case 3:Heart1.gameObject.SetActive(true);
                   Heart2.gameObject.SetActive(true);
                   Heart3.gameObject.SetActive(true);
                break;
            case 2:Heart1.gameObject.SetActive(true);
                   Heart2.gameObject.SetActive(true);
                   Heart3.gameObject .SetActive(false);
                break;
            case 1:Heart1.gameObject.SetActive(true);
                   Heart2.gameObject.SetActive(false);
                   Heart3.gameObject.SetActive (false);
              break;
            case 0:Heart1.gameObject.SetActive(false);
                   Heart2.gameObject.SetActive(false);
                   Heart3.gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

        }
    }

    public void add(){
        life++;
    }
}
