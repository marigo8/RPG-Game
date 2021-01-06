using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackContainerBehaviour : MonoBehaviour
{
    public List<AttackBehaviour> damageSpheres;

    public void SetAttacker(BattleUnitBehaviour attacker)
    {
        foreach (var damageSphere in damageSpheres)
        {
            damageSphere.data.attacker = attacker;
        }
    }
}
