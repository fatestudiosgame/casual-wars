using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefrescarUIplay : MonoBehaviour
{

    public Sprite sprite_play00;
    public Sprite sprite_play01;
    public Sprite sprite_play02;

    public Sprite sprite_pause00;
    public Sprite sprite_pause01;
    public Sprite sprite_pause02;

    int conteo;
    float tiempo;
    public int refresco;
    bool refrescar_state;
    bool juegostate;

    // Start is called before the first frame update
    void Start()
    {
        conteo = 0;
        refresco = 5;
        refrescar_state = true;
        // if (PlayerPrefs.GetInt("refrescarstate", 1) == 1) { refrescar_state = true; }
        //  else { refrescar_state = false; }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //juegostate = GameObject.Find("codigo_juego").GetComponentInParent<LogicaJuegoGun>().EstadoPartida();
        if (tiempo > refresco && refrescar_state == true)
        {
            switch (Time.timeScale == 0)
            {
                case true:
                    tiempo = 0;
                    if (conteo == 0) { this.GetComponent<Image>().sprite = sprite_play01; conteo = 1; }
                    else if (conteo == 1) { this.GetComponent<Image>().sprite = sprite_play02; conteo = 0; }
                    break;
                case false:
                    tiempo = 0;
                    if (conteo == 0) { this.GetComponent<Image>().sprite = sprite_pause01; conteo = 1; }
                    else if (conteo == 1) { this.GetComponent<Image>().sprite = sprite_pause02; conteo = 0; }
                    break;


            }
        }
        tiempo++;

          
    }
}
