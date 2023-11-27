using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _health;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _potions;
    [SerializeField] private GameObject _coins;
    [SerializeField] private GameObject _dash;
    
    [SerializeField] private Button loadButton;

    private PlayerCharacteristics _characteristics;


    private void Awake()
    {
        _deathMenu.SetActive(false);
        _characteristics = FindObjectOfType<PlayerCharacteristics>();
    }

    private void Update()
    {
        if (!_characteristics.IsAlive)
        {
            Death();
        }
        
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            if (PlayerPrefs.GetString("SavedLevel") == SceneManager.GetActiveScene().name)
            {
                loadButton.interactable = true;
            }
            else
            {
                loadButton.interactable = false;
            }
        } 
        else
        {
            loadButton.interactable = false;
        }
    }

    private void Death()
    {
        _deathMenu.SetActive(true);
        _health.SetActive(false);
        _inventory.SetActive(false);
        _potions.SetActive(false);
        _coins.SetActive(false);
        _dash.SetActive(false);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("New Menu");
    }

    public void RestartLevel()
    {
        var name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    public void LoadCheckpoint()
    {
        PlayerPrefs.SetString("IsSaveLoad", "true");
        SceneManager.LoadScene(PlayerPrefs.GetString("SavedLevel"));
    }
    
}
