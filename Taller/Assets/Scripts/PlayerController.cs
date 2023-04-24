using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private bool _isRunning;
    private bool _isAttacking;
    private NavMeshAgent _playerAgent;
    private Ray _currentRay;
    private RaycastHit _rayData;
    private Animator _playerAnimation;

    [SerializeField] private LayerMask _walkableLayer;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDelay = 0.5f;
    [SerializeField] private GameObject _attackArea;
    
    void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
        _playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        //Si hizo clic en el juego verifica si es un enemigo o el suelo
        if (Input.GetMouseButtonDown(0))
        {
            _currentRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_currentRay, out _rayData, 100, _enemyLayer.value))
            {
                Attack();
            }
            else if (Physics.Raycast(_currentRay, out _rayData, 100, _walkableLayer.value))
            {
                Run();
            }
        }
        FinishRun();
    }

    //Si la distancia es menor a 2 atacar y si no, persigue
    private void Attack()
    {
        if (_isAttacking) return;

        if(Vector3.Distance(transform.position, _rayData.point) < 2)
        {
            _isAttacking = true;
            _playerAnimation.SetBool("Attack", true);
            _attackArea.SetActive(true);
            _rayData.collider.gameObject.SetActive(true);
            StartCoroutine(FinishAttack());
        }
        else
        {
            _playerAgent.SetDestination(_rayData.point);
        }
    }

    //Espera a que acabe el tiempo delay de ataque para desactivarlo
    public IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(_attackDelay);
        _attackArea.SetActive(false);
        _playerAnimation.SetBool("Attack", false);
        _isAttacking = false;
    }

    //Mueve al jugador a la posición que hizo clic
    private void Run()
    {
        _playerAgent.SetDestination(_rayData.point);
        _isRunning = true;
        _playerAnimation.SetBool("IsRunning", true);
        GameManager.Instance.CreateClickEffect(_rayData.point);
    }

    //Si el jugador está quieto, deja de hacer la animación de correr
    private void FinishRun()
    {
        if (_playerAgent.velocity == Vector3.zero)
        {
            _isRunning = false;
            _playerAnimation.SetBool("IsRunning", false);
        }
    }
}
