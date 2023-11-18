#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class MenuManager : MonoBehaviour {
        [SerializeField] private GameObject _mainView;
        [SerializeField] private GameObject _secondView;

        private void Awake() {
            _mainView.SetActive(true);
            _secondView.SetActive(false);
        }

        #region Main view
        public void StartClicked() {
            _mainView.SetActive(false);
            _secondView.SetActive(true);
        }

        
        public void ExitClicked() {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else 
                Application.Quit();
            #endif
        }
        #endregion

        #region Second view
    
        public void LoadLevel(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

        public void BackClicked() {
            _mainView.SetActive(true);
            _secondView.SetActive(false);
        }
        #endregion
    }
}