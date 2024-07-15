using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
       public static AudioManager audio_manager_instance;

     
     
       //elemementos de audio
    public AudioClip text_sound,click_sound;

    public AudioClip holamundo01,holamundo03,musica_lm_01;

    public AudioSource audio_source;

    public bool musica_fondo_on; //0.27f;

    

    
    
      private void Awake() {

      if(audio_manager_instance==null)
     {
        audio_manager_instance=this;
     }
     else {Destroy(gameObject);}

     
    }

    // Start is called before the first frame update
    void Start()
    {
        audio_source=GetComponent<AudioSource>();
    }

     

     public void play_one_shot(string nombre_cancion, float volume)
   {
    audio_source.volume=volume; 
     switch(nombre_cancion)
     {
      case "para_texto":  audio_source.PlayOneShot(text_sound); break; 
      case "sonido_click":  audio_source.PlayOneShot(click_sound); break; 
     }
   }

  
   public void play_music(string nombre_cancion, float volume)
   {
    audio_source.volume=volume; 
     switch(nombre_cancion)
     {
      case "holamundo01":  audio_source.clip=holamundo01;  break; 
      case "holamundo03":  audio_source.clip=holamundo03; break; 
      case "musica_lm_01": audio_source.clip=musica_lm_01; break; 
     }
    audio_source.Play();
   }



  

}
