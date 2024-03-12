using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperarTiempo());
    }

   

    IEnumerator esperarTiempo()   //esperar tiempo para explotar
    {

        while (tiempo < 1f)
        {          
            tiempo += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
   }

}
