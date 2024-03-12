using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class core_logica_juego_gun : MonoBehaviour
{
    
    public static core_logica_juego_gun core_logica_juego_gun_instance;

    //objetos de juego
    public GameObject mi_jugador, mi_enemigo1, mi_enemigo2, mi_enemigo3;
   

    //lugar donde se invocan soldados y enemigos
    public Transform lugardesoldados01,lugardesoldados02, lugardesoldados03,
    lugardeenemigos01, lugardeenemigos02, lugardeenemigos03;

    //elementos de la interfaz de usuario
    public GameObject paneldesenfoque, musicaBtn, pausaBtn;
    public Sprite play_sprite, pausa_sprite;
    



    public TextMeshProUGUI ScoreT, DineroT;
    public int dinero_jugador, score_points;
    bool game_over;
    public GameObject menu_over, cuadro_text_over;
    public TextMeshProUGUI Overtext, Overtextexplain;

    //audio
    public AudioClip sonidodinero, paratexto;
    
    

  

    //elemento de la base de los player
    public int vida_base_player_01,vida_base_player_02, vida_base_player_03;
    public Slider baseplayerslider01,baseplayerslider02, baseplayerslider03;
    int num_base_player;

    //elementos de la base de los enemy
    public int vida_base_enemy_01, vida_base_enemy_02, vida_base_enemy_03;
    public TextMeshProUGUI basetextenemy01, basetextenemy02, basetextenemy03;
    int num_base_enemy;


    //elementos de la tropas de los humanos
    int cant_tropas, tipo_tropa;
    float tiempomedicos, tiempowarlord, tiempomilitar;
    bool invocomedico, invocowarlord, invocomilitar;
    public GameObject medicoBtn, warlordBtn, militarBtn;
    public GameObject goBtn, stopBtn;
 
  
    //elementos del avión
    public GameObject avion;
    GameObject avion_instancia;
    public Transform lugardeavion01,lugardeavion02,lugardeavion03;
    public AudioClip sonidojet;


    //tiempos de espera
    public float tiempoinvocaravion, tiempoinvocarsoldados, tiempoinvocarenemigos;
    float tiempoenpantalla;
    bool textoenpantalla;    
  
    
    int aleatorio;
    public TextMeshProUGUI habla_hero;
    public GameObject cuadro_dialogo;

   

    //Principal del Juego
    
    public int evento_estado, evento_juego, nueva_partida_estado;
    public GameObject Personaje01, Personaje02, burbuja01, burbuja02;
    public TextMeshProUGUI textopersonaje01;
    public GameObject conversacion, siguiente;
    int valor_siguiente;
    List<string> conversacion01;

    //cinema

   
    public Transform lugardeparacaidas01;
    public GameObject paracaidas01;
    GameObject paracaidas_instancia;
    bool baseenmigadead01, baseenmigadead02, baseenmigadead03;
    int bas_enemigas_destruidas;

    bool win_state;
   
    public TextMeshProUGUI InfoBases;
    public GameObject rayos01,rayos02,rayos03;


   
     PlayerInput player_input;
     PlayerControl controles;
  

     
   bool menu_movimiento_tropas;
   int position_boton_tropas;

   bool boton_verde_state;
    
 

   public GameObject holograma_grupo;
   public TextMeshProUGUI holograma_tmp;



/////////////////////////
public bool carro_state, helicoptero_state;
public bool vendedor_armas_state,cocinero_state;

////////////////////////



    private void Awake() {
    
       if(core_logica_juego_gun_instance==null)
     {
        core_logica_juego_gun_instance=this;
     }
     else {Destroy(gameObject);}


      warlordBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON");
      militarBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON");
      medicoBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON");



      player_input = GetComponent<PlayerInput>();
      controles = new PlayerControl();
      controles.Gameplay.Enable();
      //controles.GameplayTropas.Enable();

      controles.Gameplay.BotonPausa.performed += ctx => pausa_btn_dwn();
      controles.Gameplay.BotonSeleccionarTropa.performed += ctx => seleccionar_tropa_btn_dwn();
      controles.Gameplay.BotonSeleccionarTropa.canceled += ctx => seleccionar_tropa_btn_up();            
      

     //controles.GameplayTropas.BotonSeleccionarTropa.performed += ctx => seleccionar_tropa_btn_dwn(); 
     //controles.GameplayTropas.BotonSeleccionarTropa.canceled += ctx => seleccionar_tropa_btn_up();    
  
     controles.GameplayTropas.BotonIzquierda.performed += ctx => tropa_anterior_btn();
     controles.GameplayTropas.BotonDerecha.performed += ctx => tropa_siguiente_btn();  


      

    }


    // Start is called before the first frame update
    void Start()
    {
        paneldesenfoque.SetActive(false);
        game_over = false;
        menu_over.SetActive(false);
        cuadro_text_over.SetActive(false);
        tipo_tropa = 0;
        tiempoinvocarenemigos = 0;
        tiempoinvocarsoldados = 0;
      
    

        Time.timeScale = 1;
        habla_hero.text = "";
        cuadro_dialogo.SetActive(false);
        GameManager.gm_instance.cargarDatos();
        conversacion.SetActive(false);
        Personaje01.SetActive(false);
        Personaje02.SetActive(false);
        burbuja01.SetActive(false);
        burbuja02.SetActive(false);
        siguiente.SetActive(false);
        textopersonaje01.text = "";
    

        evento_estado = 1;
        evento_juego = 1;
        valor_siguiente = 0;
        nueva_partida_estado = 1;
        
        win_state = false;
       

        tiempoinvocaravion=20f;
        tiempoinvocarsoldados=10f;
        tiempoinvocarenemigos=10f;


        if (evento_estado == 1)
        {
             abrir_telon();
        }

        EventosDelJuego();

        

         switch(SceneManager.GetActiveScene().name)
         {
            case"fase01_ultima_ofensiva": GameManager.gm_instance.fase_actual=1; break;
            case"fase02_sin_fronteras": GameManager.gm_instance.fase_actual=2; break;
            case"fase03_esperanza": GameManager.gm_instance.fase_actual=3; break;
         } 
      

         switch(GameManager.gm_instance.fase_actual)
        {
            case 1: 
          InfoBases.text=
         "París:"+ "100%" +"\n"
          +"Rusia:"+"100%" +"\n"
          +"Egipto:"+"100%";
            break;
            case 2:
          InfoBases.text=
         "México:" +"100%" +"\n"
          +"EE.UU:"+ "100%" +"\n"
          +"Brasil:"+ "100%";
            break;
            case 3:
        InfoBases.text=
         "Malecón:"+  "100%" +"\n"
          +"Capitolio:"+ "100%" +"\n"
          +"Tunel:"+ "100%";
            break;
        }

    }





    // Update is called once per frame
    void Update()
    {
         
       // if(evento_estado == 0)
       // {

                if (game_over == false)  //mientras no sea game over sumar dinero y score
            {
                ScoreT.text = "Score: " + score_points.ToString();
                DineroT.text = dinero_jugador.ToString();
                if (textoenpantalla == true) { limpiartextos(); }
            }

       //  }


    } //update




    
    IEnumerator tiempoesperamedico()
    {   
      tiempomedicos=2;  
      yield return new WaitForSeconds(tiempomedicos);
      invocomedico = false;
      medicoBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON");
      medicoBtn.GetComponent<EventTrigger>().enabled = true; 
    }
    

   


    IEnumerator tiempoesperawarlord()
    {
        tiempowarlord=2;  
        yield return new WaitForSeconds(tiempowarlord);
        invocowarlord = false;
        warlordBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON");
        warlordBtn.GetComponent<EventTrigger>().enabled = true;             
    }

    IEnumerator tiempoesperamilitar()
    {
        tiempomilitar=2;  
        yield return new WaitForSeconds(tiempomilitar);
        invocomilitar = false;
        militarBtn.GetComponent<Image>().material.DisableKeyword("GREYSCALE_ON");
        militarBtn.GetComponent<EventTrigger>().enabled = true;
    }





    public void limpiartextos()
    {

        if (tiempoenpantalla > 3)
        {
            tiempoenpantalla = 0;
            habla_hero.text = "";
            cuadro_dialogo.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            cuadro_dialogo.SetActive(false);
            textoenpantalla = false;
        }
        tiempoenpantalla = tiempoenpantalla + Time.deltaTime;
    }


    public IEnumerator invocarEnemigos()
    {
       // aleatorio = Random.Range(1, 7);
          aleatorio = Random.Range(1, 10);
     
           switch (aleatorio) {
            //////////fase01
            case 1: Instantiate(mi_enemigo1, lugardeenemigos01.position, lugardeenemigos01.rotation); break;
            case 2: Instantiate(mi_enemigo1, lugardeenemigos02.position, lugardeenemigos02.rotation); break;
            case 3: Instantiate(mi_enemigo1, lugardeenemigos03.position, lugardeenemigos03.rotation); break;
            case 4: Instantiate(mi_enemigo2, lugardeenemigos01.position, lugardeenemigos01.rotation); break;
            case 5: Instantiate(mi_enemigo2, lugardeenemigos02.position, lugardeenemigos02.rotation); break;
            case 6: Instantiate(mi_enemigo2, lugardeenemigos03.position, lugardeenemigos03.rotation); break;
            /////////fase02
            case 7: Instantiate(mi_enemigo3, lugardeenemigos01.position, lugardeenemigos01.rotation); break;
            case 8: Instantiate(mi_enemigo3, lugardeenemigos02.position, lugardeenemigos02.rotation); break;
            case 9: Instantiate(mi_enemigo3, lugardeenemigos03.position, lugardeenemigos03.rotation); break;

        } 
    
      yield return new WaitForSeconds(tiempoinvocarenemigos);
      StartCoroutine(invocarEnemigos());
    }



    public IEnumerator invocarSoldados()  
    {

      tipo_tropa = 1;
      aleatorio = Random.Range(1, 4);
      switch (aleatorio)
            {
                case 1: Instantiate(mi_jugador, lugardesoldados01.position, lugardesoldados01.rotation); break;
                case 2: Instantiate(mi_jugador, lugardesoldados02.position, lugardesoldados02.rotation); break;
                case 3: Instantiate(mi_jugador, lugardesoldados03.position, lugardesoldados03.rotation); break;
            }
     
      yield return new WaitForSeconds(tiempoinvocarsoldados);
      StartCoroutine(invocarSoldados());
    }

    public IEnumerator invocarAvion()
    {
        aleatorio = Random.Range(1, 4);
        switch (aleatorio)
        {
            case 1: avion_instancia = Instantiate(avion, lugardeavion01.position, lugardeavion01.rotation);  break;
            case 2: avion_instancia = Instantiate(avion, lugardeavion02.position, lugardeavion02.rotation);  break;
            case 3: avion_instancia = Instantiate(avion, lugardeavion03.position, lugardeavion03.rotation);  break;
        }
      GetComponent<AudioSource>().volume = 0.7f;
      GetComponent<AudioSource>().PlayOneShot(sonidojet);
      yield return new WaitForSeconds(tiempoinvocaravion);
      StartCoroutine(invocarAvion());
    }





    public void hablarHero(string ttt)
    {
        cuadro_dialogo.SetActive(true);
        cuadro_dialogo.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        habla_hero.text = ttt;
        textoenpantalla = true;
    }



 
    public void mod_vida_base_aliada (int vidabase)
    {
        num_base_player = vidabase;
        switch (num_base_player)
        {
            case 1: vida_base_player_01 = vida_base_player_01 - 1;
                if (vida_base_player_01 < 0) { vida_base_player_01 = 0; }
                baseplayerslider01.value = vida_base_player_01;
                break;
            case 2:
                vida_base_player_02 = vida_base_player_02 - 1;
                if (vida_base_player_02 < 0) { vida_base_player_02 = 0; }
               baseplayerslider02.value = vida_base_player_02;
                break;
            case 3:
                vida_base_player_03 = vida_base_player_03 - 1;
                if (vida_base_player_03 < 0) { vida_base_player_03 = 0; }
                baseplayerslider03.value = vida_base_player_03;
                break;
        }


        

        if (vida_base_player_01==40|| vida_base_player_02 == 40|| vida_base_player_03 == 40)
        {
            StartCoroutine(holograma_speak("Necesitamos refuerzos en la base!!"));
        }

        if (vida_base_player_01==20|| vida_base_player_02 == 20|| vida_base_player_03 == 20)
        {
            StartCoroutine(holograma_speak("La situación es crítica!!"));
        }


        if (vida_base_player_01==0|| vida_base_player_02 == 0|| vida_base_player_03 == 0)
        {
            GameOver("Los aliens conquistaron la base...");
        }

        switch(GameManager.gm_instance.fase_actual)
        {
            case 1: 
          InfoBases.text=
         "París:"+ vida_base_player_03+"%" +"\n"
          +"Rusia:"+vida_base_player_02+"%" +"\n"
          +"Egipto:"+vida_base_player_01+"%";
            break;
            case 2:
          InfoBases.text=
         "México:"+ vida_base_player_03+"%" +"\n"
          +"EE.UU:"+vida_base_player_02+"%" +"\n"
          +"Brasil:"+vida_base_player_01+"%";
            break;
            case 3:
        InfoBases.text=
         "Malecón:"+ vida_base_player_03+"%" +"\n"
          +"Capitolio:"+vida_base_player_02+"%" +"\n"
          +"Tunel:"+vida_base_player_01+"%";
            break;
        }

        
    }

    public void modificarVidaBaseEnemy(int vidabase)
    {
        num_base_enemy = vidabase;
        switch (num_base_enemy)
        {
            case 1:
                vida_base_enemy_01 = vida_base_enemy_01 - 1;
                if (vida_base_enemy_01 < 0) { vida_base_enemy_01 = 0; }
                basetextenemy01.text = "(" + vida_base_enemy_01 + "/100)"; break;
            case 2:
                vida_base_enemy_02 = vida_base_enemy_02 - 1;
                if (vida_base_enemy_02 < 0) { vida_base_enemy_02 = 0; }
                basetextenemy02.text = "(" + vida_base_enemy_02 + "/100)"; break;
            case 3:
                vida_base_enemy_03 = vida_base_enemy_03 - 1;
                if (vida_base_enemy_03 < 0) { vida_base_enemy_03 = 0; }
                basetextenemy03.text = "(" + vida_base_enemy_03 + "/100)"; break;
        }


        if (vida_base_enemy_01 == 0 && baseenmigadead01 == false) {
            baseenmigadead01 = true;
            rayos01.SetActive(true);
            bas_enemigas_destruidas++;
            destrucciondebases(bas_enemigas_destruidas);
        }
        if (vida_base_enemy_02 == 0 && baseenmigadead02 == false) {
            baseenmigadead02 = true;
            rayos02.SetActive(true);
            bas_enemigas_destruidas++;
            destrucciondebases(bas_enemigas_destruidas);
        }
        if (vida_base_enemy_03 == 0 && baseenmigadead03 == false) {
            baseenmigadead03 = true;
            rayos03.SetActive(true);
            bas_enemigas_destruidas++;
            destrucciondebases(bas_enemigas_destruidas);
        }

        if (vida_base_enemy_01 == 0 && vida_base_enemy_02 == 0 && vida_base_enemy_03 == 0)
        {
            WinOver();
        }

    }

    public void destrucciondebases(int cant_bases)
    {
        switch (cant_bases)
        {
            case 1:
                StartCoroutine(holograma_speak("Bien!!! Hemos debilitado un portal"));
                evento_juego = evento_juego + 1;
                //conversacion_destruccion_portal_01(); 
                //evento_estado = 1; evento_juego = evento_juego + 1;
                break;
            case 2: 
                StartCoroutine(holograma_speak("Solo queda un portal !!!"));
                evento_juego = evento_juego + 1;
                //evento_estado = 1; evento_juego = evento_juego + 1;
                break;

            case 3: Debug.Log("Lo hicimos!!!"); break;

        }
    }



    


         

    public void addmedicos()
    {
        if (game_over == false)
        {
            if (dinero_jugador >= 15)
            {
                GetComponent<AudioSource>().volume = 1;
                GetComponent<AudioSource>().PlayOneShot(paratexto);
                medicoBtn.GetComponent<Image>().material.EnableKeyword("GREYSCALE_ON");
                medicoBtn.GetComponent<EventTrigger>().enabled = false;
                invocomedico = true;
                hablarHero("UN MÉDICO!!!");
                dinero_jugador = dinero_jugador - 15;
                tipo_tropa = 2;
                switch (core_hero.core_hero_instance.pisoHero())
                {
                    case 1: Instantiate(mi_jugador, lugardesoldados01.position, lugardesoldados01.rotation); break;
                    case 2: Instantiate(mi_jugador, lugardesoldados02.position, lugardesoldados02.rotation); break;
                    case 3: Instantiate(mi_jugador, lugardesoldados03.position, lugardesoldados03.rotation); break;
                }

               StartCoroutine(tiempoesperamedico()); 
            }
            else
            {
                hablarHero("NO HAY RECURSOS!!!");
            }
        }

    }
   

    public void addwarlord()
    {
        if (game_over == false)
        {
            if (dinero_jugador >= 25)
            {
                GetComponent<AudioSource>().volume = 1;
                GetComponent<AudioSource>().PlayOneShot(paratexto);
                warlordBtn.GetComponent<Image>().material.EnableKeyword("GREYSCALE_ON");
                warlordBtn.GetComponent<EventTrigger>().enabled = false;
                invocowarlord = true;
                hablarHero("NECESITO MUNICIONES");
                dinero_jugador = dinero_jugador - 25;
                tipo_tropa = 4;
                switch (core_hero.core_hero_instance.pisoHero())
                {
                    case 1: Instantiate(mi_jugador, lugardesoldados01.position, lugardesoldados01.rotation); break;
                    case 2: Instantiate(mi_jugador, lugardesoldados02.position, lugardesoldados02.rotation); break;
                    case 3: Instantiate(mi_jugador, lugardesoldados03.position, lugardesoldados03.rotation); break;
                }

              StartCoroutine(tiempoesperawarlord());   
            }

            else
            {
                hablarHero("NO HAY RECURSOS!!!");
            }
        }
    }

    public void addmilitar()
    {
        
        if (game_over == false)
        {
            if (dinero_jugador >= 10)
            {
                GetComponent<AudioSource>().volume = 1;
                GetComponent<AudioSource>().PlayOneShot(paratexto);
                militarBtn.GetComponent<Image>().material.EnableKeyword("GREYSCALE_ON");
                militarBtn.GetComponent<EventTrigger>().enabled = false;
                invocomilitar = true;
                hablarHero("REFUERZOS!!!");
                dinero_jugador = dinero_jugador - 10;
                tipo_tropa = 5;
                switch (core_hero.core_hero_instance.pisoHero())
                {
                    case 1: Instantiate(mi_jugador, lugardesoldados01.position, lugardesoldados01.rotation); break;
                    case 2: Instantiate(mi_jugador, lugardesoldados02.position, lugardesoldados02.rotation); break;
                    case 3: Instantiate(mi_jugador, lugardesoldados03.position, lugardesoldados03.rotation); break;
                }
                StartCoroutine(tiempoesperamilitar());   
            }

            else
            {
                hablarHero("NO HAY RECURSOS!!!");
            }
       
        }
    }




    public int tipoDeTropa() { return tipo_tropa; }



    





    public void GameOver(string textoderrota)
    {
        if (win_state == false)
        {
            pausaBtn.SetActive(false);
            Time.timeScale = 0;
            paneldesenfoque.SetActive(true);
            cuadro_text_over.SetActive(true);
            menu_over.SetActive(true);
            Overtext.SetText("Game Over");
            Overtextexplain.SetText(textoderrota);
             GameManager.gm_instance.cargarDatos();
            if (GameManager.gm_instance.score_juego_maximo < score_points) { GameManager.gm_instance.score_juego_maximo = score_points;  GameManager.gm_instance.salvarDatos(); }
        }
    }

    public void WinOver()
    {
        Time.timeScale = 0;
        win_state = true;
        GameManager.gm_instance.cargarDatos();
        if (GameManager.gm_instance.score_juego_maximo < score_points) { GameManager.gm_instance.score_juego_maximo = score_points;}
              
        paneldesenfoque.SetActive(true);
        cuadro_text_over.SetActive(true);
        menu_over.SetActive(true);
        Overtext.SetText("You Win!!!");
        Overtextexplain.SetText("Hemos vencido");
       
        switch(GameManager.gm_instance.fase_actual)
        {   
            case 0: GameManager.gm_instance.fase_juego_vencido=2; break;
            case 1: GameManager.gm_instance.fase_juego_vencido=2; break;
            case 2: GameManager.gm_instance.fase_juego_vencido=3; break;
            case 3: GameManager.gm_instance.fase_juego_vencido=4; break;
            case 4: GameManager.gm_instance.fase_juego_vencido=5; break;
            case 5: GameManager.gm_instance.fase_juego_vencido=6; break;           
        }
       
        GameManager.gm_instance.salvarDatos();
        
    }

    public void pausa_btn_dwn()
    {
       
        if (menu_over.activeSelf == false) {
           
            GameManager.gm_instance.play_one_shot("para_texto",1); 
            Time.timeScale = 0;
            Overtext.SetText("");
            Overtextexplain.SetText("");
            cuadro_text_over.SetActive(false);
            paneldesenfoque.SetActive(true);
            militarBtn.GetComponent<EventTrigger>().enabled = false;
            medicoBtn.GetComponent<EventTrigger>().enabled = false;
            warlordBtn.GetComponent<EventTrigger>().enabled = false;
            pausaBtn.GetComponent<Image>().sprite = play_sprite;
        }
        else {
            GameManager.gm_instance.play_one_shot("para_texto",1); 
            Time.timeScale = 1;
            paneldesenfoque.SetActive(false);
            pausaBtn.GetComponent<Image>().sprite = pausa_sprite;
            militarBtn.GetComponent<EventTrigger>().enabled = true;
            medicoBtn.GetComponent<EventTrigger>().enabled = true;
            warlordBtn.GetComponent<EventTrigger>().enabled = true;
           
        }
        menu_over.SetActive(!menu_over.activeSelf);
    }



    void juegoTerminado() { ScoreT.text = "Juego Terminado"; }


    public bool EstadoJuego()
    {
        return game_over;

    }

    public bool EstadoPartida()
    {
        return menu_over.activeSelf;//si es true el juego esta en pause

    }


    public void ReiniciarPartida()
    {
        PlayerPrefs.SetString("nombre_escena", SceneManager.GetActiveScene().name);     
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().PlayOneShot(paratexto);
        Time.timeScale = 1;
        SceneManager.LoadScene("04_phrases_scene");
        Time.timeScale = 1;
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1; 
        GameManager.gm_instance.play_one_shot("para_texto",1); 
        level_loader.level_loader_instance.load_scene("02_main_menu"); 

    }

   





    void addparadacidas()
    {
        paracaidas_instancia = Instantiate(paracaidas01, lugardeparacaidas01.position, lugardeparacaidas01.rotation);

        if (paracaidas_instancia.transform.position.y < -4.75f)
        {
            evento_juego = evento_juego + 1;
        }

    }






   public void musicaON()
    {
        if (GameManager.gm_instance.musica_fondo_on == true) { Debug.Log("Apagar Musica"); GameManager.gm_instance.musica_fondo_on  = false; GameManager.gm_instance.audio_source_music.Stop(); musicaBtn.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 120); }
        else { Debug.Log("Encender Musica"); GameManager.gm_instance.musica_fondo_on = true;  GameManager.gm_instance.audio_source_music.Play(); musicaBtn.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); }
    }

   









    
    public void llenarconveracion01() ///conversacion de cuando inicia la partida
    {
        conversacion01 = new List<string>();
        conversacion01.Add("Llegamos a la base sin problemas señor");
        conversacion01.Add("Esta será la última batalla");
        conversacion01.Add("Los dispositivos y vehículos están listos.");
        conversacion01.Add("Bien. Nos hemos preparado para esto");
        conversacion01.Add("Las tropas están a su disposición");
        conversacion01.Add("La humanidad prevalecerá!!!");
    }

    public void llenarconveracion02() ///conversacion de cuando se debilita el primer portal
    {
        conversacion01 = new List<string>();
        conversacion01.Add("Hemos debilitado un portal");
        conversacion01.Add("Hay que debilitarlos a todos para poder cerrarlos");
    }

    public void llenarconveracion03()///conversacion de cuando se debilita el segundo portal
    {
        conversacion01 = new List<string>();
        conversacion01.Add("Solo queda uno señor");
        conversacion01.Add("Estamos muy cerca de lograrlo");
    }






    void EventosDelJuego()
    {
        switch (evento_juego)
        {
            case 2: 
                    evento_estado = 0;
                break;
            case 3:
                break;
            
            case 4:              
                evento_estado = 0;  
                break;
            
            case 5:   
                break;
                
            case 6:
                evento_estado = 0;
                break;
        }

    }





    void abrir_telon()
    {
        conversacion.SetActive(true); Personaje02.SetActive(true);
        burbuja02.SetActive(true);  siguiente.SetActive(true);
        llenarconveracion01();
        textopersonaje01.text = conversacion01[valor_siguiente];
        boton_verde_state=true;
    }

    
    public void siguienteaccion()  /// siguiente accion de la conversacion
    {
        GameManager.gm_instance.play_one_shot("para_texto",1); 
        valor_siguiente = valor_siguiente + 1;

       if (valor_siguiente == 1) { Personaje01.SetActive(true); }
 
       if (valor_siguiente % 2 == 0 && valor_siguiente < conversacion01.Count)
            {
          textopersonaje01.text = conversacion01[valor_siguiente];
          Personaje01.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
          Personaje02.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
          burbuja02.SetActive(true); burbuja01.SetActive(false);
             }
 else if (valor_siguiente % 2 != 0 && valor_siguiente < conversacion01.Count)
            
            {
          textopersonaje01.text = conversacion01[valor_siguiente];
          Personaje01.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
          Personaje02.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
          burbuja02.SetActive(false); burbuja01.SetActive(true);               
            }

 else   ///// termina la conversacion e inicia el juego
            {

         StartCoroutine(invocarEnemigos());
         StartCoroutine(invocarAvion());
         StartCoroutine(invocarSoldados());                     
         burbuja02.SetActive(false); burbuja01.SetActive(false);
         Debug.Log("Evento Inicio");
         conversacion.SetActive(false);
         valor_siguiente = 0;
         evento_juego = evento_juego + 1;
         Time.timeScale = 1;
         boton_verde_state = false; 

          }


    }	





 

    public int estadodeeventosdejuego()
    {
        return evento_estado;
    }

    public bool estadopausedejuego()
    {
        return menu_over.activeSelf;
    }


 






