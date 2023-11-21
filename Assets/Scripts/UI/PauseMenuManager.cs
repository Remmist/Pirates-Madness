using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _goldCoins;
    [SerializeField] private GameObject _silverCoins;
    [SerializeField] private GameObject _diamonds;
    [SerializeField] private GameObject _keys;
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
        //TODO
    }
    
}
