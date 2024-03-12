using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorDeFondos : MonoBehaviour
{
    public GameObject mi_fondo;
    GameObject objeto01;
    GameObject objeto02;

    // Start is called before the first frame update
    void Start()
    {
        objeto01 = Instantiate(mi_fondo, GameObject.Find("LugarDelMar").transform.position, GameObject.Find("LugarDelMar").transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (objeto01.transform.position.x < -84)
        {
            objeto01 = Instantiate(mi_fondo, GameObject.Find("LugarDelMar").transform.position, GameObject.Find("LugarDelMar").transform.rotation);
        
        }
    }
}
