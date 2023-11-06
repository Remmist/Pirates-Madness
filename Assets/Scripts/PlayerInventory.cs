using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _keysCollected;

    public void AddKeys()
    {
        _keysCollected++;
    }

    public bool HasKeys()
    {
        return _keysCollected > 0;
    }
    
    public int KeysCollected
    {
        get => _keysCollected;
        set => _keysCollected = value;
    }
    
}
