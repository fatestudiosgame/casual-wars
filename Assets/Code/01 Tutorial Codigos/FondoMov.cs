﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMov : MonoBehaviour
{
    int movimiento;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            transform.position = new Vector3(transform.position.x - 0.1f,
            transform.position.y,
            transform.position.z);
        
        if (transform.position.x < -80) { Destroy(this.gameObject); }
    
    
    }
}
