using TMPro;
using UnityEngine;

public class GoldCoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;
    private PlayerInventory _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
    }


    private void Update()
    {
        _counter.text = $"{_inventory.GoldCoins}";
    }
}
