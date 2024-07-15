using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public  class UiManager : MonoBehaviour
{
    public static UiManager ui_manager_instance;
    
    float tiempoenpantalla;
    bool textoenpantalla;   
    
    
    [SerializeField]
    public  TextMeshProUGUI score_tmp, dinero_tmp;
    
    public  GameObject cuadro_dialogo_hero; 
    public  TextMeshProUGUI dialogo_hero_tmp;

    
    //botones
    [SerializeField]
     GameObject musica_btn;

    
    private void Awake() {

      if(ui_manager_instance==null)
     {
        ui_manager_instance=this;
     }
     else {Destroy(gameObject);}

    }
      
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
              if (core_logica_juego_gun.game_over == false)  //mientras no sea game over sumar dinero y score
            {
                score_tmp.text = "Score: " + core_logica_juego_gun.score_jugador.ToString();
                dinero_tmp.text = core_logica_juego_gun.dinero_jugador.ToString();
                if (textoenpantalla == true) { limpiartextos(); }
            }
    }

     public void limpiartextos()
    {

        if (tiempoenpantalla > 3)
        {
            tiempoenpantalla = 0;
            dialogo_hero_tmp.text = "";
            cuadro_dialogo_hero.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            cuadro_dialogo_hero.SetActive(false);
            textoenpantalla = false;
        }
        tiempoenpantalla = tiempoenpantalla + Time.deltaTime;
    }


     public void musicaON()
    {
        if (AudioManager.audio_manager_instance.musica_fondo_on == true) { Debug.Log("Apagar Musica"); AudioManager.audio_manager_instance.musica_fondo_on  = false; AudioManager.audio_manager_instance.audio_source.Stop(); musica_btn.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 120); }
        else { Debug.Log("Encender Musica"); AudioManager.audio_manager_instance.musica_fondo_on = true;  AudioManager.audio_manager_instance.audio_source.Play(); musica_btn.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); }
    } 


     public void speak_hero(string text_to_speak)
    {
        cuadro_dialogo_hero.SetActive(true);
        cuadro_dialogo_hero.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        dialogo_hero_tmp.text = text_to_speak;
        textoenpantalla = true;
    }
}
