using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotionBehaviour : CollectibleItem
{
    [SerializeField] private StrengthPotionConfig _strengthPotionConfig;
    [SerializeField] private GameObject effect;
    
    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();

        if (inventory.Items.Count >= 2)
        {
            Debug.Log("Cant collect - already 2 item in inventory");
            return;
        }

        inventory.AddToInventory(this);

        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(effect, transform.position, Quaternion.identity);
    }
    
    
    
    public override void UseItem()
    {
        StartCoroutine(PotionEffect());
    }


    private IEnumerator PotionEffect()
    {
        var playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();
        playerCharacteristics.IncreaseStrength(_strengthPotionConfig.StrengthAmount);
        yield return new WaitForSeconds(_strengthPotionConfig.Duration);
        playerCharacteristics.ReturnStrength();
        Destroy(gameObject);
    }
}
