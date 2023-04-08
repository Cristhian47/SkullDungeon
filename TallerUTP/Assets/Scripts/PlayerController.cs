using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canAttack = true;
    private float _direction = 0;

    [SerializeField] private float _moveSpeed = 5f; // Velocidad de movimiento horizontal del personaje
    [SerializeField] private float _jumpForce = 5f; // Fuerza de salto del personaje
    [SerializeField] private float _arrowSpeed = 10f; // Velocidad de la flecha
    [SerializeField] private float _attackCooldown = 1f; // Velocidad de ataque
    [SerializeField] private PlayerAnimations _animation;
    [SerializeField] private ArrowPooling _arrowPool;
    private Rigidbody _rb;
    [SerializeField] private float _groundDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
        Shoot();
    }

    public float GetDirection()
    {
        return _direction;
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _direction = horizontalInput;

        ChangeViewDirection(horizontalInput);

        Vector2 velocity = _rb.velocity;
        velocity.x = horizontalInput * _moveSpeed;
        _rb.velocity = velocity;
    }

    private void Jump()
    {
        // Verificar si el jugador está tocando el suelo
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, _groundDistance, _groundLayer))
        {
            _isGrounded = true;
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.green);
        }
        else
        {
            _isGrounded = false;
            Debug.DrawRay(transform.position, Vector3.down * _groundDistance, Color.red);
        }

        // Salto del personaje
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) && _canAttack)
        {
            StartCoroutine(AttackCooldown());
            _animation.SetAttack(true);
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }

    private void ChangeViewDirection(float directionX)
    {
        if (directionX == 0 || (transform.localScale.x < 0 && directionX < 0)) return;
        Vector3 newScale = transform.localScale;
        newScale.x = directionX * Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }

    private void Shoot()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Obtener la dirección desde la posición del jugador hasta la posición del ratón
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Instanciar la flecha y cambiar su dirección inicial
        if (Input.GetMouseButtonDown(1))
        {
            GameObject arrow = _arrowPool.GetArrowFromPool(direction);
            arrow.transform.position = transform.position;
            arrow.SetActive(true);
        }
    }

}