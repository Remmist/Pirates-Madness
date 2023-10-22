using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : CollectibleItem
{
    private static int _knifeCounter;
    
    protected override void CollectBehaviour()
    {
        _knifeCounter++;
        Debug.Log("You have collected " + _knifeCounter + " knives!");
    }
}
