using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Speed Potion config", fileName = "Speed Potion config")]
public class SpeedPotionConfig : ScriptableObject
{
    [TextArea]
    public string Description;
    public Sprite UISprite;

    public int SpeedAmount;
    public int Duration;
}
