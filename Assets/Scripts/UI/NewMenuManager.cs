#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class NewMenuManager : MonoBehaviour {
        [SerializeField] private GameObject _mainView;
        [SerializeField] private GameObject _levelsView;
        [SerializeField] private GameObject _settingsView;
        [SerializeField] private GameObject _creditsView;

        private void Awake() {
            _mainView.SetActive(true);
            _levelsView.SetActive(false);
            _settingsView.SetActive(false);
            _creditsView.SetActive(false);
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