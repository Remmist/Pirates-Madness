using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
    }


    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            DestroyWall();
        }
    }


    private void DestroyWall()
    {
        Destroy(gameObject);
    }
}
