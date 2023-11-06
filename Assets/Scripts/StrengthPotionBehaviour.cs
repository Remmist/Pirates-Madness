using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotionBehaviour : CollectibleItem
{
    [SerializeField] private StrengthPotionConfig _strengthPotionConfig;
    
    protected override void CollectBehaviour()
    {
        var playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();
        
        playerCharacteristics.IncreaseStrength(_strengthPotionConfig.StrengthAmount);
        Debug.Log("You have found a strength potion! Now You hit much harder!");
        Destroy(gameObject);
    }
}
