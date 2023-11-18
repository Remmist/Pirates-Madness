using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _xInput;
    [SerializeField] private PlayerConfig _playerConfig;
    private float _currentSpeed;
    private float _previousSpeed;
    private bool _isSpeedEffect;

    private bool _performJump;
    private bool _isGrounded;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _maxAmountOfAirJumps = 1;
    private int _counterAirJumps = 0;
    private bool _isAfterJump;
    private bool _performAirJump;
    
    private Animator _animator;

    private bool _canDash = true;
    private bool _isDashing;
    [SerializeField] private float _dashPower = 24f;
    [SerializeField] private float _dashCooldown = 1f;
    [SerializeField] private float _dashTime = 0.2f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentSpeed = _playerConfig.BaseSpeed;
    }

    private void Update()
    {
        if (_isDashing)
        {
            return;
        }
        _xInput = Input.GetAxis("Horizontal");

        if (_xInput == 0)
        {
            _animator.SetBool("IsRunning", false);
        }
        //Here, the engine decides whether the player faces left or right
        var playerTransform = transform;
        if (_xInput > 0)
        {
            _animator.SetBool("IsRunning", true);
            playerTransform.localScale = new Vector2(1, transform.localScale.y);
        } else if (_xInput < 0)
        {
            _animator.SetBool("IsRunning", true);
            playerTransform.localScale = new Vector2(-1, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _performJump = true;
        }

        if (Input.GetButtonDown("Jump") && _isAfterJump && _counterAirJumps < _maxAmountOfAirJumps)
        {
            _animator.SetBool("IsAirJumped", true);
            _performAirJump = true;
            _counterAirJumps++;
        }


        if (Input.GetKey(KeyCode.LeftShift) && _canDash)
        {
            _animator.SetTrigger("Dash");
            StartCoroutine(Dash());
        }
        
    }

    private void FixedUpdate()
    {
        if (_isDashing)
        {
            return;
        }
        _rb.velocity = new Vector2(_xInput * _currentSpeed, _rb.velocity.y);
        
        _animator.SetFloat("XInputAbs", Math.Abs(_xInput));

        if (_rb.velocity.y < -0.5)
        {
            _animator.SetBool("IsFalling", true);
        }
        else
        {
            _animator.SetBool("IsFalling", false);
        }

        //Default Jump
        if (_performJump)
        {
            _performJump = false;
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _isAfterJump = true;
            _animator.SetBool("IsAfterJump", true);
        }
        
        //Air Jump (Double jump)
        if (_performAirJump && _maxAmountOfAirJumps >= _counterAirJumps)
        {
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _performAirJump = false;
            _animator.SetBool("IsAirJumped", false);
        }
    }


    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * _dashPower, 0f);
        yield return new WaitForSeconds(_dashTime);
        _rb.gravityScale = originalGravity;
        _isDashing = false;
        GetComponent<PlayerSwordCombat>().DashLimit = false;
        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (!(other.collider.CompareTag("Ground") || other.collider.CompareTag("BreakablePlatform")))
        {
            return;
        }
        _isGrounded = true;
        _isAfterJump = false;
        _animator.SetBool("IsGrounded", true);
        _animator.SetBool("IsAfterJump", false);
        _counterAirJumps = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!(other.collider.CompareTag("Ground") || other.collider.CompareTag("BreakablePlatform")))
        {
            return;
        }
        _isGrounded = false;
        _animator.SetBool("IsGrounded", false);
    }
    
    public void IncreaseSpeed(int speedAmount)
    {
        if (speedAmount < 0)
        {
            return;
        }

        _isSpeedEffect = true;
        _previousSpeed = _currentSpeed;

        if (_currentSpeed + speedAmount > _playerConfig.MaxSpeed)
        {
            _currentSpeed = _playerConfig.MaxSpeed;
            return;
        }

        _currentSpeed += speedAmount;
    }

    public void ReturnSpeed()
    {
        _isSpeedEffect = false;
        _currentSpeed = _previousSpeed;
    }

    public float CurrentPlayerSpeed
    {
        get => _currentSpeed;
        set => _currentSpeed = value;
    }

    public bool IsDashing
    {
        get => _isDashing;
        set => _isDashing = value;
    }

    public bool IsSpeedEffect => _isSpeedEffect;
}