using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _keysCollected;
    private Queue<CollectibleItem> _items = new Queue<CollectibleItem>();
    
    [SerializeField] private SpeedPotionConfig _speedPotionConfig;
    [SerializeField] private StrengthPotionConfig _strengthPotionConfig;

    private PlayerCharacteristics _playerCharacteristics;
    private PlayerMovement _playerMovement;

    private PotionsBarsManager _potionsBarsManager;


    private void Awake()
    {
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerMovement = GetComponent<PlayerMovement>();
        _potionsBarsManager = FindObjectOfType<PotionsBarsManager>();
    }

    public void AddToInventory(CollectibleItem item)
    {
        _items.Enqueue(item);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_items.Count == 1)
            {
                UseSlot(0);
            }
            else
            {
                UseSlot(1);
            }
        }
    }

    private void UseSlot(int pos)
    {
        if (_items.Count == 0)
        {
            Debug.Log("Your inventory is empty");
            return;
        }

        
        if (_items.ElementAt(pos).GetType() == typeof(SpeedPotionBehaviour))
        {
            if (_playerMovement.IsSpeedEffect)
            {
                Debug.Log("Cant use speed potion - effect already on");
                return;
            }
        }
        else
        {
            if (_playerCharacteristics.IsStrengthEffect)
            {
                Debug.Log("Cant use strength potion - effect already on");
                return;
            }
        }

        Type tip = _items.ElementAt(pos).GetType();

        if (pos == 0)
        { 
            _items.Dequeue().UseItem();

            if (tip == typeof(SpeedPotionBehaviour))
            {
                if (_playerCharacteristics.IsStrengthEffect)
                {
                    _potionsBarsManager.ActivateSpeed("second", _speedPotionConfig.Duration);
                }
                else
                {
                    _potionsBarsManager.ActivateSpeed("first", _speedPotionConfig.Duration);
                }
            }
            else
            {
                if (_playerMovement.IsSpeedEffect)
                {
                    _potionsBarsManager.ActivateStrenght("second", _strengthPotionConfig.Duration);
                }
                else
                {
                    _potionsBarsManager.ActivateStrenght("first", _strengthPotionConfig.Duration);
                }
            }
                
        }
        else
        {
            var tmpItem = _items.Dequeue();
            _items.Dequeue().UseItem();
            _items.Enqueue(tmpItem);
            
            if (tip == typeof(SpeedPotionBehaviour))
            {
                if (_playerCharacteristics.IsStrengthEffect)
                {
                    _potionsBarsManager.ActivateSpeed("second", _speedPotionConfig.Duration);
                }
                else
                {
                    _potionsBarsManager.ActivateSpeed("first", _speedPotionConfig.Duration);
                }
            }
            else
            {
                if (_playerMovement.IsSpeedEffect)
                {
                    _potionsBarsManager.ActivateStrenght("second", _strengthPotionConfig.Duration);
                }
                else
                {
                    _potionsBarsManager.ActivateStrenght("first", _strengthPotionConfig.Duration);
                }
            }
        }
    }


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

    public Queue<CollectibleItem> Items => _items;
}
