using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotionBehaviour : CollectibleItem
{
    
    [SerializeField] private SpeedPotionConfig _speedPotionConfig;
    
    protected override void CollectBehaviour()
    {
        var playerMovement = FindObjectOfType<PlayerMovement>();
        
        playerMovement.IncreaseSpeed(_speedPotionConfig.SpeedAmount);
        Debug.Log("You have found a speed potion!  Now You are much faster!");
        Destroy(gameObject);
    }
}
