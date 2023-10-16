using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristics))]
public class PlayerSwordCombat : MonoBehaviour
{

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayers;

    private PlayerCharacteristics _player;


    private void Awake()
    {
        _player = GetComponent<PlayerCharacteristics>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
