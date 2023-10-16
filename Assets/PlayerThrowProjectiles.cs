using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowProjectiles : MonoBehaviour
{
    
    //variables for how the projectiles act when shoot by the player
    public Projectile projectilePrefab;
    public Transform launchOffSet;

    private void Update()
    {
        //condition for firing projectiles (Ctrl as default)
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, launchOffSet.position, launchOffSet.rotation);
        }
    }
}
