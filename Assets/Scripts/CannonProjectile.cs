using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            //Find new method how to get value from PlayerCharacteristics or TestEnemyCharacteristics
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<TestEnemyCharacteristics>().TakeDamage(_damage);
            }
            else
            {
                other.GetComponent<PlayerCharacteristics>().TakeDamage(_damage);
            }
            Destroy(gameObject);
        } else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
