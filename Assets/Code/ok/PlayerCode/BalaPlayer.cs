using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    public int velocidadbala;
    public float posicionInicialBala;
    float rango_bala;
    GameObject objetivo;
    

    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Rigidbody2D>().velocity = transform.right * velocidadbala;
        posicionInicialBala = GetComponent<Transform>().position.x;
        rango_bala = 20;
        GetComponent<Rigidbody2D>().velocity = transform.right * velocidadbala;
        
    }

    // Update is called once per frame
    void Update()
    {
           if (GetComponent<Transform>().position.x > (posicionInicialBala + rango_bala))
            {
                Debug.Log("Destruir bala");
                Destroy(this.gameObject);

            }
        

    }
    
    
    

    public void disparar(GameObject objjj)
    {
        objetivo = objjj;
        GetComponent<Rigidbody2D>().velocity = (transform.TransformDirection(objetivo.transform.position - this.transform.position)) * velocidadbala;

    }







}
