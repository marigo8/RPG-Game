using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamageData
{
    public AttackTypeID type;
    public int baseDamage;
    [Range(0f, 1f)] public float hitChance;
}

public class AttackBehaviour : MonoBehaviour
{

    public DamageData data;

    public UnityEvent<BattleUnitBehaviour> activateEvent;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} activated on frame {Time.frameCount}!");
        
        var unit = other.GetComponent<BattleUnitBehaviour>();
        if (unit == null) return;
        
        activateEvent.Invoke(unit);
    }

    public void UpdateUnitHealth(BattleUnitBehaviour unit)
    {
        unit.TakeDamage(data);
    }
}
