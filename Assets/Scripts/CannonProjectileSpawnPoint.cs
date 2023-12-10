 using System.Collections;
using UnityEngine;

public class CannonProjectileSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private Transform _launchOffSet;
    [SerializeField] private AudioSource _audioSource;

    private Animator _animator;
    private TestEnemyCharacteristics _enemyCharacteristics;
    private Renderer _renderer;
    private bool _wasVisible = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyCharacteristics = GetComponent<TestEnemyCharacteristics>();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        while (_enemyCharacteristics.IsAlive)
        {
            bool isVisible = _renderer.isVisible;

            if (isVisible && !_wasVisible)
            {
                _audioSource.Play();
                _animator.SetTrigger("Fire");
            }

            _wasVisible = isVisible;

            Instantiate(projectilePrefab, _launchOffSet.position, transform.rotation);
            yield return new WaitForSeconds(cooldown);
        }
    }
}