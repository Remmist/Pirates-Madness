using UnityEngine;

public class GoldenCoins : CollectibleItem
{
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        var counter = FindObjectOfType<GoldCoinManager>();
        inventory.GoldCoins++;
        counter.UpdateCounter(inventory.GoldCoins);
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
