using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Character/basic")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Color color = Color.white;

    public Mesh mesh;
    public AnimatorController animatorController;
}
