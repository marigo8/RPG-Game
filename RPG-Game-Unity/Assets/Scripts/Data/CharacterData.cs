using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Color color = Color.black;
}
