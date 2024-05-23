using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gm_instance;
    //int nueva_partida_state;
    


    public int score_juego_maximo;
    public int fase_actual, fase_juego_vencido;   
    public string nombre_heroe;
    
    int dinero_heroe;


    

    //elemementos de audio
    public AudioClip shot_sound,no_bullets_sound,helicopter_sound, car_sound, text_sound,click_sound,money_sound;

    public AudioClip holamundo01,holamundo03,musica_lm_01;

    public AudioSource audio_source_music, audio_source_sound_effect;

    public bool musica_fondo_on; //0.27f;


   void Awake()
   {
     if(gm_instance==null)
     {
        gm_instance=this;
     }
     else {Destroy(gameObject);}
     DontDestroyOnLoad(this);

   }


    void Start()
    {
        Application.targetFrameRate = 120; 
        //SceneManager.LoadScene("02_main_menu"); 
    }


      public void cargarDatos()
    {
        score_juego_maximo = PlayerPrefs.GetInt("score_juego_maximo", 0);
        fase_actual = PlayerPrefs.GetInt("fase_actual", 0);
        fase_juego_vencido = PlayerPrefs.GetInt("fase_juego_vencido", 0);
        nombre_heroe =  PlayerPrefs.GetString("nombre_heroe", "");  
    }

    
    
   public void  salvarDatos()
    {
         PlayerPrefs.SetInt("score_juego_maximo", score_juego_maximo);
         PlayerPrefs.SetInt("fase_actual", fase_actual);
         PlayerPrefs.SetInt("fase_juego_vencido", fase_juego_vencido);     
         PlayerPrefs.SetString("nombre_heroe",nombre_heroe);  
    }

 

   
   public void play_one_shot(string nombre_cancion, float volume)
   {
    audio_source_sound_effect.volume=volume; 
     switch(nombre_cancion)
     {
      case "sonido_carro":  audio_source_sound_effect.PlayOneShot(car_sound); break; 
      case "sonido_helicoptero":  audio_source_sound_effect.PlayOneShot(helicopter_sound); break; 
      case "disparo_hero":  audio_source_sound_effect.PlayOneShot(shot_sound); break; 
      case "sin_balas":  audio_source_sound_effect.PlayOneShot(no_bullets_sound); break; 
      case "para_texto":  audio_source_sound_effect.PlayOneShot(text_sound); break; 
      case "sonido_click":  audio_source_sound_effect.PlayOneShot(click_sound); break; 
      case "sonido_dinero":  audio_source_sound_effect.PlayOneShot(money_sound); break; 
     }
   }

  
   public void play_music(string nombre_cancion, float volume)
   {
    audio_source_sound_effect.volume=volume; 
     switch(nombre_cancion)
     {
      case "holamundo01":  audio_source_music.clip=holamundo01;  break; 
      case "holamundo03":  audio_source_music.clip=holamundo03; break; 
      case "musica_lm_01": audio_source_music.clip=musica_lm_01; break; 
     }
    audio_source_music.Play();
   }






}
