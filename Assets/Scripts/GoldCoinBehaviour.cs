using System.Collections;
using System.Collections.Generic;
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
}
