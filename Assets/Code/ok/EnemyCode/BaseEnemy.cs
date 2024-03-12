using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "balaplayer(Clone)" || collision.gameObject.name == "balahero(Clone)")
        {
            if (this.name == "BaseEnemigaS01") { core_logica_juego_gun.core_logica_juego_gun_instance.modificarVidaBaseEnemy(1); }
            if (this.name == "BaseEnemigaS02") { core_logica_juego_gun.core_logica_juego_gun_instance.modificarVidaBaseEnemy(2); }
            if (this.name == "BaseEnemigaS03") { core_logica_juego_gun.core_logica_juego_gun_instance.modificarVidaBaseEnemy(3); }
            Destroy(collision.gameObject);
        }

    }

}
