using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;


public class HighScores : MonoBehaviour
{
public GameObject boton_upload;
string temporal_texto;

    const string privateCode = "fZUi8rLPkkug1fEzb_CPrwFhn-mSU6kESsWCpj5yOwEw";  //Key to Upload New Info
    const string publicCode = "625567e48f4133123c5dee68";   //Key to download
    const string webURL = "http://dreamlo.com/lb/"; //  Website the keys are for

    public PlayerScore[] scoreList;
    DisplayHighscores myDisplay;

    static HighScores instance; //Required for STATIC usability
    void Awake()
    {
        instance = this; //Sets Static Instance
        myDisplay = GetComponent<DisplayHighscores>();
    }
    
    public static void UploadScore(string username, int score)  //CALLED when Uploading new Score to WEBSITE
    {//STATIC to call from other scripts easily
       instance.StartCoroutine(instance.DatabaseUpload(username,score)); //Calls Instance
    }


     IEnumerator DatabaseUpload(string userame, int score) //Called when sending new score to Website
    { 
     UnityWebRequest request = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(userame) + "/" + score);
    yield return request.SendWebRequest();
     if(request.result==UnityWebRequest.Result.ConnectionError){Debug.Log("Error uploading");}     
    else{DownloadScores();}  
    }
 
    /*
    IEnumerator DatabaseUpload(string userame, int score) //Called when sending new score to Website
    {
      
     WWW www = new WWW(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(userame) + "/" + score);
      // WWW www = new WWW(webURL + privateCode + "/add/" + "S" + "/" + "20");
      
      yield return www;
      
       if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Successful");
            DownloadScores();
        }
      
        else Debug.Log("Error uploading" + www.error);
    }
    */




    public void DownloadScores()
    {
        StartCoroutine(DatabaseDownload());
    }
    
      IEnumerator DatabaseDownload() 
    { 
     UnityWebRequest request = UnityWebRequest.Get(webURL + publicCode + "/pipe/0/10");
     yield return request.SendWebRequest();
     if(request.result==UnityWebRequest.Result.ConnectionError){Debug.Log("Error donwload");}     
     else{ 
         OrganizeInfo(request.downloadHandler.text);
         Debug.Log(request.downloadHandler.text);            
         myDisplay.SetScoresToMenu(scoreList);
        }
    }  
    
    
 

    void OrganizeInfo(string rawData) //Divides Scoreboard info by new lines
    {
        string[] entries = rawData.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        scoreList = new PlayerScore[entries.Length];
        for (int i = 0; i < entries.Length; i ++) //For each entry in the string array
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            scoreList[i] = new PlayerScore(username,score);
            //print(scoreList[i].username + ": " + scoreList[i].score);
        }
    }
}

public struct PlayerScore //Creates place to store the variables for the name and score of each player
{
    public string username;
    public int score;

    public PlayerScore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}