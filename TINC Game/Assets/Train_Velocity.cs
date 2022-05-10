using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Velocity : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 Tug_Force;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Tug_Force);
    }
}
