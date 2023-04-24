using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    private bool _isDetecting;

    //Asigna el tipo de objeto interactuable
    public enum InteractionType
    {
        OpenDoor,
        DialogWithNPC,
        LootItem
    }

    [SerializeField] private InteractionType _currentInteractionType;
    [SerializeField] private GameObject _doorToOpen;

    //Verifica si el jugador entra al area de detección para activar el texto de interaccion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isDetecting = true;
            GameManager.Instance.OpenInteractText(_isDetecting);
        }
    }

    //Verifica si el jugador sale del area de detección para desactivar el texto de interaccion
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isDetecting = false;
            GameManager.Instance.OpenInteractText(_isDetecting);
        }
    }

    //Desactiva la puerta si presiona E mientras está dentro del area de interacción
    private void Update()
    {
        if (_isDetecting && Input.GetKeyDown(KeyCode.E))
        {
            _doorToOpen.gameObject.SetActive(false);
        }
    }
}
