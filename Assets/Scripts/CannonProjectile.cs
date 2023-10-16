using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
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
                other.GetComponent<TestEnemyCharacteristics>().TakeDamage(50);
            }
            else
            {
                other.GetComponent<PlayerCharacteristics>().TakeDamage(50);
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
