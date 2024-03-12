using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefrescarUI : MonoBehaviour
{

    public Sprite sprite00;
    public Sprite sprite01;
    public Sprite sprite02;
    int conteo;
    float tiempo;
    public int refresco;
    bool refrescar_state;
    int  altas_prestaciones;

    // Start is called before the first frame update
    void Start()
    {
        tiempo=0;
        conteo = 0;
        refresco = 5;
        refrescar_state = true;
        altas_prestaciones= PlayerPrefs.GetInt("altas_prestaciones", 1);
        if(altas_prestaciones==1){refrescar_state = true;}
        else{refrescar_state = false;}
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      /*  
        if (tiempo > refresco && refrescar_state == true)
        {
            tiempo = 0;
            if (conteo == 0) { this.GetComponent<Image>().sprite = sprite01; conteo = 1; }
            else if (conteo == 1) { this.GetComponent<Image>().sprite = sprite02; conteo = 0; }
        }
     tiempo ++;
     */
    }



    }
