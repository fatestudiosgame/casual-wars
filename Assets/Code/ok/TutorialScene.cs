using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScene : MonoBehaviour
{

  
    public AudioClip sonidocarro;
    
    //historia
    GameObject fondo_en_movimiento;

    public GameObject adornos_presentacion, mi_fondo;
    public Transform lugardefondo01, lugardefondo00;
    List<string> historia_principio;
    public TextMeshProUGUI historiaprincipioTMP;

    public GameObject negro_arriba, negro_abajo;   
    int texto_actual;

   int nueva_partida_estado;
   


   AudioSource this_audio_source; 
   public AudioClip sonidodinero, paratexto;
   bool musica_on;
   GameObject musica_objeto;
  

   //elementos de la interfaz de usuario
    public GameObject paneldesenfoque, musicaBtn, pausaBtn;
    public Sprite play_sprite, pausa_sprite;
    public TextMeshProUGUI Overtext, Overtextexplain;
    public GameObject menu_over, cuadro_text_over;





     PlayerInput player_input;
     PlayerControl controles;




    // Start is called before the first frame update
    void Awake()
    {  
        Time.timeScale = 1;    
        fondo_en_movimiento=Instantiate(mi_fondo, lugardefondo00.position, lugardefondo00.rotation);    
        StartCoroutine(gestor_fondo());
        texto_actual=0;
        gestor_historia();
        GetComponent<AudioSource>().clip = sonidocarro;
        GetComponent<AudioSource>().Play();
       

       
      player_input = GetComponent<PlayerInput>();
      controles = new PlayerControl();
      controles.Gameplay.Enable();
      controles.Gameplay.BotonPausa.performed += ctx => pausa_btn_dwn();
      //controles.Gameplay.BotonSeleccionarTropa.performed += ctx => seleccionar_tropa_btn_dwn();
     // controles.Gameplay.BotonSeleccionarTropa.canceled += ctx => seleccionar_tropa_btn_up();            
     // controles.GameplayTropas.BotonIzquierda.performed += ctx => tropa_anterior_btn();
     // controles.GameplayTropas.BotonDerecha.performed += ctx => tropa_siguiente_btn();  
    }


    void Start() {
    this_audio_source=GetComponent<AudioSource>(); 
    musica_on = true;
    StartCoroutine(abrir_telon());
    musica_objeto = GameObject.Find("GameManager");
   }
  

    // Update is called once per frame
    void Update()
    {

    }



    void gestor_historia()
    {
        historia_principio = new List<string>();
        historia_principio.Add("Un día todo cambió...");
        historia_principio.Add("Todo se sumió en la desesperación cuando llegaron las primeras naves de los aliens.");
        historia_principio.Add("En pocas horas los más grandes ejércitos habían caído y millones murieron...");
        historia_principio.Add("Desde entonces, hemos perdido cada batalla a lo largo de los años...");
        historia_principio.Add("Pero esta vez será diferente, ahora ya sabemos cómo cerrar los portales...");
        historia_principio.Add("Esta vez... hay esperanzas...");
    }



     private IEnumerator  gestor_fondo()
    {
     fondo_en_movimiento=Instantiate(mi_fondo, lugardefondo01.position, lugardefondo00.rotation);     
     yield return new WaitForSeconds(5f);
     StartCoroutine(gestor_fondo());
    }

     public void siguiente_historia()
    {
        if(texto_actual==0){ adornos_presentacion .SetActive(false);}

        if(texto_actual==6){ StartCoroutine(cerrar_telon());}
        
        if(texto_actual<6){
        historiaprincipioTMP.text = historia_principio[texto_actual];
        texto_actual++;
        }
    }

    
    void salvarDatos()
    {
       PlayerPrefs.SetInt("nueva_partida",nueva_partida_estado);  
    }

    

    IEnumerator abrir_telon()
    {
        while (negro_arriba.transform.position.y < 14)
        {
            negro_arriba.transform.position = new Vector3(negro_arriba.transform.position.x, negro_arriba.transform.position.y + 0.1f, negro_arriba.transform.position.z);
            negro_abajo.transform.position = new Vector3(negro_arriba.transform.position.x, negro_abajo.transform.position.y - 0.1f, negro_arriba.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

 IEnumerator cerrar_telon()
   {
        while (negro_arriba.transform.position.y > 6)
        {
            negro_arriba.transform.position = new Vector3(negro_arriba.transform.position.x, negro_arriba.transform.position.y - 0.1f, negro_arriba.transform.position.z);
            negro_abajo.transform.position = new Vector3(negro_arriba.transform.position.x, negro_abajo.transform.position.y + 0.1f, negro_arriba.transform.position.z);
            yield return new WaitForSecondsRealtime(0.01f);
        }
      SceneManager.LoadScene("MainMenuScene");  // ir al nivel
   }










 public void pausa_btn_dwn()
    {
       
        if (menu_over.activeSelf == false) {
           
            this_audio_source.volume = 1;
            this_audio_source.PlayOneShot(paratexto);
            Time.timeScale = 0;
            Overtext.SetText("");
            Overtextexplain.SetText("");
            cuadro_text_over.SetActive(false);
            paneldesenfoque.SetActive(true);
            //militarBtn.GetComponent<EventTrigger>().enabled = false;
            //medicoBtn.GetComponent<EventTrigger>().enabled = false;
            //warlordBtn.GetComponent<EventTrigger>().enabled = false;
            pausaBtn.GetComponent<Image>().sprite = play_sprite;
        }
        else {
            this_audio_source.volume = 1;
            this_audio_source.PlayOneShot(paratexto);
            Time.timeScale = 1;
            paneldesenfoque.SetActive(false);
            pausaBtn.GetComponent<Image>().sprite = pausa_sprite;
            //militarBtn.GetComponent<EventTrigger>().enabled = true;
            //medicoBtn.GetComponent<EventTrigger>().enabled = true;
            //warlordBtn.GetComponent<EventTrigger>().enabled = true;
           
        }
        menu_over.SetActive(!menu_over.activeSelf);
    }




 public void ReiniciarPartida()
    {
        PlayerPrefs.SetString("nombre_escena", SceneManager.GetActiveScene().name);     
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().PlayOneShot(paratexto);
        Time.timeScale = 1;
        SceneManager.LoadScene("FrasesScene");
        Time.timeScale = 1;
    }

    public void MenuPrincipal()
    {
        this_audio_source.volume = 1;
        this_audio_source.PlayOneShot(paratexto);
        StartCoroutine(cerrar_telon());

    }

    
    
   public void musicaON()
    {
        if (musica_on == true) { Debug.Log("Apagar Musica"); musica_on = false; musica_objeto.GetComponent<AudioSource>().Stop(); musicaBtn.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 120); }
        else { Debug.Log("Encender Musica"); musica_on = true; musica_objeto.GetComponent<AudioSource>().Play(); musicaBtn.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 255); }
    }

   







}




