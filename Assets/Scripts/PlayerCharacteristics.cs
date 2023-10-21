using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float damage = 10;

    private float _currentHealth;

    private Animator _animator;

    private void Awake()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float takenDamage)
    {
        _animator.SetTrigger("Hurt");
        _currentHealth -= takenDamage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player die!");
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }
}
