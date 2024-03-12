using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "balaenemy(Clone)")
        {
            if (this.name == "DefensaBase01") { core_logica_juego_gun.core_logica_juego_gun_instance.mod_vida_base_aliada(1); }
            if (this.name == "DefensaBase02") { core_logica_juego_gun.core_logica_juego_gun_instance.mod_vida_base_aliada(2); }
            if (this.name == "DefensaBase03") { core_logica_juego_gun.core_logica_juego_gun_instance.mod_vida_base_aliada(3); }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "balahero(Clone)")
        {
           Destroy(collision.gameObject);
        }
    }

}
