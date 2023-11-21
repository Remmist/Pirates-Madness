using UnityEngine;

namespace Old_Code
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float patrolSpeed;
        [SerializeField] private float detectionRange;
        [SerializeField] private float changeDirectionDelay = 1f;
        [SerializeField] private float patrolRadius;

        [Header("Patrol Points")]
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;

        private Rigidbody2D _rb;
        private Vector2 _currentPoint;
        private EnemyDetection _enemyDetection;
        private float _lastDirectionChangeTime;
        private Color _gizmosColor;
        private bool _isGrounded;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _enemyDetection = GetComponent<EnemyDetection>();
            _currentPoint = pointB.position;
            _lastDirectionChangeTime = Time.time;
        
            _enemyDetection.SetPatrolPoints(pointA.position, pointB.position);
            _enemyDetection.SetDetectionRange(detectionRange);
        }

        void FixedUpdate()
        {
            bool playerDetected = _enemyDetection.DetectPlayer();

            if (playerDetected)
            {
                Vector2 playerPosition = _enemyDetection.GetPlayerPosition();
                ChasePlayer(playerPosition);
            }
            else
            {
                Patrol();
            }
        
        }

        private void Patrol()
        {
            if (Time.time - _lastDirectionChangeTime > changeDirectionDelay)
            {
                float distanceToA = Vector2.Distance(transform.position, _enemyDetection.GetPatrolPointA());
                float distanceToB = Vector2.Distance(transform.position, _enemyDetection.GetPatrolPointB());
            
                if (distanceToA <= patrolRadius)
                {
                    _currentPoint = _enemyDetection.GetPatrolPointB();
                    Flip();
                    _lastDirectionChangeTime = Time.time;
                }
                else if (distanceToB <= patrolRadius)
                {
                    _currentPoint = _enemyDetection.GetPatrolPointA();
                    Flip();
                    _lastDirectionChangeTime = Time.time;
                }

                Vector2 moveDirection = (_currentPoint - (Vector2)transform.position).normalized;
                _rb.velocity = moveDirection * patrolSpeed;
            }
        }

        private void ChasePlayer(Vector2 targetPosition)
        {
            Vector2 directionToPlayer = (targetPosition - (Vector2)transform.position).normalized;
            directionToPlayer.y = 0.0f;
            _rb.velocity = directionToPlayer * chaseSpeed;

            if (directionToPlayer.x > 0)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
            } else if (directionToPlayer.x < 0)
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
            }
        
        }

        private void Flip()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        private void OnDrawGizmosSelected()
        {
            _gizmosColor = Color.red;
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireSphere(pointA.position, 0.2f);
            Gizmos.DrawWireSphere(pointB.position, 0.2f);
        
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pointA.position, patrolRadius);
            Gizmos.DrawWireSphere(pointB.position, patrolRadius);
        
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        
        
        }
    }
}