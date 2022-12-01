using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private int velocidad;
    [SerializeField] private float gravityScale;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(movimientoX, 0, movimientoY) * velocidad;
    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }
}
