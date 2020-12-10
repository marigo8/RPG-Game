using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleBehaviour : MonoBehaviour
{
    
    public BattleController controller;

    public TeamBehaviour playerTeam, enemyTeam;

    public FighterBehaviour selectedFighter;
    public FighterBehaviour selectedTarget;

    public void SelectFighter(GameObject obj)
    {
        var fighter = obj.GetComponent<FighterBehaviour>();
        if (fighter == null) return;
        selectedFighter = fighter;
        Debug.Log("Selected Attacker: "+fighter.name);
    }

    public void SelectTarget(GameObject obj)
    {
        var fighter = obj.GetComponent<FighterBehaviour>();
        if (fighter == null) return;
        selectedTarget = fighter;
        Debug.Log("Selected Target: "+fighter.name);
    }

    private void Start()
    {
        playerTeam.SetUpTeam(controller.playerTeam);
        enemyTeam.SetUpTeam(controller.enemyTeam);
    }
}
