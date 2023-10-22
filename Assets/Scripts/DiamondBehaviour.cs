using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehaviour : CollectibleItem
{

    private static int _diamondCounter;
    
    protected override void CollectBehaviour()
    {
        _diamondCounter++;
        Debug.Log("Congratulations! You have collected " + _diamondCounter + " diamonds!");
    }
}
