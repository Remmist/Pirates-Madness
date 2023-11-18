using System;
using UnityEngine;

public class ChestBehaviour : CollectibleItem
{
    private PlayerInventory _playerInventory;
    private Animator _animator;
    private bool _isOpend;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerInventory = FindObjectOfType<PlayerInventory>();
    }

    protected override void CollectBehaviour()
    {
        if (_isOpend)
        {
            return;
        }
        if (_playerInventory != null && _playerInventory.HasKeys() && !_isOpend)
        {
            _playerInventory.KeysCollected--;
            Debug.Log("You have opened the chest!");
            _animator.SetTrigger("Unlock");
            _isOpend = true;
        }
        else
        {
            Debug.Log("You need a key to open this chest.");
        }
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
