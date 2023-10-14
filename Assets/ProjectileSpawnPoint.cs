using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    private void Start()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

}
