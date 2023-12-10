using System;
using UnityEngine;

public class HealthPotionBehaviour : CollectibleItem
{
    [SerializeField] private HealthPotionConfig _healthPotionConfig;
    [SerializeField] private AudioSource _useIt;
protected override void CollectBehaviour()
    {
        var playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();

        if (playerCharacteristics.CurrentHealth == playerCharacteristics.PlayerConfig.MaxHealth)
        {
            
            return;
        }
        playerCharacteristics.Heal(_healthPotionConfig.HealAmount);
        Debug.Log("You have found a health potion! " + _healthPotionConfig.HealAmount + " health points for You!");
        _useIt.Play();
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
