using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Tutorial : MonoBehaviour

{
    //elementos del enemigo
    Enemy mi_enemigo1;
    Slider barradecarga;
    Rigidbody2D my_rb_enemy;
    public float velocidadenemy;
    public GameObject mi_explosionenemy;
    BoxCollider2D cuerpo_enemy, rango_enemy;
    Animator my_animator_enemy;
    bool hay_contacto;
    public GameObject esqueleto_enemigo, mi_dinero;

    //elementos del ataque enemigo
    public GameObject mi_balaenemy;
    public Transform balaContenedorEnemigo;
    public float balaenemyrate, siguientebalaenemy;

    //float ataque_radio;
    float tiempoTranscurrido;
    bool avanzando_enemigo;
    public float vision_radio_enemigo;
    bool disparando_state_enemy;
    GameObject objetivo;
    GameObject mi_bala;

    //elementos de audio
     public AudioClip disparo_laser;

     




    void Start()
    {
        barradecarga = GetComponentInChildren<Slider>();
        
        tiempoTranscurrido = 0;
        mi_explosionenemy.SetActive(false);
        my_animator_enemy = esqueleto_enemigo.GetComponent<Animator>();
        my_rb_enemy = GetComponent<Rigidbody2D>();
        mi_enemigo1 = new Enemy(1, 10, 1, 10);
        BoxCollider2D[] mis_box = GetComponents<BoxCollider2D>();
        cuerpo_enemy = mis_box[0];
        rango_enemy = mis_box[1];
        if(this.gameObject.name== "enemy01(Clone)") { mi_enemigo1.setClassEnemy(1); }
        if(this.gameObject.name == "enemy02(Clone)") {
            mi_enemigo1.setClassEnemy(2);
            mi_enemigo1.setVidaMaxEnemy(15);
            mi_enemigo1.setVidaEnemy(15);
             }

        EnemigosAvanzando();


    }


    void Update()
    {
        barradecarga.value = mi_enemigo1.getVidaEnemy(); //mostrar la salud en pantalla

        if (mi_enemigo1.getVidaEnemy() == 0) // destruir si la vida llega a cero
        {
            mi_explosionenemy.SetActive(true);
            StartCoroutine(esperarTiempo());
        }
       
        if (avanzando_enemigo == true) //avanzar
        {
           my_rb_enemy.velocity = new Vector2(velocidadenemy, 0);
        }

        else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; }
            
      
        if (disparando_state_enemy == true) //disparar
        {
            disparoEnemy();
        }


       
            objetivo = GameObject.Find("hero_tutorial"); 
            avanzando_enemigo = true;
               
       
        Vector2 miposicion = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        float distancia = Vector2.Distance(objetivo.transform.position, this.transform.position);
        Vector2 foward = this.transform.TransformDirection(objetivo.transform.position - this.transform.position);
        Debug.DrawRay(transform.position, foward, Color.red);
        float linea = objetivo.transform.position.x - this.transform.position.x;   
            if (distancia > 3 && avanzando_enemigo == true) { 
                if(objetivo.transform.position.x> miposicion.x ) { my_rb_enemy.velocity = new Vector2(velocidadenemy, 0); }
                if (objetivo.transform.position.x < miposicion.x && my_rb_enemy.position.x > -3) { my_rb_enemy.velocity = new Vector2(velocidadenemy, 0); }
                               }

            else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; }
            
     

        if (distancia < vision_radio_enemigo)
        {
            Debug.DrawRay(transform.position, foward, Color.green);
            disparoEnemy();
        }
        




    }//update


   



    IEnumerator esperarTiempo()   //esperar tiempo para explotar
    {

        while (tiempoTranscurrido < 1)
        {
                       
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }

        //Instantiate(mi_dinero, this.transform.position, this.transform.rotation);
        Instantiate(mi_dinero,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1)
                , this.transform.rotation);
        GameObject.Find("codigo_tutorial").GetComponent<LogicaTutorial>().sumarScore(10); 
        tiempoTranscurrido = 0;
        Destroy(this.gameObject);

    }




        private void OnTriggerEnter2D(Collider2D collision)
      {
        if (collision.gameObject.name == "balaplayer(Clone)" && cuerpo_enemy.IsTouching(collision))
        {
            esqueleto_enemigo.GetComponentInChildren<SpriteRenderer>().color = new Color32(227, 67, 67, 255);
            mi_enemigo1.setVidaEnemy(mi_enemigo1.getVidaEnemy() - 1);
            
        }

        if (collision.gameObject.name == "balahero(Clone)" && cuerpo_enemy.IsTouching(collision))
        {
            esqueleto_enemigo.GetComponentInChildren<SpriteRenderer>().color = new Color32(227, 67, 67, 255);
            mi_enemigo1.setVidaEnemy(mi_enemigo1.getVidaEnemy() - 1);

        }





        if 
           ((collision.gameObject.name == "hero")||  //si colisiono con el heroe
           (collision.gameObject.name == "player01(Clone)")&& // o colisiono con un soldado
           (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_enemy)))//y el cuerpo enemigo esta siendo tocado por mi rango
            
        {
            objetivo = collision.gameObject;
            EnemigosStop();
            
        }



     


    }//ontriggerenter2d



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "balaplayer(Clone)" && !cuerpo_enemy.IsTouching(collision))
        {
            esqueleto_enemigo.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "balahero(Clone)" && !cuerpo_enemy.IsTouching(collision))
        {
            esqueleto_enemigo.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Destroy(collision.gameObject);
        }




        esqueleto_enemigo.GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

        ///
               
        if (((collision.gameObject.name == "hero") ||  //si colisiono con el heroe
           (collision.gameObject.name == "player01(Clone)"))&& 
                !rango_enemy.IsTouching(collision))
        {
            if (mi_enemigo1.getPisoEnemy() == 1) { objetivo = GameObject.Find("DefensaBase01"); }
            if (mi_enemigo1.getPisoEnemy() == 2) { objetivo = GameObject.Find("DefensaBase02"); }
            if (mi_enemigo1.getPisoEnemy() == 3) { objetivo = GameObject.Find("DefensaBase03"); }

            avanzando_enemigo = true;
        }
        
        //
       


    }//ontriggerexit2d



   






    public void disparoEnemy()
    {
        if (Time.time > siguientebalaenemy)
        {
            GetComponent<AudioSource>().PlayOneShot(disparo_laser);
            siguientebalaenemy = Time.time + balaenemyrate;
            mi_bala=Instantiate(mi_balaenemy, balaContenedorEnemigo.position, balaContenedorEnemigo.rotation);
            if(this.gameObject.name== "enemy_tutorial01(Clone)") { mi_bala.GetComponent<BalaEnemy>().setTipobala(1); }
            if (this.gameObject.name == "enemy_tutorial02(Clone)") { mi_bala.GetComponent<BalaEnemy>().setTipobala(2); }
            mi_bala.GetComponent<BalaEnemy>().disparar(objetivo);       
        }

    }

 

    public void EnemigosAvanzando()
    {
    avanzando_enemigo = true;
    }


    public void EnemigosStop()
    {
        avanzando_enemigo = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


    public void disparando(bool dddd)
    {
        disparando_state_enemy = dddd;
    }



    public void setTipoEnemy(int tt)
    {
        mi_enemigo1.setClassEnemy(tt);
    }

    public int  getTipoEnemy()
    {
        return mi_enemigo1.getClassEnemy();
    }



}
