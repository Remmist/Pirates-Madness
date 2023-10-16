using System.Collections;
using UnityEngine;

public class CannonProjectileSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(cooldown);
        }
    }

}
