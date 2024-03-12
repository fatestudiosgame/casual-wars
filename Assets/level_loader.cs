using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_loader : MonoBehaviour
{

      public static level_loader level_loader_instance;
      public Animator transition;
      public float transition_time;

    void Awake()
   {
     if(level_loader_instance==null)
     {
        level_loader_instance=this;
     }
     else {Destroy(gameObject);}
   }
 
    


    public void load_scene(string scene_name)
    {
        StartCoroutine(LoadScenario(scene_name));
    }

    public AsyncOperation load_scene_async(string scene_name)
    {
       return LoadScenarioAsync(scene_name);
    }
    



      IEnumerator LoadScenario(string scene_name)
    {
         transition.SetTrigger("start");
         yield return new WaitForSeconds(transition_time);
         SceneManager.LoadScene(scene_name);        

    }
     
        AsyncOperation LoadScenarioAsync(string scene_name)
    {
         transition.SetTrigger("start");
         return SceneManager.LoadSceneAsync(scene_name);        
    } 

}
