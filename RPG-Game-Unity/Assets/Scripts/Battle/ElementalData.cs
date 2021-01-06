using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Elemental Modifiers")]
public class ElementalData : ScriptableObject
{
    [System.Serializable]
    public struct Modifier
    {
        public AttackTypeID type;
        public float incomingDamageModifier;
    }

    public List<Modifier> modifiers;

    public float GetModifier(AttackTypeID type)
    {
        foreach (var modifier in modifiers.Where(modifier => modifier.type == type))
        {
            return modifier.incomingDamageModifier;
        }

        return 1f;
    }
}
