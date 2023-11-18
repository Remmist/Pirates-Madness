using System.Collections;
using UnityEngine;

public class CannonProjectileSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private Transform _launchOffSet;

    private Animator _animator;
    private TestEnemyCharacteristics _enemyCharacteristics;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyCharacteristics = GetComponent<TestEnemyCharacteristics>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (_enemyCharacteristics.IsAlive)
        {
            _animator.SetTrigger("Fire");
            Instantiate(projectilePrefab, _launchOffSet.position, transform.rotation);
            yield return new WaitForSeconds(cooldown);
        }
    }

}
