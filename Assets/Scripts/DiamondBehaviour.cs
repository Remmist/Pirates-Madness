using UnityEngine;

public class DiamondBehaviour : CollectibleItem
{

    private static int _diamondCounter;
    
    protected override void CollectBehaviour()
    {
        _diamondCounter++;
        Debug.Log("Congratulations! You have collected " + _diamondCounter + " diamonds!");
        Destroy(gameObject);
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
