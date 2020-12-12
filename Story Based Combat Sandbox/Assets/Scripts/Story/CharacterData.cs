using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Color color = Color.white;
}
