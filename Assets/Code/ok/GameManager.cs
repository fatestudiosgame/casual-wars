using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager gm_instance;
    //int nueva_partida_state;
    


    public int score_juego_maximo;
    public int fase_actual, fase_juego_vencido;   
    public string nombre_heroe;
    


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
<<<<<<< HEAD
=======
        //SceneManager.LoadScene("02_main_menu"); 
>>>>>>> f1b48554be4f3f5999f1f38a75f77b13911dc43a
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

 

   



}
