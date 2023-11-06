using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Health Potion config", fileName = "Health Potion config")]
public class HealthPotionConfig : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    public Sprite UISprite;

    public int HealAmount;
}
