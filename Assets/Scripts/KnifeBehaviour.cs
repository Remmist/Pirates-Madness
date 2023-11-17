using UnityEngine;

public class KnifeBehaviour : CollectibleItem
{
    private static int _knifeCounter;
    
    protected override void CollectBehaviour()
    {
        _knifeCounter++;
        Debug.Log("You have collected " + _knifeCounter + " knives!");
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
