using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : ScriptableObject
{
    public string attackName;
    public GameObject prefab;
    public int turnCooldown;
    public int magicCost;
}
