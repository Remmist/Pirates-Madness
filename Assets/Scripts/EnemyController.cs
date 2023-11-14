using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float movementSpeed;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform obstacleCheckPoint;
    public float obstacleCheckRadius = 0.5f;
    public LayerMask obstacleLayer;

    private bool _isGrounded;
    private bool _isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * movementSpeed * transform.right);
        
        if (!_isJumping && !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }

        if (DetectObstacle())
        {
            Jump();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        movementSpeed *= -1;
    }

    private bool DetectObstacle()
    {
        Vector2 checkPosition = obstacleCheckPoint.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, obstacleCheckRadius, obstacleLayer);
        return (colliders.Length > 0);
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        _isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isJumping = false;
        }
    }
}
