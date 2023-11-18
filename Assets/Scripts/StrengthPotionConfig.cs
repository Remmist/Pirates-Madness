using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Strength Potion config", fileName = "Strength Potion config")]
public class StrengthPotionConfig : ScriptableObject
{
    [TextArea]
    public string Description;
    public Sprite UISprite;
    
    public int StrengthAmount;
    public int Duration;
}
