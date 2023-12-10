using UnityEngine;

public class KnifeBehaviour : CollectibleItem
{
    [SerializeField] private AudioSource _audioPickUp;
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();

        if (inventory.DaggersCounter >= 3)
        {
            return;
        }
        
        inventory.DaggersCounter++;
        Destroy(gameObject);
        _audioPickUp.Play();
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}