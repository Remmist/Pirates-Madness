using System;
using UnityEngine;
public class SilverCoinBehaviour : CollectibleItem
{
    
    private static int _silverCoinCounter;
    
    protected override void CollectBehaviour()
    {
        _silverCoinCounter++;
        Debug.Log("You have collected " + _silverCoinCounter + " silver coins!");
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
