using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f; // Velocidad de movimiento horizontal del personaje
    [SerializeField] private float _jumpForce = 5f; // Fuerza de salto del personaje
    [SerializeField] private PlayerAnimations _animation;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        ChangeViewDirection(horizontalInput);

        Vector2 velocity = _rb.velocity;
        velocity.x = horizontalInput * _moveSpeed;
        _rb.velocity = velocity;
    }

    private void Jump()
    {
        // Salto del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            _animation.SetAttack(true);
        }
    }
    private void ChangeViewDirection(float directionX)
    {
        Debug.Log(directionX);
        if (directionX == 0 || (transform.localScale.x < 0 && directionX < 0)) return;
        Vector3 newScale = transform.localScale;
        newScale.x = directionX * Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }

}