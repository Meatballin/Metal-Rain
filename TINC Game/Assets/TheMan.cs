using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMan : MonoBehaviour
{
    public GameObject target;
    private float stretch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stretch = Random.Range(-0.2f, 0.2f);
        if (target.transform.position.x > this.transform.position.x){
            gameObject.transform.localScale = new Vector3(0.25f*(1+stretch), 0.25f*(1+stretch), 0.25f);
        }
        else{
            gameObject.transform.localScale = new Vector3(-0.25f*(1+stretch), 0.25f*(1+stretch), 0.25f);
        }
    }
}
