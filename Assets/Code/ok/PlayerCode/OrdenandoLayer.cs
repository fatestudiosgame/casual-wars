using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenandoLayer : MonoBehaviour
{
    int num_aleatorio_layer;
    // Start is called before the first frame update
    void Start()
    {
        num_aleatorio_layer= Random.Range(0,1000);

        for(int i=0;i< GetComponentsInChildren<SpriteRenderer>().Length ; i++)
        {
            GetComponentsInChildren<SpriteRenderer>()[i].sortingOrder=num_aleatorio_layer;
        }
       
         
        
    }

  
}
