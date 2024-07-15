using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinero : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "hero")
        {
            core_logica_juego_gun.core_logica_juego_gun_instance.sumarDinero(10);
            Destroy(this.gameObject);
        }

         if(collision.gameObject.name == "hero_tutorial")
        {
            GameObject.Find("codigo_tutorial").GetComponent<LogicaTutorial>().sumarDinero(10);
            Destroy(this.gameObject);
        }
    }
}
