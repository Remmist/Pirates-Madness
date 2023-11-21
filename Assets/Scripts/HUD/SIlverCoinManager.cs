using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SIlverCoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;
    private PlayerInventory _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
    }


    private void Update()
    {
        _counter.text = $"{_inventory.SilverCoins}";
    }
}
