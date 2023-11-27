using UnityEngine;

public class GoldenCoins : CollectibleItem
{
    [SerializeField] private AudioSource collectSound; // Поле для AudioSource

    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.GoldCoins++;

        // Проверяем, есть ли AudioSource, и воспроизводим звук сбора
        if (collectSound != null)
        {
            collectSound.Play();
        }

        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
