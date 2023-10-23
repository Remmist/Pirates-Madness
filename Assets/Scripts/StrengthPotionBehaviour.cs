using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotionBehaviour : CollectibleItem
{

    [SerializeField] private float _damageAdded;
    
    protected override void CollectBehaviour()
    {
        var playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();

        if (playerCharacteristics == null) return;
        playerCharacteristics.Damage += _damageAdded;
        Debug.Log("You have found a strength potion! Now You hit much harder!");
    }
}
