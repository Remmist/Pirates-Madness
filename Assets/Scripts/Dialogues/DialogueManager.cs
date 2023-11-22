using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueCanvas;
    [SerializeField] private TMP_Text _textComponent;
    [SerializeField] private float _textSpeed;
    
    [SerializeField] private string[] _lines;

    private int _index;
    private bool _isEnded;

    private void Start()
    {
        _textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textComponent.text == _lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _textComponent.text = _lines[_index];
            }
        }
    }

    public void StartDialogue()
    {
        if (_isEnded)
        {
            _index = _lines.Length - 1;
        }
        else
        {
            _index = 0;
        }
        StartCoroutine(TypeLine());
    }

    public void ClearText()
    {
        _textComponent.text = string.Empty;
    }

    private IEnumerator TypeLine()
    {
        var chars = _lines[_index].ToCharArray();
        foreach (char c in chars)
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void NextLine()
    {
        if (_index < _lines.Length - 1)
        {
            _index++;
            _textComponent.text = string.Empty;
            if (_index == _lines.Length - 1)
            {
                _isEnded = true;
            }
            StartCoroutine(TypeLine());
        }
        else
        {
            _isEnded = true;
            _textComponent.text = string.Empty;
            _dialogueCanvas.SetActive(false);
        }
    }
}
