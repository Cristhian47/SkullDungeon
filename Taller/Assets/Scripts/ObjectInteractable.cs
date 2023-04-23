using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    private bool _isDetecting;

    public enum InteractionType
    {
        OpenDoor,
        DialogWithNPC,
        LootItem
    }

    [SerializeField] private InteractionType _currentInteractionType;
    [SerializeField] private GameObject _doorToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isDetecting = true;
            GameManager.Instance.OpenInteractText(_isDetecting);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isDetecting = false;
            GameManager.Instance.OpenInteractText(_isDetecting);
        }
    }

    private void Update()
    {
        if (_isDetecting && Input.GetKeyDown(KeyCode.E))
        {
            _doorToOpen.gameObject.SetActive(false);
        }
    }
}
