using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private bool _isRunning;
    private NavMeshAgent _playerAgent;
    private Ray _currentRay;
    private RaycastHit _rayData;
    private Animator _playerAnimation;

    [SerializeField] private LayerMask _walkableLayer;
    
    void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
        _playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(_currentRay, out _rayData, 100, _walkableLayer.value))
            {
                _playerAgent.SetDestination(_rayData.point);
                _isRunning = true;
                _playerAnimation.SetBool("IsRunning", true);
                GameManager.Instance.CreateClickEffect(_rayData.point);
            }
        }
        if(_playerAgent.velocity == Vector3.zero)
        {
            _isRunning = false;
            _playerAnimation.SetBool("IsRunning", false);
        }
    }
}
