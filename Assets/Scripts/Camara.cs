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
        desfase = new Vector3(0, dy, -dx);
    }

    void Update()
    {
        // Mover la cámara siguiendo al jugador
        transform.position = jugador.position + desfase;
    }
}
