using System.Collections;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> Aiming_With_Trajectory
using UnityEngine;

public class CannonProjectileSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;
<<<<<<< HEAD
    [SerializeField] private Transform _launchOffSet;

    private Animator _animator;
    private TestEnemyCharacteristics _enemyCharacteristics;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyCharacteristics = GetComponent<TestEnemyCharacteristics>();
    }
=======
>>>>>>> Aiming_With_Trajectory

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
<<<<<<< HEAD
        while (_enemyCharacteristics.IsAlive)
        {
            _animator.SetTrigger("Fire");
            Instantiate(projectilePrefab, _launchOffSet.position, transform.rotation);
=======
        while (true)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
>>>>>>> Aiming_With_Trajectory
            yield return new WaitForSeconds(cooldown);
        }
    }

}
