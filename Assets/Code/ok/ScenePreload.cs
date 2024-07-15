using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePreload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

     IEnumerator esperar()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("02_main_menu"); 
    }
}
