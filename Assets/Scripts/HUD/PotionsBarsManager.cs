using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PotionsBarsManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _speedFirst;
    [SerializeField] private GameObject _speedSecond;
    [SerializeField] private GameObject _strenghtFirst;
    [SerializeField] private GameObject _strenghtSecond;

    [SerializeField] private Slider _speedFirstSlider;
    [SerializeField] private Slider _speedSecondSlider;
    [SerializeField] private Slider _strenghtFirstSlider;
    [SerializeField] private Slider _strenghtSecondSlider;

    private float _speedRemaining = 0;
    private float _strenghtRemaining = 0;
    

    private bool _isSpeed;
    private bool _isStrength;
    
    
    private void Awake()
    {
        _speedFirst.SetActive(false);
        _speedSecond.SetActive(false);
        
        _strenghtFirst.SetActive(false);
        _strenghtSecond.SetActive(false);
    }
    
    private void Update()
    {
        if (_speedRemaining > 0)
        {
            _speedFirstSlider.value = _speedRemaining;
            _speedSecondSlider.value = _speedRemaining;
            _speedRemaining -= Time.deltaTime;
        }
        else
        {
            _speedFirst.SetActive(false);
            _speedSecond.SetActive(false);
        }
        
        if (_strenghtRemaining > -0)
        {
            _strenghtFirstSlider.value = _strenghtRemaining;
            _strenghtSecondSlider.value = _strenghtRemaining;
            _strenghtRemaining -= Time.deltaTime;
        }
        else
        {
            _strenghtFirst.SetActive(false);
            _strenghtSecond.SetActive(false);
        }

        if (_speedSecond.activeInHierarchy && !_strenghtFirst.activeInHierarchy)
        {
            _speedSecond.SetActive(false);
            _speedFirst.SetActive(true);
        }
        else if (_strenghtSecond.activeInHierarchy && !_speedFirst.activeInHierarchy)
        {
            _strenghtSecond.SetActive(false);
            _strenghtFirst.SetActive(true);
        }
    }

    public void ActivateSpeed(string position, float duration)
    {
        _speedFirstSlider.maxValue = duration;
        _speedSecondSlider.maxValue = duration;
        
        if (position == "first")
        {
            _speedFirst.SetActive(true);
        }
        else
        {
            _speedSecond.SetActive(true);
        }

        _speedRemaining = duration;
    }
    
    public void ActivateStrenght(string position, float duration)
    {
        _strenghtFirstSlider.maxValue = duration;
        _strenghtSecondSlider.maxValue = duration;
        
        if (position == "first")
        {
            _strenghtFirst.SetActive(true);
        }
        else
        {
            _strenghtSecond.SetActive(true);
        }

        _strenghtRemaining = duration;
    }

    
    
}
