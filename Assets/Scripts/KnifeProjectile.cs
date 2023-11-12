using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //Collision conditions for player's projectiles
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BreakableWall"))
        {
            other.GetComponent<BreakableWall>().TakeDamage(_damage);
            Destroy(gameObject);
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            //Find new method how to get value from PlayerCharacteristics
            other.GetComponent<TestEnemyCharacteristics>().TakeDamage(_damage);
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
