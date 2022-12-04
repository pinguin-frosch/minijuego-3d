using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Obtener la configuración de rotación de la cámara
        Vector3 rotacionActual = Camara.rotaciones[Camara.rotacion];
        float rotacionX = rotacionActual.x;
        float rotacionZ = rotacionActual.z;

        // Movimiento en cada eje
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        // Mover al jugador igual que la cámara
        if (rotacionX == 0 && rotacionZ == -1)
        {
            rb.velocity = new Vector3(movimientoX, 0, movimientoY);
        }
        else if (rotacionX == -1 && rotacionZ == 0)
        {
            rb.velocity = new Vector3(movimientoY, 0, -movimientoX);
        }
        else if (rotacionX == 1 && rotacionZ == 0)
        {
            rb.velocity = new Vector3(-movimientoY, 0, movimientoX);
        }
        else if (rotacionX == 0 && rotacionZ == 1)
        {
            rb.velocity = new Vector3(-movimientoX, 0, -movimientoY);
        }
    }
}
