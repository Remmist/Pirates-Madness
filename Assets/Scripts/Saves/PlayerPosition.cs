using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour {
    private SaveMaster gm;

    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<SaveMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
