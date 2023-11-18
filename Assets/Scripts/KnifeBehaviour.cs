using UnityEngine;

public class KnifeBehaviour : CollectibleItem
{
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();

        if (inventory.DaggersCounter >= 3)
        {
            return;
        }
        
        inventory.DaggersCounter++;
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
