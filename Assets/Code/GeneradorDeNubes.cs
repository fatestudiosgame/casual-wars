using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeNubes : MonoBehaviour
{
    public GameObject mi_nube;
    float tiemponube;
    float tiempoaleatorio;
    float posicionaletoria;

    // Start is called before the first frame update
    void Start()
    {
        tiemponube = 0;
        tiempoaleatorio = 0;
        primerasnubes();


    }

    // Update is called once per frame
    void Update()
    {
        tiemponube = tiemponube + Time.deltaTime;
        if (tiemponube > tiempoaleatorio)
        {
            Instantiate(
                mi_nube,
                new Vector3(this.transform.position.x, this.transform.position.y + posicionaletoria, this.transform.position.z),
                this.transform.rotation
                );


            tiemponube = 0;
            tiempoaleatorio = Random.Range(5f, 10f);
            posicionaletoria = Random.Range(-0.2f, 0.2f);
        }

    }



    void primerasnubes()
    {
        for (int i=0; i < 10; i++)
        {
            posicionaletoria = Random.Range(-0.2f, 0.2f);

            Instantiate(
                   mi_nube,
                   new Vector3(this.transform.position.x - Random.Range(0f, 50f), this.transform.position.y + posicionaletoria, this.transform.position.z),
                   this.transform.rotation
                   );

        }

    }
}
