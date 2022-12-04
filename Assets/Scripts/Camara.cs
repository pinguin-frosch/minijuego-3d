using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float angulo;
    [SerializeField] private float dy;
    private float anguloRadianes;
    private float dx;
    private Vector3 desfase;
    public static int rotacion = 0;
    public static Vector3[] rotaciones;

    void Start()
    {
        // Corregir variables para que estén dentro de los rangos permitidos
        if (dy < 0)
            dy = 0;

        if (angulo <= 0)
            angulo = 0.01f;

        if (angulo > 90)
            angulo = 90;

        // Configurar el ángulo de la cámara
        transform.rotation = Quaternion.Euler(angulo, 0, 0);

        // Calcular el desfase respecto del jugador
        anguloRadianes = (angulo * Mathf.PI) / 180;
        dx = dy / Mathf.Tan(anguloRadianes);

        // Crear todas las rotaciones posibles
        rotaciones = new Vector3[4] {
            new Vector3(0, dy, -dx),
            new Vector3(dx, dy, 0),
            new Vector3(0, dy, dx),
            new Vector3(-dx, dy, 0)
        };

        desfase = rotaciones[rotacion];
    }

    void Update()
    {
        // Mover la cámara siguiendo al jugador
        transform.position = jugador.position + desfase;

        // Girar la cámara según el botón pulsado
        if (Input.GetKeyDown(KeyCode.Q))
        {
            girarDerecha();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            girarIzquierda();
        }
    }

    private void girarIzquierda()
    {
        rotacion = (rotacion - 1) % 4;
        if (rotacion < 0)
            rotacion += 4;

        // Girar la cámara y el jugador a la izquierda
        desfase = rotaciones[rotacion];
        Vector3 rotacionActual = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotacionActual.x, rotacionActual.y + 90, rotacionActual.z);
        jugador.rotation = Quaternion.Euler(0, jugador.rotation.eulerAngles.y + 90, 0);
    }

    private void girarDerecha()
    {
        rotacion = (rotacion + 1) % 4;

        // Girar la cámara y el jugador a la derecha
        desfase = rotaciones[rotacion];
        Vector3 rotacionActual = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotacionActual.x, rotacionActual.y - 90, rotacionActual.z);
        jugador.rotation = Quaternion.Euler(0, jugador.rotation.eulerAngles.y - 90, 0);
    }
}
