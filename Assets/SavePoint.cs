using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{

    private bool _activated;
    private GameObject _player;
    [SerializeField] private GameObject text;

    private void Start()
    {
        text.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (!_activated && other.collider.tag == "Player")
    //     {
    //         _activated = true;
    //         SaveProgress();
    //         Debug.Log("Successful save");
    //     }
    // }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_activated && other.tag == "Player")
        {
            _activated = true;
            SaveProgress();
            StartCoroutine(ShowSave());
        }
    }

    private IEnumerator ShowSave()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetString("SavedLevel", SceneManager.GetActiveScene().name);
            var inventory = _player.GetComponent<PlayerInventory>();
            
            PlayerPrefs.SetInt("SilverCoins", inventory.SilverCoins);
            PlayerPrefs.SetInt("Diamonds", inventory.Diamonds);
            
            PlayerPrefs.SetInt("Daggers", inventory.DaggersCounter);
            PlayerPrefs.SetInt("GoldCoins", inventory.GoldCoins);
            PlayerPrefs.SetInt("Keys", inventory.KeysCollected);

            if (inventory.Items.Count == 2)
            {
                if (inventory.Items.ElementAt(0).GetType() == typeof(SpeedPotionBehaviour))
                {
                    PlayerPrefs.SetInt("Speed1", 1);
                    PlayerPrefs.DeleteKey("Strenght1");
                }
                else
                {
                    PlayerPrefs.SetInt("Strenght1", 1);
                    PlayerPrefs.DeleteKey("Speed1");
                }
                
                if (inventory.Items.ElementAt(1).GetType() == typeof(SpeedPotionBehaviour))
                {
                    PlayerPrefs.SetInt("Speed2", 1);
                    PlayerPrefs.DeleteKey("Strenght2");
                }
                else
                {
                    PlayerPrefs.SetInt("Strenght2", 1);
                    PlayerPrefs.DeleteKey("Speed2");
                }
            }
            else if (inventory.Items.Count == 1)
            {
                if (inventory.Items.ElementAt(0).GetType() == typeof(SpeedPotionBehaviour))
                {
                    PlayerPrefs.SetInt("Speed1", 1);
                    PlayerPrefs.DeleteKey("Strenght1");
                }
                else
                {
                    PlayerPrefs.SetInt("Strenght1", 1);
                    PlayerPrefs.DeleteKey("Speed1");
                }
                PlayerPrefs.DeleteKey("Speed2");
                PlayerPrefs.DeleteKey("Strenght2");
            }
            else
            {
                PlayerPrefs.DeleteKey("Speed1");
                PlayerPrefs.DeleteKey("Strenght1");
                
                PlayerPrefs.DeleteKey("Speed2");
                PlayerPrefs.DeleteKey("Strenght2");
            }
            
            PlayerPrefs.SetFloat("Health", _player.GetComponent<PlayerCharacteristics>().CurrentHealth);
            
            PlayerPrefs.SetFloat("PosX", _player.transform.position.x);
            PlayerPrefs.SetFloat("PosY", _player.transform.position.y);
    }
}
