using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelNexter : MonoBehaviour
{
    [SerializeField] private bool _isFinal;
    [SerializeField] private int _coinsToCollect;
    [SerializeField] private GameObject _buttonCanvas;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private GameObject _dialogueCanvas;

    private PlayerInventory _inventory;
    private DialogueManager _dialogueManager;

    private void Awake()
    {
        _inventory = FindObjectOfType<PlayerInventory>();
        _dialogueManager = _dialogueCanvas.GetComponent<DialogueManager>();
    }

    private void Start()
    {
        _buttonCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_isFinal)
        {
            if (_dialogueManager.IsEnded && _dialogueManager.Final)
            {
                _buttonCanvas.SetActive(true);
                if (_coinsToCollect <= _inventory.GoldCoins)
                {
                    _button.interactable = true;
                    _text.text = $"Give {_coinsToCollect} coins";
                }
                else
                {
                    _button.interactable = false;
                    _text.text = "Not enough coins";
                }
            }
        }
    }
    
    
    
    
}
