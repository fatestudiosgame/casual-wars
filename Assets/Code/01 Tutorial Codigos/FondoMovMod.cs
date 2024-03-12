using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovMod : MonoBehaviour
{
    /// FONDOS
   
    


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            transform.position = new Vector3(transform.position.x - 0.0075f,
            transform.position.y,
            transform.position.z);
            

        if (transform.position.x < -85)
        {
            Destroy(this.gameObject);
        }

    }
}
