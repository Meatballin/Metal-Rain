using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Controller : MonoBehaviour
{
    public GameObject[] text_list;
    public int timer = 100;
    public int stop_timer = 200;
    private int tick = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick++;
        if (tick >= timer & !(tick >= stop_timer)){
            for (int i = 0; i < text_list.Length; i++){
                text_list[i].GetComponent<Credits_Scroll>().is_scrolling = true;
            }
        }
        else{
            for (int i = 0; i < text_list.Length; i++){
                text_list[i].GetComponent<Credits_Scroll>().is_scrolling = false;
            }
        }
    }
}
