using System;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    private PlayerCharacteristics _playerCharacteristics;

    private void Awake()
    {
        _playerCharacteristics = FindObjectOfType<PlayerCharacteristics>();
    }

    private void Start()
    {
        _healthBar.value = _playerCharacteristics.CurrentHealth;
    }

    private void Update()
    {
        _healthBar.value = _playerCharacteristics.CurrentHealth;
    }
}
