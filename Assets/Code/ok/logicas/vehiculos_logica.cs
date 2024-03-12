using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class vehiculos_logica : MonoBehaviour
{
    public GameObject emoticon;
    public GameObject seleccion_piso_menu;
    
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.name == "hero")
        {
            emoticon.SetActive(true);
          if(this.name=="carro_grupo") {core_logica_juego_gun.core_logica_juego_gun_instance.carro_state = true; }
          if(this.name=="helicoptero_grupo") {core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state = true;}
        }
    }
    

     private void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.gameObject.name == "hero")
        {
            emoticon.SetActive(false);
            seleccion_piso_menu.SetActive(false);           
            if(this.name=="carro_grupo") { core_logica_juego_gun.core_logica_juego_gun_instance.carro_state = false;}
            if(this.name=="helicoptero_grupo") {core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state = false;}
        }
    }


    


}
