using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Heart;
    public Lives life;
    void Start()
    {
        life = FindObjectOfType<Lives>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            collision.GetComponent<Lives>().add();
            Heart.SetActive(false);
        }

    }
}
