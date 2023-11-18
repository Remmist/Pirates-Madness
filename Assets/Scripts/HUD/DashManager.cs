using UnityEngine;
using UnityEngine.UI;

public class DashManager : MonoBehaviour
{
    private PlayerMovement _movement;
    [SerializeField] private Image _dashIcon;
    private float _reload;
    private float _max;


    private void Awake()
    {
        _movement = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        _max = _movement.DashCooldown;
        _reload = _max;
        _dashIcon.fillAmount = _max;
    }

    private void Update()
    {
        if (_reload < _max)
        {
            _reload += Time.deltaTime;
            _dashIcon.fillAmount = _reload / _max; 
        }
    }

    public void Reload()
    {
        _reload = 0;
        _dashIcon.fillAmount = 0;
    }

    public void ResetIcon()
    {
        _dashIcon.fillAmount = 0;
    }
    
    
}
