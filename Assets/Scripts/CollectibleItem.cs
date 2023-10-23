using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{

    protected virtual void CollectBehaviour() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectBehaviour();
            Destroy(gameObject);
        }
    }
}
