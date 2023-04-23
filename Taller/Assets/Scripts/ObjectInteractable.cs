using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    private bool _isDetecting;

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
            Debug.Log("Open The Door");
        }
    }
}
