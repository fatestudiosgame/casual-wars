using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_select : MonoBehaviour
{
    public TextMeshProUGUI texto;

    public GameObject boton_siguiente;
    string nombre_objeto;
    public AudioClip  sonidoclick;

    public GameObject prologo_btn,fase01_btn,fase02_btn,fase03_btn,epilogo_btn;

    int fase_actual,fase_juego_vencido;
   
   
   // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1;
        GameManager.gm_instance.cargarDatos();
       
    }

  


    public void ir_al_nivel()
    {
     boton_siguiente.GetComponent<EventTrigger>().enabled = false;  
     GameManager.gm_instance.salvarDatos();  
     AudioManager.audio_manager_instance.play_music("musica_lm_01",1);      
     PlayerPrefs.SetString("nombre_escena", nombre_objeto);  
     level_loader.level_loader_instance.load_scene("04_phrases_scene");   
    }


    public void ir_al_menu()
    {
       level_loader.level_loader_instance.load_scene("02_main_menu");      
    }



    public void seleccionar_prologo(){ nombre_objeto = "fase00_prologo";  boton_siguiente.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            prologo_btn.LeanScale(new Vector3(1.2f,1.2f,1.2f),0.25f);
            fase01_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase02_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase03_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            epilogo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            boton_siguiente.GetComponent<EventTrigger>().enabled = true; 
            texto.text="Prólogo: El último laboratorio de los humanos está en peligro. Nuestra misión es defenderlo.";
            fase_actual=0;
            }
    public void seleccionar_fase01(){  nombre_objeto = "fase01_ultima_ofensiva";  boton_siguiente.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            prologo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase01_btn.LeanScale(new Vector3(1.2f,1.2f,1.2f),0.25f);
            fase02_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase03_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            epilogo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            boton_siguiente.GetComponent<EventTrigger>().enabled = true;
            texto.text="Fase 1: Las grandes ciudades de Europa están hechas un caos. Debemos ayudarlos.";
            fase_actual=1;
            }
    public void seleccionar_fase02(){  nombre_objeto = "fase02_sin_fronteras";  boton_siguiente.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            prologo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase01_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase02_btn.LeanScale(new Vector3(1.2f,1.2f,1.2f),0.25f);
            fase03_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            epilogo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            boton_siguiente.GetComponent<EventTrigger>().enabled = true; 
            texto.text="Fase 2: Han aparecido nuevos portales en América. Necesitan de nuestra ayuda.";
            fase_actual=2;
            }
    public void seleccionar_fase03(){  nombre_objeto = "fase03_esperanza";  boton_siguiente.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            prologo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase01_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase02_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase03_btn.LeanScale(new Vector3(1.2f,1.2f,1.2f),0.25f);
            epilogo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            boton_siguiente.GetComponent<EventTrigger>().enabled = true;
            texto.text="Fase 3: La resitencia ha descubierto la forma de cerrar los portales. Por primera vez hay esperanza después de tanto tiempo.";
            fase_actual=3;
            }
    public void seleccionar_epilogo(){ nombre_objeto = "fase00_prologo";  boton_siguiente.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            prologo_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase01_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase02_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            fase03_btn.LeanScale(new Vector3(1f,1f,1f),0.25f);
            epilogo_btn.LeanScale(new Vector3(1.2f,1.2f,1.2f),0.25f);
            boton_siguiente.GetComponent<EventTrigger>().enabled = true;
            texto.text="Epílogo: El costo de la victoria.";
            fase_actual=4;
            }
    
    
    

      
   
      

    
  



    

}
