using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avion_logica : MonoBehaviour
{
    Rigidbody2D my_rb_avion;
    float velocidadavion;
    public  GameObject mi_caja;
    GameObject mi_caja_instancia;
    //public Transform lugardecaja01;
    bool soltar_caja;
    float aleatorio;
    int pisoavion;

    
    // Start is called before the first frame update
    void Start()
    {
        soltar_caja = false;
        my_rb_avion = GetComponent<Rigidbody2D>();
        aleatorio = Random.Range(0.1f,40f);
        velocidadavion=25;

        if (my_rb_avion.position.y ==-2.45f) { pisoavion = 1; }
        if (my_rb_avion.position.y == 1.4f)  { pisoavion = 2; }
        if (my_rb_avion.position.y == 5.2f)  { pisoavion = 3; }

         my_rb_avion.velocity = new Vector2(velocidadavion, 0);
    }

    // Update is called once per frame
    void Update()
    {
           
        if (my_rb_avion.position.x > aleatorio && soltar_caja==false)
        {
            mi_caja_instancia=Instantiate(mi_caja, this.transform.position, this.transform.rotation);
            soltar_caja = true;
            mi_caja_instancia.GetComponent<caja_logica>().setDestinoCaja(pisoavion);
        }

    }

    

}
