using UnityEngine;

public class GoldenCoins : CollectibleItem
{
    [SerializeField] private AudioSource collectSound; 

    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.GoldCoins++;
        
            collectSound.Play();
        

        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
