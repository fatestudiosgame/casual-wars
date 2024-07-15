using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posta : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bandera;
      
    void Start()
    {
        bandera=GetComponentInChildren<Transform>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.name == "player01(Clone)")
        {
           if(collision.gameObject.GetComponent<PlayerLogic>().classPlayer()==2) {bandera.SetActive(true);}
        }
    }
    

     private void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.gameObject.name == "player01(Clone)")
        {
             if(collision.gameObject.GetComponent<PlayerLogic>().classPlayer()==2) {bandera.SetActive(false);}
        }
    }
}
