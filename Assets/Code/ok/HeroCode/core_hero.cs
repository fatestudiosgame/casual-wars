using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class core_hero : MonoBehaviour
{

   public static core_hero core_hero_instance;

    //elementos del heroe
    Slider barradecarga;
    Player mi_hero;
    Rigidbody2D rb;
    BoxCollider2D box;
    Animator myAnimator;
    SpriteRenderer mySpriteRenderer;
    

    float mivelocidad; 
    public GameObject esqueleto, cabeza,cuerpo, pistola, pie_derecho, pie_izquierdo, disparofuego,mi_balahero,canvas_hero;
    public Sprite herodead_sprite;
   
    bool maniobra_state, mirandoderecha;
        

    //elementos de las balas que dispara el heroe
    public Transform balaContenedorHero;
    public float balaherorate, siguientebalahero;
    public int cantidad_balas;
    public TextMeshProUGUI cantidadbalastext;
    float tiempofuegobala;

    //elementos de la UI
    public Camera myCamera;
    public GameObject myVirtualCamera;
    public GameObject abajoBtn,medioBtn, arribaBtn;
    bool pause_state;

    //elementos de viaje entre niveles
    public GameObject  carro_viaje, helicoptero_viaje;
    public GameObject mi_carrito, mi_helicoptero,mi_carro01,mi_carro02,mi_helicoptero01,mi_helicoptero02;
    bool viajando;
    float tiempo_camara;
    int lugar_actual;

  

    //elementos de la jugabilidad
    bool zonasegura;
    bool estoy_en_carro, estoy_en_helicoptero;
    bool proveedor_armas;
    public GameObject seleccion_piso_grupo;
    public GameObject  emoticon_carro,emoticon_helicoptero;

    Vector3 vectorTemporal;
    int tipobalaenemy;

    float tiempoTranscurrido;
    public float tiempocurahero, siguientecurahero;   
    bool cura_bool;


   // float tiempoTranscurrido;
    public float tiemporecargahero, siguienterecargahero;
    bool recarga_bool;


    /// moverse android
   bool moviendose_derecha, moviendose_izquierda;


   public CameraShake cameraShake;
   private PlayerInput _playerInput;
   PlayerControl controles; 
    
   float position_final_camara, position_actual_camara;
   bool camara_cerca;

   public GameObject CodigoJuego;

   public GameObject apuntarBtn; 

   bool menu_movimiento_piso,menu_movimiento_tropas;
   int position_boton_lugar;
   
   bool espera_apuntando;


   bool boton_verde_state;
   bool mando_conectado;
   bool estado_invisible_heroe;

   bool tutorial_state;
     


    private void Awake() {

      if(core_hero_instance==null)
     {
        core_hero_instance=this;
     }
     else {Destroy(gameObject);}

     
      

          
      _playerInput = GetComponent<PlayerInput>();
      controles = new PlayerControl();
      controles.Gameplay.Enable();
       
      controles.Gameplay.BotonDisparo.performed += ctx => disp_btn_dwn();
      controles.Gameplay.BotonAccion.performed += ctx => accion_btn_dwn();
      controles.Gameplay.BotonIzquierda.performed += ctx => izquierda_btn_dwn();
      controles.Gameplay.BotonDerecha.performed += ctx => derecha_btn_dwn();
      controles.Gameplay.BotonVoltear.performed += ctx => voltear_btn_dwn();
      controles.Gameplay.BotonApuntar.performed += ctx => apuntar_btn_down();
      controles.Gameplay.BotonCancelar.performed += ctx => cancelar_btn_down();
      
     
           
         
      controles.Gameplay.BotonIzquierda.canceled += ctx => izquierda_btn_up(); 
      controles.Gameplay.BotonDerecha.canceled += ctx =>  derecha_btn_up();
      controles.Gameplay.BotonVoltear.canceled += ctx => voltear_btn_up();
      
      
    }
   

    
   

    // Start is called before the first frame update
    void Start()
    {

        if(SceneManager.GetActiveScene().name=="fase00_prologo"){tutorial_state=true;}
        else{tutorial_state=false;}
        
       
        mi_hero = new Player(3, 10, 0, 10);
        mivelocidad = 3;
        cantidad_balas = 45;
        cantidadbalastext.text = cantidad_balas.ToString();
       
        barradecarga = GetComponentInChildren<Slider>();        
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        myAnimator = esqueleto.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        

        
        seleccion_piso_grupo.SetActive(false);
        disparofuego.SetActive(false);
        tiempofuegobala=0;
        mirandoderecha = true;
      
       
        
    }


    // Update is called once per frame
    void Update()
    {
              
        barradecarga.value = mi_hero.getVidaPlayer();   //para mostrar la vida del heroe
       
        if (mi_hero.getVidaPlayer() > 0 && viajando == false) {TouchMove();}   //habilita el movimiento si el juego está en funcionamiento
        
        if (viajando == true) { setVelocityZero(); }  //inhabilita el movimiento del héroe si está moviéndose entre pisos

        if (mi_hero.getVidaPlayer() == 0)    // lo que sucede si el héroe muere
        {
            setVelocityZero();
            cabeza.GetComponent<SpriteRenderer>().sprite = herodead_sprite;
            core_logica_juego_gun.core_logica_juego_gun_instance.GameOver("Has muerto a manos de los aliens...");
        }


        if (Time.time > siguientecurahero && cura_bool == true)
        {
            siguientecurahero = Time.time + tiempocurahero;
            mi_hero.setVidaPlayer(mi_hero.getVidaPlayer() + 1);
        }

        if (Time.time > siguienterecargahero && recarga_bool == true)
        {

            siguienterecargahero = Time.time + tiemporecargahero;
            int cantidaddinero;
            cantidaddinero = core_logica_juego_gun.core_logica_juego_gun_instance.cantidadDinero();
            if (cantidaddinero > 0 && cantidad_balas!=45) {
                sumarBalas(7);
                core_logica_juego_gun.core_logica_juego_gun_instance.restarDinero(1);
            }

            
        }

        if (proveedor_armas == false) { recarga_bool = false; }



        if (disparofuego.activeSelf==true && tiempofuegobala > 0.5f)
            {
                tiempofuegobala = 0;
                disparofuego.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                disparofuego.SetActive(false);
            }
            tiempofuegobala = tiempofuegobala + Time.deltaTime;
        
 

    }//update






////////////////////INICIO DEL VIAJE DEL HEROE//////////////////////////


public void irArriba() { StartCoroutine(cargandoViajeHero(1)); }    
public void irMedio()  { StartCoroutine(cargandoViajeHero(2)); }         
public void irAbajo()  { StartCoroutine(cargandoViajeHero(3)); }
        
        
   

void seleccion_piso_finalizada()
{
           viajando = true;
        if (core_logica_juego_gun.core_logica_juego_gun_instance.carro_state ) {
            mi_carro01.SetActive(false);
            mi_carro02.SetActive(true);
        
             GameManager.gm_instance.play_one_shot("sonido_carro",1);
              }
        if (core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state == true) {
            mi_helicoptero01.SetActive(false);
            mi_helicoptero02.SetActive(true);
            GameManager.gm_instance.play_one_shot("sonido_helicoptero",1);
            }
            seleccion_piso_grupo.SetActive(false);
            abajoBtn.GetComponent<EventTrigger>().enabled = false;
            medioBtn.GetComponent<EventTrigger>().enabled = false;
            arribaBtn.GetComponent<EventTrigger>().enabled = false;
}



 IEnumerator cargandoViajeHero(int destino_de_viaje)
    {
        seleccion_piso_finalizada();  
        setHeroInvisible(true);
        
        estoy_en_carro = core_logica_juego_gun.core_logica_juego_gun_instance.carro_state ;
        estoy_en_helicoptero = core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state;
        
        lugar_actual = destino_de_viaje;
       
        while (tiempoTranscurrido < 2)
        {

            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
        
        tiempoTranscurrido = 0;
        core_logica_juego_gun.core_logica_juego_gun_instance.carro_state =estoy_en_carro;
        core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state =estoy_en_helicoptero;
       

        switch (lugar_actual)
        {
            case 1:
                if (core_logica_juego_gun.core_logica_juego_gun_instance.carro_state  == true)
                {
                    mi_hero.setPisoPlayer(1); GetComponent<Transform>().position = new Vector3(-14, 2.85f, 0);
                    mi_carrito.GetComponent<Transform>().position = new Vector3(-16, 2.95f, 0);
                    mi_helicoptero.GetComponent<Transform>().position = new Vector3(30, 3.75f, 0);
                }
                if (core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state  == true)
                {
                    mi_hero.setPisoPlayer(1); GetComponent<Transform>().position = new Vector3(32, 2.85f, 0);
                    mi_helicoptero.GetComponent<Transform>().position = new Vector3(30, 3.75f, 0);
                    mi_carrito.GetComponent<Transform>().position = new Vector3(-16, 2.95f, 0);
                }
                break;
            
            case 2:

                if (core_logica_juego_gun.core_logica_juego_gun_instance.carro_state  == true)
                {
                    mi_hero.setPisoPlayer(2); GetComponent<Transform>().position = new Vector3(-14, -0.95f, 0);
                    mi_carrito.GetComponent<Transform>().position = new Vector3(-16, -0.85f, 0);
                    mi_helicoptero.GetComponent<Transform>().position = new Vector3(30, 0.27f, 0);
                }
                if (core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state  == true)
                {
                    mi_hero.setPisoPlayer(2); GetComponent<Transform>().position = new Vector3(32, -0.95f, 0);
                    mi_helicoptero.GetComponent<Transform>().position = new Vector3(30, 0.27f, 0);
                    mi_carrito.GetComponent<Transform>().position = new Vector3(-16, -0.85f, 0);
                }
                break;

                case 3:
                if (core_logica_juego_gun.core_logica_juego_gun_instance.carro_state == true)
                {
                    mi_hero.setPisoPlayer(3); GetComponent<Transform>().position = new Vector3(-14, -4.75f, 0);
                    mi_carrito.GetComponent<Transform>().position = new Vector3(-16, -4.65f, 0);
                    mi_helicoptero.GetComponent<Transform>().position = new Vector3(30, -3.63f, 0);
                }
                if (core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state  == true)
                {
                    mi_hero.setPisoPlayer(3); GetComponent<Transform>().position = new Vector3(32, -4.75f, 0);
                    mi_helicoptero.GetComponent<Transform>().position = new Vector3(30, -3.63f, 0);
                    mi_carrito.GetComponent<Transform>().position = new Vector3(-16, -4.65f, 0);
                }
                break;
            
        }
    
      StartCoroutine(despuesViaje());
    }


    IEnumerator  despuesViaje() 
    {
      if(core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state ==true){mi_helicoptero02.GetComponent<Animator>().SetBool("aterrizar",true);}
      if(core_logica_juego_gun.core_logica_juego_gun_instance.carro_state ==true){mi_carro02.GetComponent<Animator>().SetBool("frenar",true);}  
      yield return new WaitForSeconds(2f);
      core_logica_juego_gun.core_logica_juego_gun_instance.carro_state =false;
      core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state=false;
      carro_viaje.SetActive(false); 
      helicoptero_viaje.SetActive(false); 
      menu_movimiento_piso=false;
      mi_helicoptero01.SetActive(true);
      mi_helicoptero02.SetActive(false);
      mi_carro01.SetActive(true);
      mi_carro02.SetActive(false);
      setHeroInvisible(false);
      viajando = false;
    }


////////////////////FIN DEL VIAJE DEL HEROE//////////////////////////




    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "balaenemy(Clone)" && estado_invisible_heroe==false)
        {

         
            int canttt = esqueleto.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {
             esqueleto.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(227, 67, 67, 255);
            }

            tipobalaenemy = collision.gameObject.GetComponent<BalaEnemy>().getTipobala();
            switch (tipobalaenemy)
            {
                case 1: Debug.Log("bala01ok"); StartCoroutine(cameraShake.Shake(0.25f,0.5f));  mi_hero.setVidaPlayer(mi_hero.getVidaPlayer() - 1);  break;
                case 2: Debug.Log("bala02ok"); StartCoroutine(cameraShake.Shake(0.25f,2f));  mi_hero.setVidaPlayer(mi_hero.getVidaPlayer() - 5);  break;
                case 3: Debug.Log("bala03ok"); StartCoroutine(cameraShake.Shake(0.25f,2f));  mi_hero.setVidaPlayer(mi_hero.getVidaPlayer() - 8);  break;
           
            }

           
            
        }

        if (collision.gameObject.name == "ZonaSegura")
        {

            zonasegura = true;
            abajoBtn.GetComponent<EventTrigger>().enabled = true;
            medioBtn.GetComponent<EventTrigger>().enabled = true;
            arribaBtn.GetComponent<EventTrigger>().enabled = true;
        }






        if (collision.gameObject.name == "player01(Clone)" &&
         collision.gameObject.GetComponent<PlayerLogic>().classPlayer() == 4 &&
         collision.GetComponents<BoxCollider2D>()[0].IsTouching(this.GetComponent<BoxCollider2D>())
         )
        {
            proveedor_armas = true;
        }


    }
    
   



    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "balaenemy(Clone)" && estado_invisible_heroe==false)
        {
            // mySpriteRenderer.color = new Color32(255, 255, 255, 255);
            int canttt = esqueleto.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {
            esqueleto.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(255, 255, 255, 255);
            }


            Destroy(collision.gameObject);
        }

        
        if (collision.gameObject.name == "ZonaSegura")
        {
            
            zonasegura = false;
            abajoBtn.GetComponent<EventTrigger>().enabled = false;
            medioBtn.GetComponent<EventTrigger>().enabled = false; 
            arribaBtn.GetComponent<EventTrigger>().enabled = false; 
        }

        

     


        if (collision.gameObject.name == "player01(Clone)" &&
         collision.gameObject.GetComponent<PlayerLogic>().classPlayer() == 4 )
        {
            if (!collision.GetComponents<BoxCollider2D>()[0].IsTouching(this.GetComponent<BoxCollider2D>()))
                 { proveedor_armas = false; }
        }




        mySpriteRenderer.color = new Color32(255, 255, 255, 255);
   


    }



    





    void disparoHero()
    {
            

        if (cabeza.GetComponent<SpriteRenderer>().flipX) { mirandoderecha = false; }
        else { mirandoderecha = true; }
        if (cantidad_balas > 0 && estado_invisible_heroe==false)
        {
            cantidad_balas = cantidad_balas - 1;
            if (cantidad_balas > 45) { cantidad_balas = 45; }
            if (cantidad_balas < 0) { cantidad_balas = 0; }
            cantidadbalastext.text = cantidad_balas.ToString();

            disparofuego.SetActive(true);
            disparofuego.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            GameManager.gm_instance.play_one_shot("disparo_hero",0.2f);
            siguientebalahero = Time.deltaTime + balaherorate;
            if (mirandoderecha == true)
            {
                Instantiate(mi_balahero, balaContenedorHero.position, balaContenedorHero.rotation);
            }
            else
            {
                Vector3 vectorTemporal = balaContenedorHero.position;
                vectorTemporal.x = balaContenedorHero.position.x - 1;
                Instantiate(mi_balahero, vectorTemporal, balaContenedorHero.rotation);
            }
        }
        else {
            if(estado_invisible_heroe==false)
            {
              GameManager.gm_instance.play_one_shot("sin_balas",0.5f);
            }
        }

    }


    



    public void curarHero()
    {  
        cura_bool = true;
        int canttt = GetComponentsInChildren<SpriteRenderer>().Length;
        for (int i = 0; i < canttt; i++)
        {GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(0, 255, 20, 255); }
    }

    public void curarterminoHero() {
        cura_bool = false;
        int canttt = GetComponentsInChildren<SpriteRenderer>().Length;
        for (int i = 0; i < canttt; i++)
        {
            GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(255, 255, 255, 255);
        }



    }



    public bool MirandoRight() { return mirandoderecha; }







    public void setVelocityZero() {
        rb.velocity = Vector2.zero;
        myAnimator.SetBool("WalkL", false);
        myAnimator.SetBool("Walk", false);
    }

    

 


    void TouchMove()
    {

        vectorTemporal.Set(this.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z);
        myCamera.transform.position = vectorTemporal;

        if (rb.position.x < -20 && moviendose_izquierda == true)
        {
            setVelocityZero();
        }

        if (rb.position.x > 48.7f && moviendose_derecha == true)
        {
            setVelocityZero();
        }
    }



    void moverCamaraI() {
        
        tiempo_camara = tiempo_camara + Time.deltaTime;
        if (tiempo_camara < 6.75f)
        {
            vectorTemporal.Set(this.transform.position.x - tiempo_camara, myCamera.transform.position.y, myCamera.transform.position.z);
            myCamera.transform.position = vectorTemporal;
        }
        else
        {
            vectorTemporal.Set(this.transform.position.x - 6.75f, myCamera.transform.position.y, myCamera.transform.position.z);
            myCamera.transform.position = vectorTemporal;
            tiempo_camara = 0;
        }
       
    }

    void moverCamaraD()
    {
        
        tiempo_camara = tiempo_camara + Time.deltaTime;
        if (tiempo_camara < 6.75f)
        {
            vectorTemporal.Set(this.transform.position.x + tiempo_camara, myCamera.transform.position.y, myCamera.transform.position.z);
            myCamera.transform.position = vectorTemporal;
        }
        else
        {
           vectorTemporal.Set(this.transform.position.x + 6.75f, myCamera.transform.position.y, myCamera.transform.position.z);
           myCamera.transform.position = vectorTemporal;
            tiempo_camara = 0;
        }

    }


  
    public void setHeroInvisible(bool state_invisible){
       if(state_invisible==true)
       {
        estado_invisible_heroe=state_invisible;
        canvas_hero.SetActive(false);
        cabeza.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 0);
        cuerpo.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 0);
        pistola.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 0);
        pie_derecho.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 0);
        pie_izquierdo.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 0);
        //box.isTrigger=false;
        ///voltear
       }
        else
        {
        estado_invisible_heroe=state_invisible;   
        canvas_hero.SetActive(true);
        cabeza.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 255);
        cuerpo.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 255);
        pistola.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 255);
        pie_derecho.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 255);
        pie_izquierdo.GetComponent<SpriteRenderer>().color= new Color32(255, 255, 255, 255);
        }
       }


   

   


    public void sumarBalas(int balasss)
    {
        GameManager.gm_instance.play_one_shot("sin_balas",0.5f);
        cantidad_balas = cantidad_balas + balasss;
        if (cantidad_balas > 45) { cantidad_balas = 45; }
        if (cantidad_balas < 0) { cantidad_balas = 0; }
        cantidadbalastext.text = cantidad_balas.ToString();
    }

    public int cantidadBalas()
    {
       return cantidad_balas;
    }




    ////////////////////////////Inicio controles con mando///////////////////////////

     
     void pasar_piso_izquierda()
     {
     position_boton_lugar=position_boton_lugar+1;
     if(position_boton_lugar>3){position_boton_lugar=1;}
     animacion_pasar_piso();
     }

      void pasar_piso_derecha()
     {
     position_boton_lugar=position_boton_lugar-1;
     if(position_boton_lugar<1){position_boton_lugar=3;}
     animacion_pasar_piso();
     }


