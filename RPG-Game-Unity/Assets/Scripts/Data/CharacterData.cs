using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string characterName;

    public FloatData moveSpeed, runSpeed;
}
