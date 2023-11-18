using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMaster : MonoBehaviour
{
    private static SaveMaster instance;
    public Vector2 lastCheckPointPos;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(gameObject);
        }

    }
}



        

        

