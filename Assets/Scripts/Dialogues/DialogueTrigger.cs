using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueCanvas;

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
        _dialogueCanvas.SetActive(true);
        _dialogueCanvas.GetComponent<DialogueManager>().StartDialogue();
    }
}
