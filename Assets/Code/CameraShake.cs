using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject Hero;
   

   public IEnumerator Shake(float dur,float mag)
   {
    Vector3 originalPosition = transform.localPosition;
    float elapsed = 0;

    while (elapsed<dur)
    {
        float x = Random.Range(-0.05f,0.05f)*mag;
        float y = Random.Range(-0.05f,0.05f)*mag;

        transform.localPosition = new Vector3(Hero.transform.position.x+ x,originalPosition.y+y,originalPosition.z);
        
        elapsed += Time.deltaTime;
        yield return null;
    }

    transform.localPosition=new Vector3(Hero.transform.position.x,originalPosition.y,originalPosition.z);

   }

   
}
