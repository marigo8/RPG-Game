using UnityEngine;
using UnityEngine.Events;

public class AttackBehaviour : MonoBehaviour
{
    public AttackData data;
    public bool activate;

    public UnityEvent<BattleUnitBehaviour> activateEvent;

    private void OnTriggerStay(Collider other)
    {
        if (!activate) return;
        
        var unit = other.GetComponent<BattleUnitBehaviour>();
        if (unit == null) return;
        
        activate = false;
        activateEvent.Invoke(unit);
    }

    public void UpdateUnitHealth(BattleUnitBehaviour unit)
    {
        unit.TakeDamage(data);
    }
}
