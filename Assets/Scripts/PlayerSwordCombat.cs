using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristics))]
public class PlayerSwordCombat : MonoBehaviour
{

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayers;
    private bool _isAttacking;

    private PlayerCharacteristics _player;
    private Animator _animator;


    private void Awake()
    {
        _player = GetComponent<PlayerCharacteristics>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isAttacking = true;
            System.Random rnd = new System.Random();
            _animator.SetInteger("AttackIndex", rnd.Next(0,3));
            _animator.SetTrigger("Attack");
            Attack();
        }
    }


    private void Attack()
    {
        Collider2D[] hitEnemyes = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

        foreach (var enemy in hitEnemyes)
        {
            enemy.GetComponent<TestEnemyCharacteristics>().TakeDamage(_player.Damage);
            
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
