using UnityEngine;

public enum AttackType
{
    Kick, Punch
}

[CreateAssetMenu(fileName = "Item", menuName ="Item/item")]
public class Item : ScriptableObject
{
    public int attack;
    public int rate;
    public AttackType attackType;
}
