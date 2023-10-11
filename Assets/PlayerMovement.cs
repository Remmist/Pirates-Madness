using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xInput;
    [SerializeField] private float _speed = 5;

    private bool _performJump;
    private bool _isGrounded;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _maxAmountOfAirJumps = 1;
    private int _counterAirJumps = 0;
    private bool _isAfterJump;
    private bool _performAirJump;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _performJump = true;
        }

        if (Input.GetButtonDown("Jump") && _isAfterJump)
        {
            _performAirJump = true;
            _counterAirJumps++;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * _speed, _rb.velocity.y);

        //Default Jump
        if (_performJump)
        {
            _performJump = false;
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _isAfterJump = true;
        }
        
        //Air Jump (Double jump)
        if (_performAirJump && _maxAmountOfAirJumps >= _counterAirJumps)
        {
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _performAirJump = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
        _isAfterJump = false;
        _counterAirJumps = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;
    }
}