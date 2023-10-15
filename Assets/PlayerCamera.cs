using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 offset;  

    void Awake () 
    {        
        offset = transform.position - _player.transform.position;
    }

    void Update () 
    {        
        transform.position = _player.transform.position + offset;
    }
    
}
