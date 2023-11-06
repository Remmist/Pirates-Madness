using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionBehaviour : CollectibleItem
{
    [SerializeField] private HealthPotionConfig _healthPotionConfig;

    protected override void CollectBehaviour()
    {

        var playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();
        
        playerCharacteristics.Heal(_healthPotionConfig.HealAmount);
        Debug.Log("You have found a health potion! " + _healthPotionConfig.HealAmount + " health points for You!");
        Destroy(gameObject);
    }
}
