using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerThrowProjectiles : PlayerProjectile
{
    //Variables for how the projectiles act when shoot by the player
    [SerializeField] private GameObject _playerProjectilePrefab;
    [SerializeField] private Transform _launchOffSet;
    //[SerializeField] private TrajectoryRenderer _trajectoryRenderer;

    private void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            //_trajectoryRenderer.InitializeTrajectory(_launchOffSet.position, shootingDirection, _shootSpeed);
            //_trajectoryRenderer.ShowTrajectory();        
        }
        
        if (Input.GetButtonUp("Fire2"))
        {
            //_trajectoryRenderer.HideTrajectory();
            
            var position = _launchOffSet.position;
            GameObject projectile = Instantiate(_playerProjectilePrefab, position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            
        }
        
    }
    
}
