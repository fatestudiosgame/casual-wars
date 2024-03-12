using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoriaInicial : MonoBehaviour
{
    public TextMeshProUGUI historia;
   // float tiempoInicial;
   // float tiempoFinal;
    List<string> historiaAleatoria;
    int contador;
    float tiempoescritura;
    char[] _oracion;
    string texto_mostrar;
    int numero_caracter;
  

    // Start is called before the first frame update
    void Start()
    {
        tiempoescritura = 0.05f;
       // tiempoInicial = 0;
       // tiempoFinal = 7;
        historiaAleatoria = new List<string>();
        llenarhistoria();
        contador = 0;
        _oracion = historiaAleatoria[contador].ToCharArray();

        ///
        historia.SetText("");
        texto_mostrar = "";
        numero_caracter = 0;
        _oracion = historiaAleatoria[contador].ToCharArray();
        StartCoroutine(Escribir());
        contador++;
        





    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Space)) {
           
            historia.SetText("");
            texto_mostrar = "";
            numero_caracter = 0;
            Debug.Log(contador);
            if (contador < 2) //numero de oraciones
            {
                _oracion = historiaAleatoria[contador].ToCharArray();
                StartCoroutine(Escribir());
                contador++;
            }
            else { SceneManager.LoadScene("Level01Scene"); }





        }


       

    }  //update


    IEnumerator Escribir()
    {

       

        while (numero_caracter < _oracion.Length)
        {
            texto_mostrar = texto_mostrar + _oracion[numero_caracter].ToString();
            historia.SetText(texto_mostrar);
            numero_caracter++;
            yield return new WaitForSeconds(tiempoescritura);
        }
        
    }



    void llenarhistoria()
    {

        historiaAleatoria.Add("Papá, puedes contarme la historia de la guerra, La Guerra de las Luces de Hierro... ");
        historiaAleatoria.Add("Pero esta vez me la cuentas desde el principio... "); 

    }


}
