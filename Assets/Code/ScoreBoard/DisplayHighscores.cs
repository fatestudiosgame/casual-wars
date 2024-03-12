using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour 
{
    public TMPro.TextMeshProUGUI[] rNames;
    public TMPro.TextMeshProUGUI[] rScores;
    HighScores myScores;
    int score_a_subir;
   string nombre_a_subir;

    void Start() //Fetches the Data at the beginning
    {
        for (int i = 0; i < rNames.Length;i ++)
        {
            rNames[i].text = i + 1 + ". Buscando...";
        }
        myScores = GetComponent<HighScores>();
        StartCoroutine("RefreshHighscores");
        
    }
    public void SetScoresToMenu(PlayerScore[] highscoreList) //Assigns proper name and score for each text value
    {
        for (int i = 0; i < rNames.Length;i ++)
        {
            rNames[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                rScores[i].text = highscoreList[i].score.ToString();
                rNames[i].text = i+1 +"."+ highscoreList[i].username;
            }
        }
    }
    IEnumerator RefreshHighscores() //Refreshes the scores every 30 seconds
    {
        while(true)
        {
            myScores.DownloadScores();
            yield return new WaitForSeconds(10);
            SendScore();
            yield return new WaitForSeconds(3);            
        }
    }



    public void SendScore()
{
  score_a_subir=PlayerPrefs.GetInt("score_juego_maximo", 0);
  nombre_a_subir=PlayerPrefs.GetString("nombre_heroe", "anónimo");
  HighScores.UploadScore( nombre_a_subir, score_a_subir);  
  Debug.Log("Name Uploaded:"+ nombre_a_subir +" "+ "Score Uploaded:" + score_a_subir);
}
}
