using System;
using UnityEngine;
public class SilverCoinBehaviour : CollectibleItem
{
    
    [SerializeField] private GameObject effect;
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.SilverCoins++;
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
