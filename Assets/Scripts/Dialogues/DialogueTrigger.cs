using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueCanvas;
    [SerializeField] private string[] _lines;

    private bool _IsActivated;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _dialogueCanvas.GetComponent<DialogueManager>().ClearText();
            _dialogueCanvas.SetActive(false);
        }
    }

    void TriggerDialogue()
    {
        if (!_IsActivated)
        {
            _dialogueCanvas.GetComponent<DialogueManager>().Lines = _lines;
            _IsActivated = true;
            _dialogueCanvas.GetComponent<DialogueManager>().IsEnded = false;
        }
        _dialogueCanvas.SetActive(true);
        _dialogueCanvas.GetComponent<DialogueManager>().StartDialogue();
    }
}
