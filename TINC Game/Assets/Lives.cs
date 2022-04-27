using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public GameObject Heart1 , Heart2 , Heart3 , Heart4 , Heart5 , Heart6;
    public int life = 3;
    // Start is called before the first frame update
    void Start(){
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3 .gameObject.SetActive(true); 
    }

    void Update(){
        switch (life){
            case 6:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(true);
                Heart6.gameObject.SetActive(true);
                break;
            case 5:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(true);
                Heart6.gameObject.SetActive(false);
                break;
            case 4:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(false);
                Heart6.gameObject.SetActive(false);
                break;
            case 3:Heart1.gameObject.SetActive(true);
                   Heart2.gameObject.SetActive(true);
                   Heart3.gameObject.SetActive(true);
                   Heart4.gameObject.SetActive(false);
                   Heart5.gameObject.SetActive(false);
                   Heart6.gameObject.SetActive(false); 
                break;
            case 2:Heart1.gameObject.SetActive(true);
                   Heart2.gameObject.SetActive(true);
                   Heart3.gameObject .SetActive(false);
                   Heart4.gameObject.SetActive(false);
                   Heart5.gameObject.SetActive(false);
                   Heart6.gameObject.SetActive(false);
                break;
            case 1:Heart1.gameObject.SetActive(true);
                   Heart2.gameObject.SetActive(false);
                   Heart3.gameObject.SetActive (false);
                   Heart4 .gameObject.SetActive(false);
                   Heart5.gameObject.SetActive(false);
                   Heart6.gameObject.SetActive(false);
              break;
            case 0:Heart1.gameObject.SetActive(false);
                   Heart2.gameObject.SetActive(false);
                   Heart3.gameObject.SetActive(false);
                   Heart4.gameObject.SetActive(false);
                   Heart5.gameObject.SetActive(false);
                   Heart6.gameObject.SetActive(false);
                SceneManager.LoadScene("Game Over Screen");
                break;

        }
    }

    public void add(){
        life++;
    }
}
