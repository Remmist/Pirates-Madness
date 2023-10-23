using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
public class SilverCoinBehaviour : CollectibleItem
{
    
    private static int _silverCoinCounter;
    
    protected override void CollectBehaviour()
    {
        _silverCoinCounter++;
        Debug.Log("You have collected " + _silverCoinCounter + " silver coins!");
    }
    
}
