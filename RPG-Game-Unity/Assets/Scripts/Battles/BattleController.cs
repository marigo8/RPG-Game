using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Controllers/Battle")]
public class BattleController : ScriptableObject
{
    public IDContainer turnState;
    public TeamData playerTeam, enemyTeam;

    public FighterBehaviour selectedFighter;
    public FighterBehaviour selectedTarget;

    public void SelectFighter(FighterBehaviour fighter)
    {
        selectedFighter = fighter;
    }

    public void SelectTarget(FighterBehaviour fighter)
    {
        selectedTarget = fighter;
    }
}
