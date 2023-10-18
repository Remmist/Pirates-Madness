using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
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

    private SpriteRenderer _sr;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        
        //Here, the engine decides whether the player faces left or right
        var playerTransform = transform;
        if (_xInput > 0)
        {
            playerTransform.localScale = new Vector2(1, transform.localScale.y);
        } else if (_xInput < 0)
        {
            playerTransform.localScale = new Vector2(-1, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _performJump = true;
        }

        if (Input.GetButtonDown("Jump") && _isAfterJump && _counterAirJumps < _maxAmountOfAirJumps)
        {
            _performAirJump = true;
            _counterAirJumps++;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * _speed, _rb.velocity.y);
        
        // Flip();

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

    // private void Flip()
    // {
    //     if (_xInput > 0)
    //     {
    //         _sr.flipX = false;
    //     }
    //     else if (_xInput < 0)
    //     {
    //         _sr.flipX = true;
    //     }
    // }


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