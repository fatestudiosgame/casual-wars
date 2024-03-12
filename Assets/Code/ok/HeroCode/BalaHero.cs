using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaHero : MonoBehaviour
{
    public int velocidadbala;
    public float posicionInicialBala;
    float rango_bala;
    bool derecha;
    
   

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = transform.right * velocidadbala;
        posicionInicialBala = GetComponent<Transform>().position.x;
        derecha = true;
        rango_bala = 20;
        if(GameObject.Find("hero"))
        {
            derecha = core_hero.core_hero_instance.MirandoRight();
        }
        
        if(GameObject.Find("hero_tutorial"))
        {
            derecha = GameObject.Find("hero_tutorial").GetComponent<HeroTutorial>().MirandoRight();
        }
     
                 
            if (derecha==true)
            {
               
                GetComponent<Rigidbody2D>().velocity = transform.right * velocidadbala;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = transform.right * -velocidadbala;
            }

    }

    

    // Update is called once per frame
    void Update()
    {

        if (derecha == true)
        {
            if (GetComponent<Transform>().position.x > (posicionInicialBala + rango_bala))
            {
                Destroy(this.gameObject);

            }
        }

        else
        {
            if (GetComponent<Transform>().position.x < (posicionInicialBala - rango_bala))
            {
                Debug.Log("Destruir bala");
                Destroy(this.gameObject);

            }

        }

    }
}