/////////funciones sencillas///////
   public void sumarScore(int ss)
    {
        score_points = score_points + ss;
        ScoreT.text = "Score: " + score_points.ToString();
    }

    public void sumarDinero(int dd)
    {
        GameManager.gm_instance.play_one_shot("sonido_dinero",0.5f); 
        dinero_jugador = dinero_jugador + dd;
        DineroT.text = dinero_jugador.ToString() + "$";
    }

    public void restarDinero(int dd)
    {
        GameManager.gm_instance.play_one_shot("sonido_dinero",0.5f); 
        dinero_jugador = dinero_jugador - dd;
        DineroT.text = dinero_jugador.ToString() + "$";
    }

    public int cantidadDinero()    {  return dinero_jugador; }


//////en pruebas

  ///////////////control por el mando INICIO ////////////
    public void seleccionar_tropa_btn_dwn()  {seleccionar_tropa_mando();}
    public void seleccionar_tropa_btn_up()  { deseleccionar_tropa_mando();}
    public void tropa_seleccionada_btn_down() {}
   
    public void add_militar_btn(){addmilitar();}
    public void add_medico_btn() {addmedicos();}
    public void add_warlord_btn(){addwarlord();}
   
   

     void seleccionar_tropa_mando()
     {
       menu_movimiento_tropas=true;
       position_boton_tropas=1;
       militarBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
       medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
       warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
     }
     
     void deseleccionar_tropa_mando()
     {
       menu_movimiento_tropas=false;
       position_boton_tropas=1;
       militarBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
       medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
       warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
     }
     
   public void tropa_seleccionada_ok()
    {
    switch(position_boton_tropas)
     {
        case 1:  addmilitar(); break;
        case 2:  addmedicos(); break;
        case 3:  addwarlord(); break; 
     }
     militarBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
     medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
     warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
     menu_movimiento_tropas=false;
     position_boton_tropas=1;
    
    }



    public void tropa_siguiente_btn() 
    {
     pasar_tropa_derecha();
    }
    public void tropa_anterior_btn() 
    {
    pasar_tropa_izquierda();
    }  
    
    public bool hay_movimiento_de_tropas(){return menu_movimiento_tropas;}
    public bool hay_boton_verde_en_pantalla(){return boton_verde_state;}




    void pasar_tropa_derecha()
    {
     position_boton_tropas=position_boton_tropas+1;
     if(position_boton_tropas>3){position_boton_tropas=1;}
     switch(position_boton_tropas)
     {
         case 1:  
         militarBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         break;
        case 2:  
         militarBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         medicoBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         break;
        case 3:  
         militarBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         warlordBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         break;
     }
    }
    void pasar_tropa_izquierda()
    {
     position_boton_tropas=position_boton_tropas-1;
     if(position_boton_tropas<1){position_boton_tropas=3;}
     switch(position_boton_tropas)
     {
         case 1:  
         militarBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         break;
        case 2:  
         militarBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         medicoBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         warlordBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         break;
        case 3:  
         militarBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         medicoBtn.LeanScale(Vector2.one,0.1f).setEaseInBack();
         warlordBtn.LeanScale(new Vector2(1.5f,1.5f),0.1f).setEaseInBack();
         break;
     }
    }



 ///////////////control por el mando FIN ////////////






     IEnumerator holograma_speak(string texto_a_mostrar)
    {
       holograma_grupo.SetActive(true);
       holograma_tmp.text=texto_a_mostrar;
       yield return new WaitForSeconds(4);
       holograma_grupo.SetActive(false);
    }




















}





