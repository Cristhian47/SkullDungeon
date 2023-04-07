using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPooling : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab de la flecha
    public float arrowSpeed = 10f; // Velocidad de la flecha
    public int arrowPoolSize = 10; // Tamaño del pool de flechas

    private List<GameObject> arrowPool; // Pool de flechas
    private int arrowIndex = 0;

    private void Start()
    {
        // Inicializar el pool de flechas
        arrowPool = new List<GameObject>();
        for (int i = 0; i < arrowPoolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.SetActive(false);
            arrowPool.Add(arrow);
        }
    }

    // Obtener una flecha del pool
    public GameObject GetArrowFromPool(Vector2 direction)
    {
        Arrow arrow = arrowPool[arrowIndex].GetComponent<Arrow>();
        arrow.SetDirection(direction);
        arrowIndex = (arrowIndex + 1) % arrowPoolSize;
        return arrow.gameObject;
    }
}
