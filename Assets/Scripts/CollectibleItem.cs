using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CollectibleItem : MonoBehaviour
{

    protected abstract void CollectBehaviour();

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollectBehaviour();
    }
}
