using UnityEngine;
using UnityEngine.Events;

public class AttackBehaviour : MonoBehaviour
{
    public AttackData data;

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
