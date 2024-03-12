using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class TerminarOpening : MonoBehaviour
{
    public VideoClip  opening_nivel_01;
    VideoPlayer mi_video_player;

    public GameObject presentacion_pantalla;

    // Start is called before the first frame update
    void Start()
    {
        mi_video_player=GetComponent<VideoPlayer>();
        ReproducirVideo(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void termino_video(UnityEngine.Video.VideoPlayer vp)
    { 
        presentacion_pantalla.SetActive(false);
    }


    public void ReproducirVideo() 
    {
        mi_video_player.loopPointReached += termino_video;
        mi_video_player.clip=opening_nivel_01;
        mi_video_player.Play();   
    }

}
