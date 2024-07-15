    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caja_logica : MonoBehaviour
{
    Rigidbody2D my_rb_caja;
    int numerobalas;
    int destino;

 
    void Start()
    {
        my_rb_caja = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (destino)
        {
            case 1:
                if (my_rb_caja.position.y < -4.75)
                {
                    my_rb_caja.velocity = Vector2.zero;
                    my_rb_caja.gravityScale = 0;
                }
                break;
            case 2:
                if (my_rb_caja.position.y < -0.95f)
                {
                    my_rb_caja.velocity = Vector2.zero;
                    my_rb_caja.gravityScale = 0;
                }
                break;
            case 3:
                if (my_rb_caja.position.y < 2.85f)
                {
                    my_rb_caja.velocity = Vector2.zero;
                    my_rb_caja.gravityScale = 0;
                }
                break;
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if
         (collision.gameObject.name == "hero")

        {
            numerobalas = Random.Range(30, 41);
            core_hero.core_hero_instance.sumarBalas(numerobalas);
            Destroy(this.gameObject);

        }

    }

    public void setDestinoCaja(int destt)
    {
        destino = destt;
    }


}
