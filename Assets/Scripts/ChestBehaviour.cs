using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : CollectibleItem
{
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = FindObjectOfType<PlayerInventory>();
    }

    protected override void CollectBehaviour()
    {
        if (_playerInventory != null && _playerInventory.HasKeys())
        {
            _playerInventory.KeysCollected--;
            Debug.Log("You have opened the chest!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need a key to open this chest.");
        }
    }
}
