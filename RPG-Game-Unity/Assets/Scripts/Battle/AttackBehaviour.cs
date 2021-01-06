using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamageData
{
    public AttackTypeID type;
    public int baseDamage;
    public float hitChance;

    public BattleUnitBehaviour attacker;

    public int GetTotalDamage(BattleUnitBehaviour target)
    {
        var totalDamage = baseDamage;
        totalDamage = (int) (totalDamage * attacker.character.damageModifier);
        totalDamage = (int) (totalDamage * target.character.elementalModifiers.GetModifier(type));
        return totalDamage;
    }
}

[RequireComponent(typeof(TextMeshInstanceBehaviour))]
public class AttackBehaviour : MonoBehaviour
{
    private TextMeshInstanceBehaviour textMeshInstancer;
    
    public DamageData data;

    public UnityEvent<BattleUnitBehaviour> hitEvent, missEvent;

    private void Start()
    {
        textMeshInstancer = GetComponent<TextMeshInstanceBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"{name} activated on frame {Time.frameCount}!");
        
        var unit = other.GetComponent<BattleUnitBehaviour>();
        if (unit == null) return;
        
        var character = unit.character;
        var chance = data.hitChance - character.dodgeChance;
        var diceRoll = Random.Range(0f, 1f);

        if (diceRoll < chance) // hit or...
        {
            hitEvent.Invoke(unit);
        }
        else // miss
        {
            missEvent.Invoke(unit);
        }
        
    }

    public void UpdateUnitHealth(BattleUnitBehaviour unit)
    {
        unit.TakeDamage(data);
    }

    public void DisplayDamage(BattleUnitBehaviour unit)
    {
        var totalDamage = -data.GetTotalDamage(unit);
        var color = Color.white;
        if (totalDamage < 0)
        {
            color = Color.red;
        }
        else if (totalDamage > 0)
        {
            color = Color.green;
        }

        textMeshInstancer.InstantiateTextMesh(totalDamage.ToString("+#;-#;-0"), color);
    }
}
