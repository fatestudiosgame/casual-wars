using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendedores_logica : MonoBehaviour
{
    public GameObject emoticon;
   
      private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.name == "hero")
        {
            emoticon.SetActive(true);
            
          if(this.name=="vendedor_armas_grupo") {core_logica_juego_gun.core_logica_juego_gun_instance.vendedor_armas_state = true;}
          if(this.name=="cocinero_grupo") {core_logica_juego_gun.core_logica_juego_gun_instance.cocinero_state = true;}
        }
    }
    

     private void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.gameObject.name == "hero")
        {
            emoticon.SetActive(false);           
            if(this.name=="vendedor_armas_grupo") { core_logica_juego_gun.core_logica_juego_gun_instance.vendedor_armas_state = false; }
            if(this.name=="cocinero_grupo") {core_logica_juego_gun.core_logica_juego_gun_instance.cocinero_state = false; }
        }
    }

}
