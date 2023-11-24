using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueCanvas;
    [SerializeField] private string[] _lines;

    private bool _IsActivated;
    [SerializeField] private bool _isFinal;

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
        if (_isFinal)
        {
            _dialogueCanvas.GetComponent<DialogueManager>().Final = true;
        }
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
