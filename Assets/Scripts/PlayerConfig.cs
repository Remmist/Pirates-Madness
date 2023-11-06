using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Config", fileName = "Player config")]

public class PlayerConfig : ScriptableObject
{
    public int BaseHealth = 50;
    public int MaxHealth = 100;
    public int BaseDamage = 10;
    public int MaxDamage = 20;
    public int BaseSpeed = 5;
    public int MaxSpeed = 10;
}
