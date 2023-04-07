using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform; // Referencia al transform del jugador

    private float _offsetX; // Distancia en X entre el jugador y el primer cubo

    private void Start()
    {
        // Calcular la distancia en X entre el jugador y el primer cubo
        _offsetX = transform.position.x - _playerTransform.position.x;
    }

    private void OnBecameInvisible()
    {
        // Mover los cubos en función del movimiento del jugador
        if (_playerTransform.position.x > transform.position.x && transform.position.x < _playerTransform.position.x - _offsetX)
        {
            transform.position += new Vector3(26f, 0f, 0f);
        }
        else if (_playerTransform.position.x < transform.position.x && transform.position.x > _playerTransform.position.x + _offsetX)
        {
            transform.position -= new Vector3(26f, 0f, 0f);
        }
    }
}
