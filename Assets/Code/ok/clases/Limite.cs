using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
         if (collision.gameObject.name == "balaplayer(Clone)")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "balaenemy(Clone)")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "enemy01(Clone)")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "player01(Clone)")
        {
            Destroy(collision.gameObject);
        }

         if (collision.gameObject.name == "avion01(Clone)")
        {
            Destroy(collision.gameObject);
        }

    }


}
