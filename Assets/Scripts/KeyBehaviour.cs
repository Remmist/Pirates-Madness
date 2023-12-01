using UnityEngine;

public class KeyBehaviour : CollectibleItem
{
    
    [SerializeField] private GameObject effect;
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.KeysCollected++;
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
