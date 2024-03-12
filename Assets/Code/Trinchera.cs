using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trinchera : MonoBehaviour
{

    int vida_trinchera, vida_max_trincheram, tipobalaenemy;


    // Start is called before the first frame update
    void Start()
    {
      vida_trinchera = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "balaenemy(Clone)")
        {
            tipobalaenemy = collision.gameObject.GetComponent<BalaEnemy>().getTipobala();
            switch (tipobalaenemy)
            {
                case 1: Debug.Log("bala01ok"); vida_trinchera = vida_trinchera - 1; break;
                case 2: Debug.Log("bala02ok"); vida_trinchera = vida_trinchera - 5; break;

            }

            if (vida_trinchera < 1) { Destroy(this.gameObject); }
        }


    }

}
