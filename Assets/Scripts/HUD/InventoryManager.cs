using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private PlayerInventory _inventory;

    [SerializeField] private GameObject _speedQ;
    [SerializeField] private GameObject _speedE;
    [SerializeField] private GameObject _strenghtQ;
    [SerializeField] private GameObject _strenghtE;

    [SerializeField] private GameObject _oneDagger;
    [SerializeField] private GameObject _twoDagger;
    [SerializeField] private GameObject _threeDagger;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
        _speedQ.SetActive(false);
        _speedE.SetActive(false);
        _strenghtQ.SetActive(false);
        _strenghtE.SetActive(false);
        
        _oneDagger.SetActive(false);
        _twoDagger.SetActive(false);
        _threeDagger.SetActive(false);
    }

    private void Start()
    {
        _speedQ.SetActive(false);
        _speedE.SetActive(false);
        _strenghtQ.SetActive(false);
        _strenghtE.SetActive(false);
        
        _oneDagger.SetActive(false);
        _twoDagger.SetActive(false);
        _threeDagger.SetActive(false);
    }

    private void Update()
    {
        if (_inventory.DaggersCounter == 0)
        {
            _oneDagger.SetActive(false);
            _twoDagger.SetActive(false);
            _threeDagger.SetActive(false);
        }
        else if (_inventory.DaggersCounter == 1)
        {
            _oneDagger.SetActive(true);
            _twoDagger.SetActive(false);
            _threeDagger.SetActive(false);
        }
        else if (_inventory.DaggersCounter == 2)
        {
            _oneDagger.SetActive(false);
            _twoDagger.SetActive(true);
            _threeDagger.SetActive(false);
        }
        else if (_inventory.DaggersCounter == 3)
        {
            _oneDagger.SetActive(false);
            _twoDagger.SetActive(false);
            _threeDagger.SetActive(true);
        }
        
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
                // _strenghtQ.SetActive(true);
                // _speedQ.SetActive(false);
            }
            else
            {
                // _speedQ.SetActive(true);
                // _strenghtQ.SetActive(false);
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
                // _speedQ.SetActive(false);
                // _strenghtQ.SetActive(true);

                if (_inventory.Items.ElementAt(1).GetType() == typeof(SpeedPotionBehaviour))
                {
                    _speedE.SetActive(true);
                    _strenghtE.SetActive(false);
                    
                    // _speedE.SetActive(false);
                    // _strenghtE.SetActive(true);
                }
                else
                {
                    _speedE.SetActive(false);
                    _strenghtE.SetActive(true);
                    // _speedE.SetActive(true);
                    // _strenghtE.SetActive(false);
                }
            }
            else
            {
                _strenghtQ.SetActive(true);
                _speedQ.SetActive(false);
                // _strenghtQ.SetActive(false);
                // _speedQ.SetActive(true);
                
                if (_inventory.Items.ElementAt(1).GetType() == typeof(SpeedPotionBehaviour))
                {
                    // _speedE.SetActive(false);
                    // _strenghtE.SetActive(true);
                    
                    _speedE.SetActive(true);
                    _strenghtE.SetActive(false);
                }
                else
                {
                    // _speedE.SetActive(true);
                    // _strenghtE.SetActive(false);
                    
                    _speedE.SetActive(false);
                    _strenghtE.SetActive(true);
                }
                
            }
            
        }
    }
    
    
}
