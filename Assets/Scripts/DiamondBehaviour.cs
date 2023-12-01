using UnityEngine;

public class DiamondBehaviour : CollectibleItem
{
    
    [SerializeField] private GameObject effect;
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.Diamonds++;
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
