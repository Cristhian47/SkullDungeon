using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la flecha
    public Vector2 initialDirection = Vector2.right; // Dirección inicial de la flecha
    private Rigidbody rb;

    private void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        initialDirection = direction;
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialDirection.normalized * speed;
    }
}
