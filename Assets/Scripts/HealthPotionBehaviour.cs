using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionBehaviour : CollectibleItem
{
    [SerializeField] private float _healthAdded;

    protected override void CollectBehaviour()
    {

        var playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();

        if (playerCharacteristics == null) return;
        playerCharacteristics.CurrentHealth += _healthAdded;
        Debug.Log("You have found a health potion! " + _healthAdded + " health points for You!");

    }
}
