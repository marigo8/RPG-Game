using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Attack")]
public class AttackData : ScriptableObject
{
    public string attackName;
    public GameObject prefab;
    public int staminaCost;
}
