using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneMenuPrincipal : MonoBehaviour
{
   
    
    public TextMeshProUGUI score_historico_tmp,historia_tmp;
    public GameObject input_nombre_text;
    
    public GameObject continuar_btn;
    int nueva_partida_state;

     string nombre_heroe;


      private void  Awake() {
         
         nueva_partida_state=PlayerPrefs.GetInt("nueva_partida_state",1);
         if(nueva_partida_state!=1)   /// si no es una nueva partida 
         {
          input_nombre_text.SetActive(false);
          if( PlayerPrefs.GetString("nombre_heroe")=="anonymus")
          {
                 historia_tmp.text= "Esta es la historia de un héroe"+ "<#FF6B6B> anónimo</color>"+","+"\n" +"la historia del hombre que salvó a la humanidad.";
          }
          else
          {
                 nombre_heroe=PlayerPrefs.GetString("nombre_heroe", nombre_heroe); 
                 GameManager.gm_instance.nombre_heroe= PlayerPrefs.GetString("nombre_heroe", nombre_heroe);
                // historia.text= "Esta es la historia de "+ "<#FF6B6B>"+ nombre_heroe+"</color>"+","+"\n" +" el hombre que salvó a la humanidad.";
                  historia_tmp.text= "Esta es la historia de "+ "<#FF6B6B>"+ GameManager.gm_instance.nombre_heroe+"</color>"+","+"\n" +" el hombre que salvó a la humanidad.";
    
          }
         }

    }




    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameManager.gm_instance.cargarDatos(); 
        AudioManager.audio_manager_instance.play_music("holamundo01",1);
    }


    // Update is called once per frame
    void Update()
    {
        score_historico_tmp.text = GameManager.gm_instance.score_juego_maximo + " ";
    }

 
    
           void IntroducirNombreDelHeroe()
  {
       GameManager.gm_instance.nombre_heroe=input_nombre_text.GetComponent<TMP_InputField>().text;
       if(input_nombre_text.GetComponent<TMP_InputField>().text!="")
       {
       PlayerPrefs.SetString("nombre_heroe",  GameManager.gm_instance.nombre_heroe); 
       input_nombre_text.SetActive(false);
       historia_tmp.text= "Esta es la historia de "+ "<#FF6B6B>"+  GameManager.gm_instance.nombre_heroe+"</color>"+","+"\n" +" el hombre que salvó a la humanidad.";
       }
       else
       {
       GameManager.gm_instance.nombre_heroe="anonymus";    
       PlayerPrefs.SetString("nombre_heroe",  GameManager.gm_instance.nombre_heroe); 
       input_nombre_text.SetActive(false);
       historia_tmp.text= "Esta es la historia de un héroe"+ "<#FF6B6B> anónimo</color>"+","+"\n" +"la historia del hombre que salvó a la humanidad.";
       }

       PlayerPrefs.SetInt("nueva_partida_state",0);
       nueva_partida_state=0;
       
  }


     void IniciarPartida()
    {
        continuar_btn.GetComponent<EventTrigger>().enabled = false; 
        level_loader.level_loader_instance.load_scene("03_phase_select");
    }

  




    public void continuar_partida()
    {
      
       AudioManager.audio_manager_instance.play_one_shot("sonido_click",1); 
       if(nueva_partida_state==1)
       {
         IntroducirNombreDelHeroe();
       }
       else
       {
         IniciarPartida();
       }

    }
    public void iratwitter()
    {
        AudioManager.audio_manager_instance.play_one_shot("sonido_click",1); 
        Application.OpenURL("https://twitter.com/fatestudiosgame");
    }
    public void irafacebook()
    {
       AudioManager.audio_manager_instance.play_one_shot("sonido_click",1); 
        Application.OpenURL("https://www.facebook.com/fatestudiosgame/");
    }
    public void irayoutube()
    {
        AudioManager.audio_manager_instance.play_one_shot("sonido_click",1); 
        Application.OpenURL("https://www.youtube.com/c/fatestudiosgame");
    }

    public void SalirPartida()
    {
        Debug.Log("salir");
        Application.Quit();   
    }

    public void Opciones()
    {
       AudioManager.audio_manager_instance.play_one_shot("para_texto",1); 
        level_loader.level_loader_instance.load_scene("06_lobby_scene");   
    }





   
   

  
   



}
