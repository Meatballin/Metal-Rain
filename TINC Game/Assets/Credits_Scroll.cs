using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Scroll : MonoBehaviour
{
    public Vector2 Motion_Vector;
    public bool is_scrolling;
    public float ramp_rate = 0.002f;
    public float max_scroll_speed = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_scrolling & (Motion_Vector.y < max_scroll_speed)){
            Motion_Vector.y += ramp_rate;
        }

        if (!is_scrolling & (Motion_Vector.y > 0)){
            Motion_Vector.y += -ramp_rate;
        }

        Vector2 current_pos = new Vector2(gameObject.transform.position.x + Motion_Vector.x, gameObject.transform.position.y + Motion_Vector.y);
        gameObject.transform.position = current_pos;
    }
}
