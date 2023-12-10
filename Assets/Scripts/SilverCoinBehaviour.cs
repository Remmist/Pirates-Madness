using System;
using UnityEngine;
public class SilverCoinBehaviour : CollectibleItem
{
    [SerializeField] private AudioSource _collectSound; 
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.SilverCoins++;
        if (_collectSound != null)
        {
            if (!_collectSound.isPlaying)
            {
                Debug.Log("Playing collect sound");
                _collectSound.Play();
            }
            else
            {
                Debug.LogWarning("Collect sound is already playing");
            }
        }
        else
        {
            Debug.LogWarning("Collect sound is not assigned");
        }

        Destroy(gameObject);
      
    }

    public override void UseItem()
    {
     
        throw new NotImplementedException();
    }
}
