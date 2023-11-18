using UnityEngine;
using UnityEngine.UI;

public class EnemyHealtBar : MonoBehaviour
{
    
    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameObject _canvas;
    private TestEnemyCharacteristics _enemyCharacteristics;

    private void Awake()
    {
        _enemyCharacteristics = GetComponent<TestEnemyCharacteristics>();
    }

    private void Start()
    {
        _healthBar.maxValue = _enemyCharacteristics.MaxHealth;
    }

    private void Update()
    {
        _healthBar.value = _enemyCharacteristics.CurrentHealth;
    }

    public void Die()
    {
        _canvas.SetActive(false);
    }
}
