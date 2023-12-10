using UnityEngine;

public class GoldenCoins : CollectibleItem
{
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioSource _audioCoin;
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.GoldCoins++;
        _audioCoin.Play();
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
