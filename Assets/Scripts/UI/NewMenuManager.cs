#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {
    public class NewMenuManager : MonoBehaviour {
        [SerializeField] private GameObject _mainView;
        [SerializeField] private GameObject _levelsView;
        [SerializeField] private GameObject _settingsView;
        [SerializeField] private GameObject _creditsView;
        
        [SerializeField] private Button _level2;
        [SerializeField] private Button _level3;
        [SerializeField] private Button _lastSave;

        private string _levelComplete;
        private string _savedLevel;

        private void Awake() {
            _mainView.SetActive(true);
            _levelsView.SetActive(false);
            _settingsView.SetActive(false);
            _creditsView.SetActive(false);
        }

        private void Start()
        {
            _levelComplete = PlayerPrefs.GetString("LevelComplete");
            _level2.interactable = false;
            _level3.interactable = false;
            _lastSave.interactable = false;

            if (PlayerPrefs.HasKey("SavedLevel"))
            {
                _savedLevel = PlayerPrefs.GetString("SavedLevel");
                _lastSave.interactable = true;
            }
            
            switch (_levelComplete)
            {
                case "Level 1":
                    _level2.interactable = true;
                    break;
                case "Level 2":
                    _level2.interactable = true;
                    _level3.interactable = true;
                    break;
            }
        }

        public void DeleteSave()
        {
            PlayerPrefs.DeleteAll();
            _lastSave.interactable = false;
        }

        public void LoadSave()
        {
            PlayerPrefs.SetString("IsSaveLoad", "true");
            SceneManager.LoadScene(_savedLevel);
        }

        #region Main view
        
        public void LevelsClicked() {
            _mainView.SetActive(false);
            _levelsView.SetActive(true);
        }
        
        public void SettingsClicked() {
            //TODO
        }
        
        public void CreditsClicked() {
            _mainView.SetActive(false);
            _creditsView.SetActive(true);
        }
        
        public void ExitClicked() {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else 
                Application.Quit();
            #endif
        }
        #endregion

        #region Levels view
    
        public void LoadLevel(string sceneName) {
            PlayerPrefs.SetString("IsSaveLoad", "false");
            SceneManager.LoadScene(sceneName);
        }

        public void BackClicked() {
            _mainView.SetActive(true);
            _levelsView.SetActive(false);
        }
        #endregion
        
        #region Settings view
        //TODO: make settings
        #endregion
        
        #region Credits view

        public void CreditsBackClicked() {
            _mainView.SetActive(true);
            _creditsView.SetActive(false);
        }
        #endregion
        
    }
}