using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Rigidbody2D _rb;
    [SerializeField] private AudioSource _audioThrow; // Add this line for audio playback

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioThrow.Play();

  
    }

    // Collision conditions for player's projectiles
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BreakableWall"))
        {
            other.GetComponent<BreakableWall>().TakeDamage(_damage);
            _audioThrow.Play();

            Destroy(gameObject);
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            // Find a new method to get value from PlayerCharacteristics
            other.GetComponent<TestEnemyCharacteristics>().TakeDamage(_damage);
            _audioThrow.Play();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            _audioThrow.Play();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

  
}
