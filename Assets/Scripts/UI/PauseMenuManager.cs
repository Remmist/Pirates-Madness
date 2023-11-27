using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _goldCoins;
    [SerializeField] private GameObject _silverCoins;
    [SerializeField] private GameObject _diamonds;
    [SerializeField] private GameObject _keys;

    [SerializeField] private Button loadButton;
    private bool _isPaused;

    private void Awake()
    { 
        _pauseMenu.SetActive(false);
        _goldCoins.SetActive(false);
        _silverCoins.SetActive(false);
        _diamonds.SetActive(false);
        _keys.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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


    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _goldCoins.SetActive(false);
        _silverCoins.SetActive(false);
        _diamonds.SetActive(false);
        _keys.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _goldCoins.SetActive(true);
        _silverCoins.SetActive(true);
        _diamonds.SetActive(true);
        _keys.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("New Menu");
    }

    public void RestartLevel()
    {
        var name = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
    
    public void LoadCheckpoint()
    {
        PlayerPrefs.SetString("IsSaveLoad", "true");
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerPrefs.GetString("SavedLevel"));
    }
    
}
