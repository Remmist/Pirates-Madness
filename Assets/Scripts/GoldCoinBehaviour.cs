using UnityEngine;

public class GoldenCoins : CollectibleItem
{

    private static int _goldCoinCounter;
    
    protected override void CollectBehaviour()
    {
        _goldCoinCounter++;
        Debug.Log("You have collected " + _goldCoinCounter + " gold coins!");
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
