using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicaTutorial : MonoBehaviour
{

     public TextMeshProUGUI ScoreT, DineroT;
     public AudioClip sonidodinero;
     int score_points, dinero_jugador;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void sumarScore(int ss)
    {
        score_points = score_points + ss;
        ScoreT.text = "Score: " + score_points.ToString();
    }

     public void sumarDinero(int dd)
    {
        GetComponent<AudioSource>().volume = 0.5f;
        GetComponent<AudioSource>().PlayOneShot(sonidodinero);
        dinero_jugador = dinero_jugador + dd;
        DineroT.text = dinero_jugador.ToString() ;
    }


}
