using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Attack")]
public class AttackData : ScriptableObject
{
    public AttackTypeID type;
    public int baseDamage;
    [Range(0f,1f)]
    public float hitChance;
}
