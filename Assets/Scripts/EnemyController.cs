using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int patrolDestination;
    [SerializeField] private Transform obstacleCheckPoint;
    [SerializeField] private float obstacleCheckRadius = 0.5f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform gulfCheck_1;
    [SerializeField] private Transform gulfCheck_2;
    [SerializeField] private float gulfCheckRadius = 0.1f;
    
    private Color _gizmosColor;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _chaseDistance;
    //[SerializeField] private float _StopChaseDistance;
    
    
    private bool _isGrounded;
    private bool _isJumping;
    private bool _isChasing;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*
         * Quick note - while setting patrol points (ex. adding empty objects to enemy instance on hierarchy view,
         * then setting these objects on the scene), make sure the first patrol point (the one to which the enemy comes
         * in the first place), is on the right from the enemy instance, otherwise, there will be problems with swapping
         * the enemy model left/right.
         */
        if (_isChasing)
        {
            if (transform.position.x > _playerTransform.position.x)
            {
                var transformVar = transform;
                transformVar.localScale = new Vector3(-Math.Abs(transformVar.localScale.x), transformVar.localScale.y, 1);
                transformVar.position += Vector3.left * ((_moveSpeed + _chaseSpeed) * Time.deltaTime);
            }
            if  (transform.position.x < _playerTransform.position.x)
            {
                var transformVar = transform;
                transformVar.localScale = new Vector3(Math.Abs(transformVar.localScale.x), transformVar.localScale.y, 1);
                transformVar.position += Vector3.right * ((_moveSpeed + _chaseSpeed) * Time.deltaTime);
            }
            
            if (!_isJumping && !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
            {
                var transformLocalScale = transform.localScale;
                if (transformLocalScale.x < 0)
                {
                    transformLocalScale = new Vector3(Math.Abs(transformLocalScale.x), transformLocalScale.y, 1);
                    transform.localScale = transformLocalScale;
                } else if (transformLocalScale.x > 0)
                {
                    transformLocalScale = new Vector3(-Math.Abs(transformLocalScale.x), transformLocalScale.y, 1);
                    transform.localScale = transformLocalScale;
                }
                _isChasing = false;
            }
            
        }
        else
        {

            if (Vector2.Distance(transform.position, _playerTransform.position) < _chaseDistance)
            {
                _isChasing = true;
            }
            /*
            if (Vector2.Distance(transform.position, _playerTransform.position) > _StopChaseDistance)
            {
                _isChasing = false;
            }
            */
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    _patrolPoints[0].position,
                    _moveSpeed * Time.deltaTime
                );
                if (Vector2.Distance(transform.position, _patrolPoints[0].position) < .2f)
                {
                    var transform1 = transform;
                    transform1.localScale = new Vector3(-Math.Abs(transform1.localScale.x), transform1.localScale.y, 1);
                    patrolDestination = 1;
                }
            }
            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    _patrolPoints[1].position,
                    _moveSpeed * Time.deltaTime
                );
                if (Vector2.Distance(transform.position, _patrolPoints[1].position) < .2f)
                {
                    var transform1 = transform;
                    transform1.localScale = new Vector3(Math.Abs(transform1.localScale.x), transform1.localScale.y, 1);
                    patrolDestination = 0;
                }
            }
        }
        
        if (DetectObstacle())
        {
            Jump();
        }
        
        JumpOverGulf();
            
    }
    
    private bool DetectObstacle()
    {
        Vector2 checkPosition = obstacleCheckPoint.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, obstacleCheckRadius, obstacleLayer);
        return (colliders.Length > 0);
    }
    
    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        _isJumping = true;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isJumping = false;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        var position = transform.position;
        
        _gizmosColor = Color.red;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(position, _chaseDistance);
        
        /*
        _gizmosColor = Color.green;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(position, _StopChaseDistance);
        */
        
        _gizmosColor = Color.white;
        Gizmos.color = _gizmosColor;
        var position1 = gulfCheck_1.position;
        var position2 = gulfCheck_2.position;
        Gizmos.DrawLine(position1, position2);
        Gizmos.DrawWireSphere(position1, gulfCheckRadius);
        Gizmos.DrawWireSphere(position2, gulfCheckRadius);
        
        _gizmosColor = Color.yellow;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(_patrolPoints[0].position, .2f);
        Gizmos.DrawWireSphere(_patrolPoints[1].position, .2f);
        
        _gizmosColor = Color.magenta;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(obstacleCheckPoint.position, obstacleCheckRadius);
        
        _gizmosColor = Color.cyan;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void JumpOverGulf()
    {
        if (!_isJumping &&
            !Physics2D.OverlapCircle(gulfCheck_1.position, gulfCheckRadius, groundLayer) &&
            !Physics2D.OverlapCircle(gulfCheck_2.position, gulfCheckRadius, groundLayer))
        {
            Jump();
        }
    }
    
}
