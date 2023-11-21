using UnityEngine;

namespace Old_Code
{
    public class EnemyDetection : MonoBehaviour
    {
        private float _detectionRange;
        private Transform _player;
        private Transform _patrolPointA;
        private Transform _patrolPointB;
    
        public void SetDetectionRange(float range)
        {
            _detectionRange = range;
        }
    
        public void SetPatrolPoints(Vector2 pointA, Vector2 pointB)
        {
            _patrolPointA.position = pointA;
            _patrolPointB.position = pointB;
        }

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _patrolPointA = new GameObject("PatrolPointA").transform;
            _patrolPointB = new GameObject("PatrolPointB").transform;
        }

        public bool DetectPlayer()
        {
            return Physics2D.OverlapCircle(transform.position, _detectionRange, LayerMask.GetMask("Player"));
        }

        public Vector2 GetPlayerPosition()
        {
            return _player.position;
        }

        public Vector2 GetPatrolPointA()
        {
            return _patrolPointA.position;
        }

        public Vector2 GetPatrolPointB()
        {
            return _patrolPointB.position;
        }
    }
}
