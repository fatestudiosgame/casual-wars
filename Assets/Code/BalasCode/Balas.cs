using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    int numerobalas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "hero")
        {
            if(core_hero.core_hero_instance.cantidadBalas()!=45)
            {
            numerobalas = Random.Range(3, 11);
            core_hero.core_hero_instance.sumarBalas(numerobalas);
            Destroy(this.gameObject);
            }
        }

    }

}
