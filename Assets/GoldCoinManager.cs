using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;


    public void UpdateCounter(int i)
    {
        _counter.text = $"{i}";
    }
}
