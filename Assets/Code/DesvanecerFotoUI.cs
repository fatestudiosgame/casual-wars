using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesvanecerFotoUI : MonoBehaviour
{
   
    float tiempo;
    public int tiempodesvanecimiento;
    bool desvanecer_state;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      
           
        if (desvanecer_state == true) { 
        if (tiempo > 254)
        {
            tiempo = 254;
                GameObject.Destroy(this);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(255-tiempo));
        }

        tiempo=tiempo+3;
        }


    }



}
