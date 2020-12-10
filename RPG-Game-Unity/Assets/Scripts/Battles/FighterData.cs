using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Fighter")]
public class FighterData : CharacterData
{
    public int baseHealth = 100;

    public List<SkillData> skills;
}
