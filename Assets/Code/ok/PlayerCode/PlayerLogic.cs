using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    Slider barradecarga;
    Player mi_player01;
    public Sprite constructor;
    public int velocidadplayer;
    SpriteRenderer clase_sprite;
    public GameObject esqueleto_player;
    int tipobalaenemy;
    bool avanzando_player;
    bool cura_bool;
    bool zonasegura;
    public AnimatorOverrideController medicoanimator;
    public AnimatorOverrideController warlordanimator;

    public AnimatorOverrideController militaranimator;

    //public AnimatorOverrideController costructoranimator;

    public GameObject mi_balaplayer;
    public Transform balaContenedorPlayer;
    public float balaplayerrate;
    public float siguientebalaplayer;
    public float siguientecura,tiempocura;
    Animator my_animator_player;
    Rigidbody2D my_rb_player;
    BoxCollider2D cuerpo_player;
    BoxCollider2D rango_player;
    public float vision_radio_player;
    GameObject objetivo;
    GameObject mi_bala;
    public GameObject bala_recarga;
    public AudioClip disparo_player;
    /// 
    Vector2 miposicion;
    float distancia;
    Vector2 foward;
    float linea;


    public GameObject cuadrodialogo;
    public TextMeshProUGUI textdialogo;
    bool textoplayerpantalla;
    float tiempotextoplayer;
    public GameObject emoticon_action;



    bool construir;
    public GameObject mi_trinchera;
    int cantidad_trincheras_piso1;
    int cantidad_trincheras_piso2;
    int cantidad_trincheras_piso3;
     GameObject trinchera_p101;
     GameObject trinchera_p102;
     GameObject trinchera_p103;
     GameObject trinchera_p201;
     GameObject trinchera_p202;
     GameObject trinchera_p203;
     GameObject trinchera_p301;
     GameObject trinchera_p302;
     GameObject trinchera_p303;


    // Start is called before the first frame update
    void Start()
    {

        barradecarga = GetComponentInChildren<Slider>();
        avanzando_player = true;
        my_animator_player = esqueleto_player.GetComponent<Animator>();
        my_animator_player.SetBool("walk", true);
        my_rb_player = GetComponent<Rigidbody2D>();
        BoxCollider2D[] mis_box = GetComponents<BoxCollider2D>();
        cuerpo_player = mis_box[0];
        rango_player = mis_box[1];


        textdialogo.text = "";
        cuadrodialogo.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        cuadrodialogo.SetActive(false);
        textoplayerpantalla = false;
        emoticon_action.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        emoticon_action.SetActive(false);

       
        
     
        if (this.transform.position.y == -4.80f) 
        { 
            objetivo = GameObject.Find("BaseEnemigaS01");
            mi_player01 = new Player(1, 7, 1, 7);
        }
        if (this.transform.position.y == -1) {
            objetivo = GameObject.Find("BaseEnemigaS02");
            mi_player01 = new Player(2, 7, 1, 7);
        }
        if (this.transform.position.y == 2.8f) {
            objetivo = GameObject.Find("BaseEnemigaS03");
            mi_player01 = new Player(3, 7, 1, 7);
        }






        switch (core_logica_juego_gun.core_logica_juego_gun_instance.tipoDeTropa())
        {
            case 1: mi_player01.setClassPlayer(1); break;
            case 2: mi_player01.setClassPlayer(2); break;
            case 3: mi_player01.setClassPlayer(3); break;
            case 4: mi_player01.setClassPlayer(4); break;
            case 5: mi_player01.setClassPlayer(5); break;       
        }

        






        if (mi_player01.getClassPlayer() == 1) {
         
        }//soldado


        if (mi_player01.getClassPlayer() == 2) {
            //medico
           my_animator_player.runtimeAnimatorController = medicoanimator as RuntimeAnimatorController;
                       objetivo = GameObject.Find("hero");
            

        }
        if (mi_player01.getClassPlayer() == 3) {//constructor

             construir = true;
             trinchera_p101 = GameObject.Find("p101"); 
             trinchera_p102 = GameObject.Find("p102"); 
             trinchera_p103 = GameObject.Find("p103"); 
             trinchera_p201 = GameObject.Find("p201"); 
             trinchera_p202 = GameObject.Find("p202"); 
             trinchera_p203 = GameObject.Find("p203"); 
             trinchera_p301 = GameObject.Find("p301"); 
             trinchera_p302 = GameObject.Find("p302"); 
             trinchera_p303 = GameObject.Find("p303"); 

            //my_animator_player.runtimeAnimatorController = costructoranimator as RuntimeAnimatorController;
        }

        if (mi_player01.getClassPlayer() == 4)
        {
            //warlord
           my_animator_player.runtimeAnimatorController = warlordanimator as RuntimeAnimatorController;
            
        }

        if (mi_player01.getClassPlayer() == 5)
        {
            //militar
          my_animator_player.runtimeAnimatorController = militaranimator as RuntimeAnimatorController;

        }



    }

    // Update is called once per frame
    void Update()
    {

        if (textoplayerpantalla == true) { limpiartextosplayer(); }

        barradecarga.value = mi_player01.getVidaPlayer();

        if (mi_player01.getVidaPlayer() == 0)
        {            // StartCoroutine(esperarTiempo());
            
            Instantiate(bala_recarga,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+1)
                , this.transform.rotation);
            Destroy(this.gameObject);
        }


        if (Time.deltaTime > siguientecura && cura_bool == true) // curarse por alguan accion
        {
            siguientecura = Time.deltaTime + tiempocura;
            mi_player01.setVidaPlayer(mi_player01.getVidaPlayer() + 1);

            int canttt = this.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {

                this.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(0, 255, 20, 255);

            }

        }
        



        miposicion = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        distancia = Vector2.Distance(objetivo.transform.position, this.transform.position);
        foward = this.transform.TransformDirection(objetivo.transform.position - this.transform.position);
        Debug.DrawRay(transform.position, foward, Color.red);
        linea = objetivo.transform.position.x - this.transform.position.x;

        switch (mi_player01.getClassPlayer()) {

                    
        
        case 1:

                if (objetivo == null) {
                    switch (mi_player01.getPisoPlayer())
                    {
                        case 1:  objetivo = GameObject.Find("BaseEnemigaS01"); break;
                        case 2:  objetivo = GameObject.Find("BaseEnemigaS02"); break;
                        case 3:  objetivo = GameObject.Find("BaseEnemigaS03"); break;
                    }

                    avanzando_player = true; 
                
                }
               
                if (distancia > 3 && avanzando_player == true)
                {
                    if (objetivo.transform.position.x > miposicion.x && my_rb_player.position.x < 47)
                    {
                        my_rb_player.velocity = new Vector2(velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                    if (objetivo.transform.position.x < miposicion.x && my_rb_player.position.x < 47)
                    {
                        my_rb_player.velocity = new Vector2(-velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                }

                else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; my_animator_player.SetBool("walk", false); }



                if (distancia < vision_radio_player && zonasegura == false)
                {
                    Debug.DrawRay(transform.position, foward, Color.green);
                    disparoPlayer();
                }

                if (my_rb_player.position.x > 48)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    my_animator_player.SetBool("walk", false);
                }


                break;  // end clase soldado

            case 2:
               

                    if (mi_player01.getPisoPlayer() == 1)
                    {
                        objetivo = GameObject.Find("posta_medica_egipto"); 
                    }
                    if (mi_player01.getPisoPlayer() == 2)
                    {
                        objetivo = GameObject.Find("posta_medica_rusia"); 
                    }
                    if (mi_player01.getPisoPlayer() == 3)
                    {
                    objetivo = GameObject.Find("posta_medica_paris"); 
                    }


                miposicion = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
                distancia = Vector2.Distance(objetivo.transform.position, this.transform.position);
                foward = this.transform.TransformDirection(objetivo.transform.position - this.transform.position);
                Debug.DrawRay(transform.position, foward, Color.red);
                linea = objetivo.transform.position.x - this.transform.position.x;
                if (distancia > 0 && avanzando_player == true)
                {
                    if (objetivo.transform.position.x > miposicion.x && my_rb_player.position.x < 29)
                    {
                        my_rb_player.velocity = new Vector2(velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                    if (objetivo.transform.position.x < miposicion.x && my_rb_player.position.x < 29)
                    {
                        my_rb_player.velocity = new Vector2(-velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                }

                else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; my_animator_player.SetBool("walk", false); }


               

                if (distancia < 2)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    my_animator_player.SetBool("walk", false);
                    Debug.DrawRay(transform.position, foward, Color.green);             
                
                }


                



                break; // end clase medico




            case 3:

                switch (mi_player01.getPisoPlayer())
                {
                    case 1:
                        if (cantidad_trincheras_piso1 == 0) { objetivo = GameObject.Find("p101"); }
                        else if (cantidad_trincheras_piso1 == 1) { objetivo = GameObject.Find("p102"); }
                        else { objetivo = GameObject.Find("p103"); }
                        break;
                    case 2:
                        if (cantidad_trincheras_piso1 == 0) { objetivo = GameObject.Find("p201"); }
                        else if (cantidad_trincheras_piso1 == 1) { objetivo = GameObject.Find("p202"); }
                        else { objetivo = GameObject.Find("p203"); }
                        break;
                    case 3:
                        if (cantidad_trincheras_piso1 == 0) { objetivo = GameObject.Find("p301"); }
                        else if (cantidad_trincheras_piso1 == 1) { objetivo = GameObject.Find("p302"); }
                        else { objetivo = GameObject.Find("p303"); }
                        break;
                }

               
                miposicion = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
                distancia = Vector2.Distance(objetivo.transform.position, this.transform.position);
                foward = this.transform.TransformDirection(objetivo.transform.position - this.transform.position);
                Debug.DrawRay(transform.position, foward, Color.red);
                linea = objetivo.transform.position.x - this.transform.position.x;
                if (distancia > 0 && avanzando_player == true)
                {
                    if (objetivo.transform.position.x > miposicion.x && my_rb_player.position.x < 29)
                    {
                        my_rb_player.velocity = new Vector2(velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                    if (objetivo.transform.position.x < miposicion.x && my_rb_player.position.x < 29)
                    {
                        my_rb_player.velocity = new Vector2(-velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                }

                else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; my_animator_player.SetBool("walk", false); }




                if (distancia < 1)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    my_animator_player.SetBool("walk", false);
                    Debug.DrawRay(transform.position, foward, Color.green);
                    if (construir == true)
                    {
                        Instantiate(mi_trinchera, objetivo.transform.position, objetivo.transform.rotation);
                        construir = false;
                    }
                        switch (mi_player01.getPisoPlayer())
                    {
                        case 1: cantidad_trincheras_piso1 = cantidad_trincheras_piso1 + 1; break;
                        case 2: cantidad_trincheras_piso2 = cantidad_trincheras_piso2 + 1; break;
                        case 3: cantidad_trincheras_piso3 = cantidad_trincheras_piso3 + 1; break;
                    }
                }



                break;// end clase constructor


            case 4:

                if (objetivo == null)
                {
                    switch (mi_player01.getPisoPlayer())
                    {
                        case 1: objetivo = GameObject.Find("BaseEnemigaS01"); break;
                        case 2: objetivo = GameObject.Find("BaseEnemigaS02"); break;
                        case 3: objetivo = GameObject.Find("BaseEnemigaS03"); break;
                    }
                    avanzando_player = true;
                }
                if (distancia > 3 && avanzando_player == true)
                {
                    if (objetivo.transform.position.x > miposicion.x && my_rb_player.position.x < 47)
                    {
                        my_rb_player.velocity = new Vector2(velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                    if (objetivo.transform.position.x < miposicion.x && my_rb_player.position.x < 47)
                    {
                        my_rb_player.velocity = new Vector2(-velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                }

                else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; my_animator_player.SetBool("walk", false); }



                if (distancia < vision_radio_player && zonasegura == false)
                {
                    Debug.DrawRay(transform.position, foward, Color.green);
                    disparoPlayer();
                }

                if (my_rb_player.position.x > 48)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    my_animator_player.SetBool("walk", false);
                }

                break;// end clase warlord


            case 5:

                if (objetivo == null)
                {
                    switch (mi_player01.getPisoPlayer())
                    {
                        case 1: objetivo = GameObject.Find("BaseEnemigaS01"); break;
                        case 2: objetivo = GameObject.Find("BaseEnemigaS02"); break;
                        case 3: objetivo = GameObject.Find("BaseEnemigaS03"); break;
                    }
                    avanzando_player = true;
                }


                miposicion = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
                distancia = Vector2.Distance(objetivo.transform.position, this.transform.position);
                foward = this.transform.TransformDirection(objetivo.transform.position - this.transform.position);
                Debug.DrawRay(transform.position, foward, Color.red);
                linea = objetivo.transform.position.x - this.transform.position.x;
                if (distancia > 0 && avanzando_player == true)
                {
                    if (objetivo.transform.position.x > miposicion.x && my_rb_player.position.x < 29)
                    {
                        my_rb_player.velocity = new Vector2(velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                    if (objetivo.transform.position.x < miposicion.x && my_rb_player.position.x < 29)
                    {
                        my_rb_player.velocity = new Vector2(-velocidadplayer, 0);
                        my_animator_player.SetBool("walk", true);
                    }
                }

                else { GetComponent<Rigidbody2D>().velocity = Vector2.zero; my_animator_player.SetBool("walk", false); }


                if (distancia < vision_radio_player && zonasegura == false)
                {
                    Debug.DrawRay(transform.position, foward, Color.green);
                    disparoPlayer();
                }

                if (my_rb_player.position.x > 48)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    my_animator_player.SetBool("walk", false);
                }


                break;// end clase militar
        }




                   
              



        






    } // update


    void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "balaenemy(Clone)" && cuerpo_player.IsTouching(collision))
            {


            int canttt = esqueleto_player.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {
             esqueleto_player.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(227, 67, 67, 255);
            }

            tipobalaenemy = collision.gameObject.GetComponent<BalaEnemy>().getTipobala();
            switch (tipobalaenemy)
            {
                case 1: mi_player01.setVidaPlayer(mi_player01.getVidaPlayer() - 1); break;
                case 2: mi_player01.setVidaPlayer(mi_player01.getVidaPlayer() - 5); break;
                case 3: mi_player01.setVidaPlayer(mi_player01.getVidaPlayer() - 8); break;
            }
            
            
        
            }


          

            else if (collision.gameObject.name == "ZonaSegura" && cuerpo_player.IsTouching(collision))
            {
            zonasegura = true;
            }

             else if

            ((collision.gameObject.name == "enemy01(Clone)")
            &&   // si colisiono con alguien llamado enemigo
              (mi_player01.getClassPlayer()==1) 
              &&
             (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();         
        }


        else if

      ((collision.gameObject.name == "enemy02(Clone)")
      &&   // si colisiono con alguien llamado enemigo
        (mi_player01.getClassPlayer() == 1)  &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }

       ///nuevo enemigo

        else if

      ((collision.gameObject.name == "enemy03(Clone)")
      &&   // si colisiono con alguien llamado enemigo
        (mi_player01.getClassPlayer() == 1)  &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }

        ////////////


        else if

    ((collision.gameObject.name == "enemy01(Clone)")
    &&   // si colisiono con alguien llamado enemigo
      (mi_player01.getClassPlayer() == 4)
      &&
     (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }


        else if

      ((collision.gameObject.name == "enemy02(Clone)")
      &&   // si colisiono con alguien llamado enemigo
        (mi_player01.getClassPlayer() == 4) &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }
       
          ///nuevo enemigo

        else if

      ((collision.gameObject.name == "enemy03(Clone)")
      &&   // si colisiono con alguien llamado enemigo
        (mi_player01.getClassPlayer() == 4)  &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }

        ////////////


        else if

            ((collision.gameObject.name == "enemy01(Clone)")
                &&   // si colisiono con alguien llamado enemigo
            (mi_player01.getClassPlayer() == 5)
            &&
                (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }


        else if

      ((collision.gameObject.name == "enemy02(Clone)")
      &&   // si colisiono con alguien llamado enemigo
        (mi_player01.getClassPlayer() == 5) &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }

        ///nuevo enemigo

        else if

      ((collision.gameObject.name == "enemy03(Clone)")
      &&   // si colisiono con alguien llamado enemigo
        (mi_player01.getClassPlayer() == 5)  &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(rango_player))) //&& // si el cuerpo del enemigo esta siendo tocado por mi rango
        {
            objetivo = collision.gameObject;
            DetenganseSoldados();
        }

        ////////////







        else if

      ((collision.gameObject.name == "hero") && 
      (mi_player01.getClassPlayer() == 2) &&
       (collision.GetComponents<BoxCollider2D>()[0].IsTouching(cuerpo_player))) 
        {
            DetenganseSoldados();
            collision.gameObject.GetComponent<core_hero>().curarHero(); 
        }


        else if

  ((collision.gameObject.name == "hero") &&
  (mi_player01.getClassPlayer() == 4) &&
   (collision.GetComponents<BoxCollider2D>()[0].IsTouching(cuerpo_player)))
        {
           DetenganseSoldados();
           emoticon_action.SetActive(true);
           hablarPlayer("¿Quieres munición?");
        }






    }//entertrigger

    









    void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.gameObject.name == "balaenemy(Clone)" && !cuerpo_player.IsTouching(collision))
            {
            
            int canttt = esqueleto_player.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {

                esqueleto_player.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(255, 255, 255, 255);

            }


            Destroy(collision.gameObject);
            }


           
                       

            else if (collision.gameObject.name == "ZonaSegura" && !cuerpo_player.IsTouching(collision))
            {

                zonasegura = false;

            }





        else if
        ((collision.gameObject.name == "enemy01(Clone)") ||
            (collision.gameObject.name == "enemy02(Clone)")||
            (collision.gameObject.name == "enemy03(Clone)") 
            &&
        (mi_player01.getClassPlayer() == 1) &&
                !rango_player.IsTouching(collision))
        {
            switch (mi_player01.getPisoPlayer())
            {
                case 1: objetivo = GameObject.Find("BaseEnemigaS01"); break;
                case 2: objetivo = GameObject.Find("BaseEnemigaS02"); break;
                case 3: objetivo = GameObject.Find("BaseEnemigaS03"); break;
            }
            avanzando_player = true;


        }


        else if
          
       ((collision.gameObject.name == "hero") &&
       (mi_player01.getClassPlayer() == 2) &&
       !cuerpo_player.IsTouching(collision))
        
        {
            collision.gameObject.GetComponent<core_hero>().curarterminoHero();
            AvancenSoldados();
        }



        else if

        ((collision.gameObject.name == "hero") &&
        (mi_player01.getClassPlayer() == 4) &&
        !cuerpo_player.IsTouching(collision))
        {
            emoticon_action.SetActive(false);
            AvancenSoldados();
        }


        else if
  ((collision.gameObject.name == "enemy01(Clone)") ||
      (collision.gameObject.name == "enemy02(Clone)")|| 
      (collision.gameObject.name == "enemy03(Clone)")&&
  (mi_player01.getClassPlayer() == 4) &&
          !rango_player.IsTouching(collision))
        {
            switch (mi_player01.getPisoPlayer())
            {
                case 1: objetivo = GameObject.Find("BaseEnemigaS01"); break;
                case 2: objetivo = GameObject.Find("BaseEnemigaS02"); break;
                case 3: objetivo = GameObject.Find("BaseEnemigaS03"); break;
            }
            avanzando_player = true;


        }
        else if
  ((collision.gameObject.name == "enemy01(Clone)") ||
      (collision.gameObject.name == "enemy02(Clone)")||
       (collision.gameObject.name == "enemy03(Clone)") &&
  (mi_player01.getClassPlayer() == 5) &&
          !rango_player.IsTouching(collision))
        {
            switch (mi_player01.getPisoPlayer())
            {
                case 1: objetivo = GameObject.Find("BaseEnemigaS01"); break;
                case 2: objetivo = GameObject.Find("BaseEnemigaS02"); break;
                case 3: objetivo = GameObject.Find("BaseEnemigaS03"); break;
            }
            avanzando_player = true;


        }


    }



        


    void disparoPlayer()
        {
        if (Time.time > siguientebalaplayer)
        {
            GetComponent<AudioSource>().PlayOneShot(disparo_player);
            siguientebalaplayer = Time.time + balaplayerrate;
            mi_bala=Instantiate(mi_balaplayer, balaContenedorPlayer.position, balaContenedorPlayer.rotation);
            mi_bala.GetComponent<BalaPlayer>().disparar(objetivo);
        }

        }



    //public void curarPlayer()  { cura_bool = true; }

    public void curarterminoPlayer()
    {
        cura_bool = false;
        int canttt = this.GetComponentsInChildren<SpriteRenderer>().Length;
        for (int i = 0; i < canttt; i++)
        {

            this.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(255, 255, 255, 255);

        }
    }


    public void AvancenSoldados()
        {
            Debug.Log("estuvo2");
            avanzando_player = true;
            my_animator_player.SetBool("walk", true);

        }

        public void DetenganseSoldados()
        {
            avanzando_player = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            my_animator_player.SetBool("walk", false);
        }



        public void hablarPlayer(string ttt)
         {

        cuadrodialogo.SetActive(true);
        cuadrodialogo.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        textdialogo.text = ttt;
        textoplayerpantalla = true;

        }

        public void limpiartextosplayer()
         {

        if (tiempotextoplayer > 2)
        {
            tiempotextoplayer = 0;
            textdialogo.text = "";
            cuadrodialogo.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            cuadrodialogo.SetActive(false);
            textoplayerpantalla = false;
        }
        tiempotextoplayer = tiempotextoplayer + Time.deltaTime;
        }



    public int pisoPlayer()  { return mi_player01.getPisoPlayer(); }

        public int classPlayer() { return mi_player01.getClassPlayer(); }

        public int vidaPlayer() { return mi_player01.getVidaPlayer(); }

         public int vidaMaxPlayer() { return mi_player01.getVidaMaxPlayer(); }



    public int cantidaddetrincheras01() { return cantidad_trincheras_piso1; }
    public int cantidaddetrincheras02() { return cantidad_trincheras_piso2; }
    public int cantidaddetrincheras03() { return cantidad_trincheras_piso3; }
}




