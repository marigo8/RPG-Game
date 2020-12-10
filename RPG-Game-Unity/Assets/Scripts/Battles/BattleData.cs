using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Controllers/Battle")]
public class BattleData : ScriptableObject
{
    public IDContainer turnState;
    public TeamData playerTeam, enemyTeam;

    public ID attackID, supportID, defenceID;
}