void animacion_pasar_piso()
     {
          switch(position_boton_lugar)
     {
         case 1:  
         arribaBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         medioBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         abajoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         break;
        case 2:  
         abajoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         medioBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         arribaBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         break;
        case 3:  
         arribaBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         medioBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         abajoBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         break;
     }
     }

     
     void cancelar_btn_down()
     {
        menu_movimiento_piso=false;
        seleccion_piso_grupo.SetActive(false);
     }
      
   

      public  void derecha_btn_dwn()
    {
       if(tutorial_state==false){menu_movimiento_tropas=core_logica_juego_gun.core_logica_juego_gun_instance.hay_movimiento_de_tropas();}
       
       if(menu_movimiento_piso==true) {pasar_piso_derecha();  GameManager.gm_instance.play_one_shot("para_texto",1);}
       
       else if(menu_movimiento_tropas){core_logica_juego_gun.core_logica_juego_gun_instance.tropa_siguiente_btn(); GameManager.gm_instance.play_one_shot("para_texto",1);}
       
       else
       {
       
        if(mirandoderecha==true) {  myAnimator.SetBool("Walk", true); } 
        if(mirandoderecha==false) {  myAnimator.SetBool("WalkL", true); } 
        if (rb.position.x < 48.7f)
        {
            moviendose_derecha = true;
            rb.velocity = new Vector2(mivelocidad, 0);
        }
        else
        {
            setVelocityZero();
        }
       }
    }

    public void derecha_btn_up() {
      
      if(menu_movimiento_piso)
      {
       }
       else{
        myAnimator.SetBool("Walk", false);
        setVelocityZero();
        moviendose_derecha = false;
       }
        
    }
    


    public void izquierda_btn_dwn() {
        
        if(tutorial_state==false){menu_movimiento_tropas=core_logica_juego_gun.core_logica_juego_gun_instance.hay_movimiento_de_tropas();}

        if(menu_movimiento_piso==true) {pasar_piso_izquierda(); GameManager.gm_instance.play_one_shot("para_texto",1); }
            else if(menu_movimiento_tropas){ core_logica_juego_gun.core_logica_juego_gun_instance.tropa_anterior_btn(); GameManager.gm_instance.play_one_shot("para_texto",1);}

       else{
        
        if(mirandoderecha==true) {  myAnimator.SetBool("Walk", true); } 
        if(mirandoderecha==false) {  myAnimator.SetBool("WalkL", true); } 
          if (rb.position.x > -20)
        {
            moviendose_izquierda = true;
            rb.velocity = new Vector2(-mivelocidad, 0);
        }
        else
        {
            setVelocityZero();
        }
       }
    }

    public void izquierda_btn_up()
    {
        if(menu_movimiento_piso==true){}
        else{
        myAnimator.SetBool("Walk", false);
        setVelocityZero();
        moviendose_izquierda = false;
    }}


    public void disp_btn_dwn ()
    {
         
        if (Time.time > siguientebalahero)
        {
           
             if(tutorial_state==false){pause_state = core_logica_juego_gun.core_logica_juego_gun_instance.estadopausedejuego();}

            if (pause_state == false)
            {
                if (zonasegura == false) { disparoHero(); }
                else
                {
                    core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("NO PUEDO DISPARAR AQUI!!!");
                }
            }
        }
    }

    public void disp_btn_up() {}

 

    public void maniobra()
    {
        if (maniobra_state == false) { maniobra_state = true; }
        else { maniobra_state = false; }
        Debug.Log(maniobra_state);
    }


    public void voltear_btn_dwn()
    {
        if(mirandoderecha==true)
        {
           mirandoderecha=false;
           myAnimator.SetBool("Walk", false);  
           myAnimator.SetBool("WalkL", true);     
        }
        else
        {
           mirandoderecha=true;
           myAnimator.SetBool("WalkL", false);  
           myAnimator.SetBool("Walk", true);
        }

       
    }

    public void voltear_btn_up() 
    {
         if(rb.velocity==Vector2.zero){ myAnimator.SetBool("WalkL", false); myAnimator.SetBool("Walk", false); }     
    }
    
    










    public void apuntar_btn_down() 
    {
        if(myVirtualCamera.GetComponent<Animator>().GetBool("zoom_in"))
        { zoom_out();}
        else {zoom_in();}
        
    }

     
    

      IEnumerator tiempo_apuntar()
    { 
      apuntarBtn.GetComponent<Image>().material.EnableKeyword("GREYSCALE_ON");  
      apuntarBtn.GetComponent<EventTrigger>().enabled = false;
      yield return new WaitForSeconds(1f);
      apuntarBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON"); 
      apuntarBtn.GetComponent<EventTrigger>().enabled = true;
      espera_apuntando=false; 
    
    }


     public void apuntar_up() { }

    
     public void zoom_in()
     {
        myVirtualCamera.GetComponent<Animator>().SetBool("zoom_in",true);
        myVirtualCamera.GetComponent<Animator>().SetBool("zoom_out",false);
     }
     
       public void zoom_out()
     {
        myVirtualCamera.GetComponent<Animator>().SetBool("zoom_in",false);
        myVirtualCamera.GetComponent<Animator>().SetBool("zoom_out",true);
     }

     IEnumerator cambiar_camara_position()
     {
        position_final_camara=0;
        position_actual_camara=myCamera.transform.position.y;   
       
               switch(mi_hero.getPisoPlayer())
            {
            case 1:  position_final_camara= 2.35f;   break;
            case 2:  position_final_camara=-1.5f;   break;
            case 3:  position_final_camara=-3.85f;  break;
            }
         
              
        if(camara_cerca==true)
         {

          if(position_actual_camara==-3.85f)
          {
          while (myCamera.transform.position.y<-1.5f)
          {         
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,myCamera.transform.position.y + 0.15f,myCamera.transform.position.z);
          yield return new WaitForSeconds(0.005f); 
          }
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,-1.5f,myCamera.transform.position.z);
          }

          if(position_actual_camara==2.35f)
          {
             while (myCamera.transform.position.y>-1.5f)
          {   
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,myCamera.transform.position.y - 0.15f,myCamera.transform.position.z);
          yield return new WaitForSeconds(0.005f); 
          }
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,-1.5f,myCamera.transform.position.z);
          }  
          camara_cerca=false;
         }

         else
         {
         if(position_final_camara==-3.85f)
          {
          
           while (myCamera.transform.position.y>-3.85f)
          {         
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,myCamera.transform.position.y - 0.15f,myCamera.transform.position.z);
          yield return new WaitForSeconds(0.005f); 
          }
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,-3.85f,myCamera.transform.position.z);
          position_actual_camara=position_final_camara;
          camara_cerca=true;
          }


           if(position_final_camara==2.35f)
          {
             while (myCamera.transform.position.y<2.35f)
          {    
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,myCamera.transform.position.y + 0.15f,myCamera.transform.position.z);
          yield return new WaitForSeconds(0.005f); 
          }
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,2.35f,myCamera.transform.position.z);
          position_actual_camara=position_final_camara;
          camara_cerca=true;
          }

         }
            
         
               
     }

     IEnumerator cambiar_camara_size()
    {
        float posicion_camara_actual=myCamera.orthographicSize;
        if(posicion_camara_actual>5)
        {
            

           while (myCamera.orthographicSize>5)
        {
          myCamera.orthographicSize=myCamera.orthographicSize-0.25f;
          yield return new WaitForSeconds(0.01f); 
        }
        myCamera.orthographicSize=5f;
        }
        else
        {
          while (myCamera.orthographicSize<7)
        {
          myCamera.orthographicSize=myCamera.orthographicSize+0.25f;
          yield return new WaitForSeconds(0.01f); 
        }
        myCamera.orthographicSize=7f;
        }
       
    }





    
   public  void accion_btn_dwn() {mando_conectado=true; accion();}
   public  void accion_touch_dwn(){mando_conectado=false; accion();} 

    public void accion()
    {

         /// si estamos frente al carro o al helicoptero o al carro
          if (core_logica_juego_gun.core_logica_juego_gun_instance.carro_state  == true || core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state == true && proveedor_armas == false)   
            {
                emoticon_carro.SetActive(false);
                emoticon_helicoptero.SetActive(false);
                seleccion_piso_grupo.SetActive(true);
                abajoBtn.GetComponent<EventTrigger>().enabled = true;
                medioBtn.GetComponent<EventTrigger>().enabled = true;
                arribaBtn.GetComponent<EventTrigger>().enabled = true;
                  switch (mi_hero.getPisoPlayer())
            {
                 case 1:
                    arribaBtn.GetComponent<EventTrigger>().enabled = false;
                    abajoBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    medioBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    arribaBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 120);
                    break;
              
                case 2:
                    medioBtn.GetComponent<EventTrigger>().enabled = false;
                    abajoBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    medioBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 120);
                    arribaBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;

                case 3:
                    abajoBtn.GetComponent<EventTrigger>().enabled = false;
                    abajoBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 120);
                    medioBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    arribaBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    break;
               
            }  
        }


        //////////////INCIO ONLY MANDO///////////////
       if(mando_conectado==true)
       {
        menu_movimiento_tropas=core_logica_juego_gun.core_logica_juego_gun_instance.hay_movimiento_de_tropas();
        boton_verde_state=core_logica_juego_gun.core_logica_juego_gun_instance.hay_boton_verde_en_pantalla();
        
        ////sucede cuando esta en la pantalla de dialogo
        if(boton_verde_state==true) {core_logica_juego_gun.core_logica_juego_gun_instance.siguienteaccion();}
         
        ////sucede cuando se selecciona la tropa a comprar 
        else if(menu_movimiento_tropas){ core_logica_juego_gun.core_logica_juego_gun_instance.tropa_seleccionada_ok();}
         
        ////sucede cuando esta delante de un carro
        else if((core_logica_juego_gun.core_logica_juego_gun_instance.carro_state  == true || core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state == true) && menu_movimiento_piso==false) {
        myAnimator.SetBool("Walk", false);   setVelocityZero();   position_boton_lugar=mi_hero.getPisoPlayer();
        menu_movimiento_piso=true;
        switch(position_boton_lugar)
       {
         case 1:  arribaBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack(); break;
         case 2:  medioBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();  break;
         case 3:  abajoBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();  break;
       }
       }
       
        ////sucede cuando se selecciona el piso al que se quiere ir
        else if((core_logica_juego_gun.core_logica_juego_gun_instance.carro_state == true || core_logica_juego_gun.core_logica_juego_gun_instance.helicoptero_state == true) && menu_movimiento_piso==true)
        {
         if(position_boton_lugar!=mi_hero.getPisoPlayer())
         {
         menu_movimiento_piso=false;    
         switch (position_boton_lugar) {  case 1: irArriba(); break; case 2: irMedio(); break; case 3: irAbajo(); break; }
        }
        }
       
        }
        //////////////FIN ONLY MANDO///////////////

        

            

            /// si estamos frente al vendedor de armas
             if (core_logica_juego_gun.core_logica_juego_gun_instance.vendedor_armas_state == true)   
            {
                int cantidaddinero;
                cantidaddinero = core_logica_juego_gun.core_logica_juego_gun_instance.cantidadDinero();

                if (cantidaddinero < 3)
                {
                    core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("NO HAY RECURSOS!!!");
                }
                else
                {
                    if (cantidad_balas == 45)
                    {
                        core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("TENGO BALAS");
                    }
                    else
                    {
                        sumarBalas(20);
                       core_logica_juego_gun.core_logica_juego_gun_instance.restarDinero(3);
                    }
                }
            }


            
             /// si estamos frente al proveedor de armas
             if (proveedor_armas == true)
            {
                if (cantidad_balas == 45) {   core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("TENGO BALAS");}
                else {recarga_bool = true; }
            }


            /// si estamos frente al nero 
             if (core_logica_juego_gun.core_logica_juego_gun_instance.cocinero_state == true)
            {
                int cantidaddinero;
                cantidaddinero = core_logica_juego_gun.core_logica_juego_gun_instance.cantidadDinero();
                if (cantidaddinero < 3)
                {
                    core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("NO HAY RECURSOS");
                }
                else
                {
                    if (mi_hero.getVidaPlayer() == mi_hero.getVidaMaxPlayer())
                    {
                        core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("ESTOY BIEN");
                    }
                    else
                    {
                        mi_hero.setVidaPlayer(mi_hero.getVidaMaxPlayer());
                        core_logica_juego_gun.core_logica_juego_gun_instance.restarDinero(3);
                    }
                }
            }
        



        
    }




     
  




public int pisoHero() {return mi_hero.getPisoPlayer(); }

public int vidaHero() { return mi_hero.getVidaPlayer(); }

public int vidaHeroMax() { return mi_hero.getVidaMaxPlayer(); }

}
