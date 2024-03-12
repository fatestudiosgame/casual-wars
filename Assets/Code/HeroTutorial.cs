using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroTutorial : MonoBehaviour
{ 
    public Camera myCamera;
    public CameraShake cameraShake;
    public Transform balaContenedorHero;
    public Sprite herodead_sprite;
    public TextMeshProUGUI cantidadbalastext;
    public AudioClip disparo_hero, sinbalas, paratexto;
    Slider barradecarga;
    Player mi_hero;
    Rigidbody2D rb;
    Animator myAnimator;
    SpriteRenderer mySpriteRenderer;
    Vector3 vectorTemporal;

    public GameObject esqueleto, cabeza, disparofuego, mi_balahero;

    bool mirandoderecha,zonasegura,vendedor_armas,proveedor_armas,
    cura_bool, recarga_bool,moviendose_derecha, moviendose_izquierda,camara_cerca;
 
    float  mivelocidad, balaherorate, siguientebalahero,
    tiempofuegobala,limiteizquierdohero,   
    position_final_camara, position_actual_camara;
    int cantidad_balas,tipobalaenemy;
   

    // Start is called before the first frame update
    void Start()
    {
        mi_hero = new Player(2, 10, 0, 10);
        mivelocidad=3;
        cantidad_balas = 45;
        cantidadbalastext.text = cantidad_balas.ToString();
        
        barradecarga = GetComponentInChildren<Slider>();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = esqueleto.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        zonasegura = false;
        vendedor_armas = false;
        cura_bool = false;
        recarga_bool = false;     
        disparofuego.SetActive(false);
        tiempofuegobala=0;
        mirandoderecha = true;
        limiteizquierdohero = -97;
        moviendose_derecha = false;
        moviendose_izquierda = false;
    }


    // Update is called once per frame
    void Update()
    {
         if (mi_hero.getVidaPlayer() > 0) { TouchMove();}      
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

       
  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "balaenemy(Clone)")
        {
            int canttt = esqueleto.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {
                esqueleto.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(227, 67, 67, 255);
            }
  
             tipobalaenemy = collision.gameObject.GetComponent<BalaEnemy>().getTipobala();
            switch (tipobalaenemy)
            {
                case 1:  StartCoroutine(cameraShake.Shake(0.25f,0.5f));  mi_hero.setVidaPlayer(mi_hero.getVidaPlayer() - 1);  break;
                case 2:  StartCoroutine(cameraShake.Shake(0.25f,2f));  mi_hero.setVidaPlayer(mi_hero.getVidaPlayer() - 5);  break;
            }

              Debug.Log(tipobalaenemy);
            
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
        
        if (collision.gameObject.name == "balaenemy(Clone)")
        {
            int canttt = esqueleto.GetComponentsInChildren<SpriteRenderer>().Length;
            for (int i = 0; i < canttt; i++)
            {
             esqueleto.GetComponentsInChildren<SpriteRenderer>()[i].color = new Color32(255, 255, 255, 255);
            }
            Destroy(collision.gameObject);
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
        if (cantidad_balas > 0)
        {
            cantidad_balas = cantidad_balas - 1;
            if (cantidad_balas > 45) { cantidad_balas = 45; }
            if (cantidad_balas < 0) { cantidad_balas = 0; }
            cantidadbalastext.text = cantidad_balas.ToString();

            disparofuego.SetActive(true);
            disparofuego.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            GetComponent<AudioSource>().volume = 0.2f;
            GetComponent<AudioSource>().PlayOneShot(disparo_hero);
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
            GetComponent<AudioSource>().volume = 0.5f;
            GetComponent<AudioSource>().PlayOneShot(sinbalas); 
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



    public void boton_voltear_personaje_down()
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

    public void boton_voltear_personaje_up() 
    {
         if(rb.velocity==Vector2.zero){ myAnimator.SetBool("WalkL", false); myAnimator.SetBool("Walk", false); }     
    }
    



    public void setVelocityZero() {
        rb.velocity = Vector2.zero;
        myAnimator.SetBool("WalkL", false);
        myAnimator.SetBool("Walk", false);
    }

    

   public  void botonderechadown()
    {
        GetComponent<AudioSource>().PlayOneShot(paratexto);
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

    public void botonderechaup() {
        myAnimator.SetBool("Walk", false);
        setVelocityZero();
        moviendose_derecha = false;
    }
    


    public void botonizquierdadown() {

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

    public void botonizquierdaup()
    {
        myAnimator.SetBool("Walk", false);
        setVelocityZero();
        moviendose_izquierda = false;
    }


    public void botondisparodown()
    {
        if (Time.time > siguientebalahero)
        {

                      if (zonasegura == false) { disparoHero(); }

                else
                {

                    core_logica_juego_gun.core_logica_juego_gun_instance.hablarHero("NO PUEDO DISPARAR AQUI!!!");

                }
            

        }
    }

  

     

    public void voltear_btn_up() 
    {
         if(rb.velocity==Vector2.zero){ myAnimator.SetBool("WalkL", false); myAnimator.SetBool("Walk", false); }     
    }
    

    public void apuntar_down() 
    {
        StartCoroutine(cambiar_camara_size());
        StartCoroutine(cambiar_camara_position());
    }
     
     public void apuntar_up() { }

    
     IEnumerator cambiar_camara_position()
     {
        position_final_camara=0;
        position_actual_camara=myCamera.transform.position.y;   
       
               switch(mi_hero.getPisoPlayer())
            {
            case 1:  position_final_camara=-4f;     break;
            case 2:  position_final_camara=-1.5f;   break;
            case 3:  position_final_camara= 2.35f;  break;
            }
         
              
        if(camara_cerca==true)
         {

          if(position_actual_camara==-4f)
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
         if(position_final_camara==-4f)
          {
          
           while (myCamera.transform.position.y>-4f)
          {         
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,myCamera.transform.position.y - 0.15f,myCamera.transform.position.z);
          yield return new WaitForSeconds(0.005f); 
          }
          myCamera.transform.position= new Vector3(myCamera.transform.position.x,-4f,myCamera.transform.position.z);
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


   
    //////funciones sencillas
    
    public int vidaHero() { return mi_hero.getVidaPlayer(); }
    public int vidaHeroMax() { return mi_hero.getVidaMaxPlayer(); }  
    public int cantidadBalas() { return cantidad_balas; }


}
