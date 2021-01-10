using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Story/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Color dialogueColor = Color.white;

    public int baseHealth = 100;
    public float damageModifier = 1f, dodgeChance = 0f, maxMoveDistance = 5f;
    public ElementalData elementalModifiers;
}
