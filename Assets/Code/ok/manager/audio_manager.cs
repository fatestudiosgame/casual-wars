using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
       public static audio_manager audio_manager_instance;

     
     public AudioClip aa;
     AudioSource my_audio_source;
     

    

    
      private void Awake() {

      if(audio_manager_instance==null)
     {
        audio_manager_instance=this;
     }
     else {Destroy(gameObject);}

     
    }

    // Start is called before the first frame update
    void Start()
    {
        my_audio_source = GetComponent<AudioSource>();
    }

     

    // Update is called once per frame
    void Update()
    {
        
    }


}
