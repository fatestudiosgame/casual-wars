using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "balaplayer(Clone)")
        {
            
           collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        }

        if (collision.gameObject.name == "balaenemy(Clone)")
        {

            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

}
