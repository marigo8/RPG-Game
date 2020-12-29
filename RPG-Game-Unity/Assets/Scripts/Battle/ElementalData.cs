using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Elemental Modifiers")]
public class ElementalData : ScriptableObject
{
    [System.Serializable]
    public struct Modifier
    {
        public ID type;
        public float incomingDamageModifier;
    }

    public List<Modifier> modifiers;
}
