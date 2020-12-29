using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/Character")]
public class CharacterData : ScriptableObject
{
    public StringData characterName;
    public ColorData color;

    public IntData baseHealth;
    public FloatData maxMoveDistance;
    public ElementalData elementalModifiers;
}
