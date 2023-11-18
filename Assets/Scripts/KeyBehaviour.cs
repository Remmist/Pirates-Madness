using UnityEngine;

public class KeyBehaviour : CollectibleItem
{
    
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = FindObjectOfType<PlayerInventory>();
    }
    
    protected override void CollectBehaviour()
    {
        _playerInventory.AddKeys();
        Debug.Log("You have found a key. Maybe there is a chest around!");
        Destroy(gameObject);

    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
