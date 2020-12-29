using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    public IntData baseDamage;
    public FloatData hitChance;
    public ID type;
    
    public void OnUnitTrigger(Collider col)
    {
        var unit = col.GetComponent<BattleUnitBehaviour>();
        if (unit == null) return;
        unit.TakeDamage(this);
    }
}
