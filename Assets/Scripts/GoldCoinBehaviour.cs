using UnityEngine;

public class GoldenCoins : CollectibleItem
{
    [SerializeField] private GameObject effect;
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.GoldCoins++;
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
