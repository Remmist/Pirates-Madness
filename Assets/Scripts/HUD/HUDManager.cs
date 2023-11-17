using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private PlayerInventory _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
    }
    
    
    
    
}
