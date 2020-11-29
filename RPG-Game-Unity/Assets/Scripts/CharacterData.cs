using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string characterName;

    public FloatData moveSpeed, runSpeed;
}
