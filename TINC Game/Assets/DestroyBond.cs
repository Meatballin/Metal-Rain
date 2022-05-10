using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBond : MonoBehaviour
{
    public GameObject bonded_target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bonded_target == null){
            Destroy(this.gameObject);
        }
    }
}
