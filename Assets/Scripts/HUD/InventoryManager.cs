using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private PlayerInventory _inventory;

    [SerializeField] private GameObject _speedQ;
    [SerializeField] private GameObject _speedE;
    [SerializeField] private GameObject _strenghtQ;
    [SerializeField] private GameObject _strenghtE;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
        _speedQ.SetActive(false);
        _speedE.SetActive(false);
        _strenghtQ.SetActive(false);
        _strenghtE.SetActive(false);
    }

    private void Start()
    {
        _speedQ.SetActive(false);
        _speedE.SetActive(false);
        _strenghtQ.SetActive(false);
        _strenghtE.SetActive(false);
    }

    private void Update()
    {
        if (_inventory.Items.Count == 0)
        {
            _speedQ.SetActive(false);
            _speedE.SetActive(false);
            _strenghtQ.SetActive(false);
            _strenghtE.SetActive(false);
            return;
        }

        if (_inventory.Items.Count == 1)
        {
            if (_inventory.Items.ElementAt(0).GetType() == typeof(SpeedPotionBehaviour))
            {
                _speedQ.SetActive(true);
                _strenghtQ.SetActive(false);
            }
            else
            {
                _strenghtQ.SetActive(true);
                _speedQ.SetActive(false);
            }
            _speedE.SetActive(false);
            _strenghtE.SetActive(false);
            return;
        }

        if (_inventory.Items.Count == 2)
        {
            if (_inventory.Items.ElementAt(0).GetType() == typeof(SpeedPotionBehaviour))
            {
                _speedQ.SetActive(true);
                _strenghtQ.SetActive(false);

                if (_inventory.Items.ElementAt(1).GetType() == typeof(SpeedPotionBehaviour))
                {
                    _speedE.SetActive(true);
                    _strenghtE.SetActive(false);
                }
                else
                {
                    _speedE.SetActive(false);
                    _strenghtE.SetActive(true);
                }
            }
            else
            {
                _strenghtQ.SetActive(true);
                _speedQ.SetActive(false);
                
                if (_inventory.Items.ElementAt(1).GetType() == typeof(SpeedPotionBehaviour))
                {
                    _speedE.SetActive(true);
                    _strenghtE.SetActive(false);
                }
                else
                {
                    _speedE.SetActive(false);
                    _strenghtE.SetActive(true);
                }
                
            }
            
        }
    }
    
    
}
