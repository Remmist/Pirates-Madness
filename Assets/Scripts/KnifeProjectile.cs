using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private AudioSource _hitSound;  
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
            _hitSound.Play();
            Destroy(gameObject);
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            //Find new method how to get value from PlayerCharacteristics
            other.GetComponent<TestEnemyCharacteristics>().TakeDamage(_damage);
            _hitSound.Play();
            Destroy(gameObject);
        } else if (other.CompareTag("Ground"))
        {
            _hitSound.Play();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
