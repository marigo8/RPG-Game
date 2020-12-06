using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BattleData : ScriptableObject
{
    public List<CharacterData> playerFighters = new List<CharacterData>(5), enemyFighters = new List<CharacterData>(5);
}
