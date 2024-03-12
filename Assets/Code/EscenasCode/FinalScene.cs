using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{

    int final_estado;
    bool fadeout_end;
    int conteo_blanco;
    public GameObject pantallablanca01, pantallablanca02, pantallablanca03;
    bool empezo;
    public AudioClip sonidoalien;
    public AudioClip sonidoend;

    // Start is called before the first frame update
    void Start()
    {
        conteo_blanco = 255;
        final_estado = 0;
    }

    // Update is called once per frame
    void Update()
    {

       

           
            switch (final_estado)
            {
            case 0:
                    fadeout(pantallablanca01);

                if (fadeout_end == true)
                    {
                    final_estado = 1;
                    fadeout_end = false;
                    conteo_blanco = 255;
                    }
                    break;

            case 1:
                if (Input.GetKeyDown(KeyCode.Space) && conteo_blanco==255)
                {
                    empezo = true;
                }

                if (empezo == true) { fadeout(pantallablanca02); }

                if (fadeout_end == true)
                {
                    empezo = false;
                    final_estado = 2;
                    fadeout_end = false;
                    conteo_blanco = 255;
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space) && conteo_blanco == 255)
                {
                    empezo = true;
                   GetComponent<AudioSource>().PlayOneShot(sonidoend); 
                   
                }
                if (empezo == true) { fadeout(pantallablanca03); }
                if (fadeout_end == true)
                {
                    final_estado = 4;
                    empezo = false;
                    fadeout_end = false;
                    conteo_blanco = 255;
                }
                break;
             case 3:
              //  if (empezo == false) { empezo = true; GetComponent<AudioSource>().PlayOneShot(sonidoend); }
              //  if (GetComponent<AudioSource>().isPlaying == false) { final_estado = 4; empezo = false; }

                break;
            case 4:

                SceneManager.LoadScene("MainMenuScene");

                break;


        }
    }


    public void fadeout( GameObject pantalla)
    {

            if (conteo_blanco<1)
            {

            fadeout_end = true;
            pantalla.SetActive(false);
                
            }

            if(fadeout_end==false)
            {
            pantalla.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)conteo_blanco);
            conteo_blanco = conteo_blanco - 1;
            }
        
    }







       public void escena_final()
       {
           
       }












        }
    

