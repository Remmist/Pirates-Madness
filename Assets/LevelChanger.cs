using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private string _levelToLoad;
    private PlayerInventory _inventory;

    private GameObject _player;

    [SerializeField] private SpeedPotionBehaviour speedPotion;
    [SerializeField] private StrengthPotionBehaviour strenghPotion;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inventory = FindObjectOfType<PlayerInventory>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            if (PlayerPrefs.GetString("SavedLevel") == SceneManager.GetActiveScene().name)
            {
                if (PlayerPrefs.GetString("IsSaveLoad") == "true")
                {
                    //Загружаем сейф
                    LoadSave();
                }
            }
        }
        
        if (PlayerPrefs.HasKey("Diamonds"))
        {
            _inventory.Diamonds = PlayerPrefs.GetInt("Diamonds");
        }

        if (PlayerPrefs.HasKey("SilverCoins"))
        {
            _inventory.SilverCoins = PlayerPrefs.GetInt("SilverCoins");
        }
    }

    public void FadeToLevel()
    {
        _animator.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        PlayerPrefs.SetString("LevelComplete", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("SilverCoins", _inventory.SilverCoins);
        PlayerPrefs.SetInt("Diamonds", _inventory.Diamonds);
        
        
        PlayerPrefs.DeleteKey("SavedLevel");
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        
        PlayerPrefs.DeleteKey("Speed1");
        PlayerPrefs.DeleteKey("Strenght1");
        PlayerPrefs.DeleteKey("Speed2");
        PlayerPrefs.DeleteKey("Strenght2");
        
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");

        PlayerPrefs.DeleteKey("Health");
        
        PlayerPrefs.DeleteKey("Daggers");
        PlayerPrefs.DeleteKey("GoldCoins");
        PlayerPrefs.DeleteKey("Keys");
        
        SceneManager.LoadScene(_levelToLoad);
    }

    public void LoadSave()
    {
        _player.transform.position =  new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));
        _player.GetComponent<PlayerCharacteristics>().CurrentHealth = PlayerPrefs.GetFloat("Health");

        _inventory.SilverCoins = PlayerPrefs.GetInt("SilverCoins");
        _inventory.Diamonds = PlayerPrefs.GetInt("Diamonds");
        _inventory.DaggersCounter = PlayerPrefs.GetInt("Daggers");
        _inventory.GoldCoins = PlayerPrefs.GetInt("GoldCoins");
        _inventory.KeysCollected = PlayerPrefs.GetInt("Keys");

        if (PlayerPrefs.HasKey("Speed1"))
        {
            _inventory.AddToInventory(speedPotion);
        } 
        else if(PlayerPrefs.HasKey("Strenght1"))
        {
            _inventory.AddToInventory(strenghPotion);
        }
                    
        if (PlayerPrefs.HasKey("Speed2"))
        {
            _inventory.AddToInventory(speedPotion);
        }
        else if (PlayerPrefs.HasKey("Strenght2"))
        {
            _inventory.AddToInventory(strenghPotion);
        }
        PlayerPrefs.SetString("IsSaveLoad", "false");
    }
}
