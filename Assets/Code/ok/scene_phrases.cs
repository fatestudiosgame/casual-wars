using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_phrases : MonoBehaviour
{
    public GameObject barradecarga;
    public TextMeshProUGUI texto_nombre;
    public TextMeshProUGUI texto_explicar;
    public List<Sprite> listadofotos;
    public SpriteRenderer fotico;

    public GameObject foto_animation01,foto_animation02;

    float tiempoInicial,tiempoFinal;

    public GameObject boton_siguiente;


    List<string> historianombres, historiatextos;
    int numeroAleatorio;
    
    string escena_siguiente;


    void Start()
    {

        Time.timeScale = 1;
        guardarnombres();
        guardartextos();
        tiempoInicial = 0;
        tiempoFinal = 3;
        numeroAleatorio = Random.Range(1, 11);
        texto_nombre.text = historianombres[numeroAleatorio-1];
        texto_explicar.text = historiatextos[numeroAleatorio-1];
        foto_animation01.GetComponent<Animator>().SetFloat("Blend",numeroAleatorio-1);
        foto_animation01.GetComponent<Animator>().Play("frases_tree");
        foto_animation02.GetComponent<Animator>().SetFloat("Blend",numeroAleatorio-1);
        foto_animation02.GetComponent<Animator>().Play("frases_tree");
        escena_siguiente=PlayerPrefs.GetString("nombre_escena", "MainMenuScene");   
        boton_siguiente.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        boton_siguiente.GetComponent<EventTrigger>().enabled = true;

    }
    //EE009E

    
         
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = level_loader.level_loader_instance.load_scene_async(escena_siguiente);
        while (operation.isDone==false)
        {
            
            float progreso = Mathf.Clamp01(operation.progress / .9f);
            barradecarga.GetComponent<Slider>().value = progreso;
            Debug.Log(progreso * 100f + "%");
            yield return null;
        }
        
    }



    
    public void siguiente_escena()
    {
        StartCoroutine(LoadAsynchronously()); ;
    }








    void guardarnombres()
    {

        historianombres = new List<string>();

        historianombres.Add("Soldados R");
        historianombres.Add("Hadas Blancas");
      //  historianombres.Add("Ingenieros");
        historianombres.Add("Warlords");
        historianombres.Add("Transporte Terrestre");
        historianombres.Add("Transporte Aereo");
        historianombres.Add("Platillos");
        historianombres.Add("Tanques");
        historianombres.Add("Apoyo Aereo");
        historianombres.Add("Servicios Públicos");
        historianombres.Add("Servicios Públicos");
    }




    void guardartextos()
    {

        historiatextos = new List<string>();
        //soldados r 
        historiatextos.Add(
            "Cuando empezó la invasión, los valientes <#FF6B6B>Soldados R</color> marcaron una diferencia." +
            "Estos fieles guerreros no dudarán en dar su vida por la victoria.");
        //medicos
        historiatextos.Add("Los muertos fueron millones. " +
            "Sin las <#FF6B6B>Hadas Blancas</color> nunca hubiésemos sobrevivido. " +
            "Al principio el nombre era un chiste interno. Después, basta decir que se lo ganaron...");
     /*   //ingenieros
        historiatextos.Add("Los muertos fueron millones. " +
            "Sin las hadas blancas nunca hubiésemos sobrevivido. " +
            "Al principio el nombre era un chiste interno. Después, basta decir que se lo ganaron...");
    */   
        //warlords
        historiatextos.Add("Expertos en batallas. Algunos les llaman  <#FF6B6B>courier</color> a estos hombres, referenciado a un viejo videojuego." +
            " Si te cruzas con ellos en el campo de batalla podrás recargar tus municiones.");
        //transporte01
        historiatextos.Add("Para viajar entre los frentes puedes utilizar diferentes <#FF6B6B>medios de transporte</color>. Con un coche de estos puedes moverte rápidamente entre las bases.");
        //transporte02
        historiatextos.Add("Para viajar entre los frentes puedes utilizar diferentes <#FF6B6B>medios de transporte</color>. Los helicópteros sirven para desplazarse en las zonas de combate.");
        //enemigo01 platillo
        historiatextos.Add("Fueron los primeros en <#FF6B6B>desatar el caos</color>. Su velocidad no puede ser superada por los hombres.");
        //enemigo02 tanque
        historiatextos.Add("Temibles. Se necesita toda una <#FF6B6B>horda de hombres</color> para acabar con uno solo de estos enemigos.");
        //aviones tanque
        historiatextos.Add("A cada rato recibirás <#FF6B6B>apoyo aereo</color>. Cada gota, cada recurso será destinado a esta batalla. Los aviones vendrán de diferentes partes a brindar apoyo. Una bala puede salvar tu vida.");
        //servicios publicos cocinero
        historiatextos.Add("Los servicios públicos como la <#FF6B6B>comida</color> cuestan solo 3 monedas. Si comes te curarás rápidamente.");
        //servicios publicos vendedor de armas
        historiatextos.Add("Los servicios públicos como la  <#FF6B6B>armas</color> cuestan solo 3 monedas. Cada paquete trae 30 balas. Siempre ten ahorrado un poco de dinero.");

    }




     





}
