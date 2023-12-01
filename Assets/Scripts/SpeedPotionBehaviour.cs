using System.Collections;
using UnityEngine;

public class SpeedPotionBehaviour : CollectibleItem
{
    
    [SerializeField] private SpeedPotionConfig _speedPotionConfig;
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
        var playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.IncreaseSpeed(_speedPotionConfig.SpeedAmount);
        yield return new WaitForSeconds(_speedPotionConfig.Duration);
        playerMovement.ReturnSpeed();
        Destroy(gameObject);
    }
    
}
