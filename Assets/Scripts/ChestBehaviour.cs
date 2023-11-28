using System;
using UnityEngine;

public class ChestBehaviour : CollectibleItem
{
    private PlayerInventory _playerInventory;
    private Animator _animator;
    private bool _isOpened;

    [SerializeField] private GameObject _lifePotionPrefab;
    [SerializeField] private GameObject _strengthPotionPrefab;
    [SerializeField] private GameObject _speedPotionPrefab;
    [SerializeField] private GameObject _stilettoPrefab;
    [SerializeField] private Transform _itemSpawnPoint;
    
    public enum ItemInsideTheChest
    {
        LifePotion,
        StrengthPotion,
        SpeedPotion,
        StilettoKnife
    }

    [SerializeField] private ItemInsideTheChest _itemInsideTheChest;

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
        if (_isOpened)
        {
            return;
        }
        if (_playerInventory != null && _playerInventory.HasKeys() && !_isOpened)
        {
            _playerInventory.KeysCollected--;
            Debug.Log("You have opened the chest!");
            _animator.SetTrigger("Unlock");
            _isOpened = true;
            ThrowHiddenItemWhenChestOpens();
        }
        else
        {
            Debug.Log("You need a key to open this chest.");
        }
    }

    private void ThrowHiddenItemWhenChestOpens()
    {
        GameObject item = null;

        switch (_itemInsideTheChest)
        {
            case ItemInsideTheChest.LifePotion:
                item = Instantiate(_lifePotionPrefab, _itemSpawnPoint.position, Quaternion.identity);
                break;
            case ItemInsideTheChest.StrengthPotion:
                item = Instantiate(_strengthPotionPrefab, _itemSpawnPoint.position, Quaternion.identity);
                break;
            case ItemInsideTheChest.SpeedPotion:
                item = Instantiate(_speedPotionPrefab, _itemSpawnPoint.position, Quaternion.identity);
                break;
            case ItemInsideTheChest.StilettoKnife:
                item = Instantiate(_stilettoPrefab, _itemSpawnPoint.position, Quaternion.identity);
                break;
        }
        
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
