using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotionBehaviour : CollectibleItem
{

    [SerializeField] private float _speedAdded;
    
    protected override void CollectBehaviour()
    {
        var playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement == null) return;
        playerMovement.CurrentPlayerSpeed += _speedAdded;
        Debug.Log("You have found a speed potion!  Now You are much faster!");
    }
}
