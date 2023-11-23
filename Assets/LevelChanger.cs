using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private string _levelToLoad;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        _animator.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
