using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Character/basic")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Color color = Color.white;
}
