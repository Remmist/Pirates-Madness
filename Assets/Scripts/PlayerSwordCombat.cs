using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristics))]
public class PlayerSwordCombat : MonoBehaviour
{

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private float _attackRate = 2f;
    private bool _isAttacking;
    private float _nextAttackTime = 0f;

    private PlayerCharacteristics _player;
    private Animator _animator;
    private PlayerMovement _playerMovement;


    private void Awake()
    {
        _player = GetComponent<PlayerCharacteristics>();
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement._isDashing)
        {
            Attack(true);
        }
        if (Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _isAttacking = true;
                System.Random rnd = new System.Random();
                _animator.SetInteger("AttackIndex", rnd.Next(0,3));
                _animator.SetTrigger("Attack");
                Attack(false);
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }
    }


    private void Attack(bool dash)
    {
        Collider2D[] hitEnemyes = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        

        foreach (var enemy in hitEnemyes)
        {
            if (dash)
            {
                enemy.GetComponent<TestEnemyCharacteristics>().TakeDamage(_player.Damage);
            }
            else
            {
                enemy.GetComponent<TestEnemyCharacteristics>().TakeDamage(_player.Damage);
            }
        }
        _isAttacking = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
    
    
}
