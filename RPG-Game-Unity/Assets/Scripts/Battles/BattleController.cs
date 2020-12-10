using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Controllers/Battle")]
public class BattleController : ScriptableObject
{
    public IDContainer turnState;
    public TeamData playerTeam, enemyTeam;
}
