using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    public int velocidadbala;
    float posicion_inicial_laser;
    public float rango_laser;
    GameObject objetivo;
    int tipo_bala;


    // Start is called before the first frame update
    void Start()
    {
       
        posicion_inicial_laser = GetComponent<Transform>().position.x;
        rango_laser = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.x < (posicion_inicial_laser - rango_laser))
        {
            Destroy(this.gameObject);
        }
    }

    public void disparar(GameObject obj)
    {
        objetivo = obj;
        GetComponent<Rigidbody2D>().velocity = (transform.TransformDirection(objetivo.transform.position - this.transform.position))*velocidadbala; 
        
    }



     public void setTipobala(int t_bala)
    {
        tipo_bala = t_bala;
    }

    public int  getTipobala()
    {
        return tipo_bala;
    }


}
