using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/Character")]
public class CharacterData : ScriptableObject
{
    public StringData characterName;
    public ColorData color;

    public IntData baseHealth;
    public float damageModifier = 1f, dodgeChance = 0f, maxMoveDistance = 5f;
    public ElementalData elementalModifiers;
}
