using System;
using UnityEngine;
public class SilverCoinBehaviour : CollectibleItem
{
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();

        inventory.SilverCoins++;
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
