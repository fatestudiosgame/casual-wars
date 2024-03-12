using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionesScene : MonoBehaviour
{

    public Toggle toggle_musica, toggle_altas_prestaciones;
    int score_point_maximo;
    int refrescamiento;
    int altas_prestaciones;
    int musica_on;

     bool refrescamiento_state;

    GameObject musica_objeto;
    bool game_on;
    

    private void Awake() {
        game_on=false;
        cargarDatos();
        if(musica_on==1){toggle_musica.isOn=true;}
        else{toggle_musica.isOn=false;}
        if(altas_prestaciones==1){toggle_altas_prestaciones.isOn=true;}
        else{toggle_altas_prestaciones.isOn=false;}
        
    }

    // Start is called before the first frame update
    void Start()
    {      
        musica_objeto = GameObject.Find("GameManager");
        game_on=true; 
    }


    public void RefrescamientoJuego(bool refrescando)
    {
        refrescamiento_state = refrescando;
        if (refrescamiento_state == true) { refrescamiento = 1; }
        else { refrescamiento = 0; }
        Debug.Log(refrescamiento);
        salvarDatos();
    }

    

    void salvarDatos()
    {
        PlayerPrefs.SetInt("scorejuegomaximo", score_point_maximo);
        PlayerPrefs.SetInt("refrescarstate", refrescamiento);
        PlayerPrefs.SetInt("altas_prestaciones",altas_prestaciones);
        PlayerPrefs.SetInt("musica_on",musica_on);
    }

    void cargarDatos()
    {
        score_point_maximo = PlayerPrefs.GetInt("scorejuegomaximo", 0);
        refrescamiento = PlayerPrefs.GetInt("refrescarstate", 1);
        altas_prestaciones= PlayerPrefs.GetInt("altas_prestaciones", 1);
        musica_on= PlayerPrefs.GetInt("musica_on", 1);
    }

  

    
      public void on_toggle_musica()
    {
        if(game_on==true){
        if (musica_on==1) {  musica_on = 0; musica_objeto.GetComponent<AudioSource>().Stop();}
        else { musica_on = 1; musica_objeto.GetComponent<AudioSource>().Play();}
        Debug.Log("musica state:" +musica_on);
        salvarDatos();
        }
    }
    
    public void on_toggle_altas_prestaciones()
    {
        if(game_on==true){
        if(altas_prestaciones==1){altas_prestaciones=0;}
        else{altas_prestaciones=1;}
        Debug.Log("altas prestaciones:" +altas_prestaciones);
        salvarDatos();
        }
    }
    
    
     public void borrar_progreso()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("fase00_prologo");
    }

    public void ir_a_menu_principal()
    {
        SceneManager.LoadScene("MainMenuScene");
    }


    

}
