using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCarrito : MonoBehaviour
{
    int conteo, movimiento;
    float tiempo;
    Vector3 posicion_original;

    // Start is called before the first frame update
    void Start()
    {
        conteo = 0;
        movimiento = 5;
        posicion_original = new Vector3(transform.position.x,
        transform.position.y,
        transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           if (tiempo > movimiento) {
            tiempo = 0;
            if (conteo == 0) {
        transform.position = new Vector3(transform.position.x,
        posicion_original.y - 0.01f,
        transform.position.z);
                conteo = 1;
            }
            else if (conteo == 1) {
        transform.position = new Vector3(transform.position.x,
        posicion_original.y + 0.01f,
        transform.position.z);
                conteo = 0;
            }
        }
        tiempo++;
    }
}
