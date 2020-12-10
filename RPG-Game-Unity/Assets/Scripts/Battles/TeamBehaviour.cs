using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamBehaviour : MonoBehaviour
{
    public BattleController controller;
    public bool isPlayerTeam;
    public FighterBehaviour baseFighterPrefab;
    public List<Transform> fighterPositions;
    public List<FighterBehaviour> fighters;

    private void Start()
    {
        if(controller == null) throw new Exception($"{name}: No Team assigned!");
        var team = isPlayerTeam ? controller.playerTeam : controller.enemyTeam;
        
        var capacity = Math.Min(team.fighters.Capacity, fighterPositions.Capacity);

        for (var i = 0; i < capacity; i++)
        {
            var fighter = team.fighters[i];
            var position = fighterPositions[i];
            if (fighter == null || position == null) continue;

            var fighterBehaviour = Instantiate(baseFighterPrefab, position).GetComponent<FighterBehaviour>();
            if (fighterBehaviour == null) throw new Exception($"{name}: Fighter {i} of team {team.name} is not a fighter!");

            fighterBehaviour.data = fighter;

            fighters.Add(fighterBehaviour);
        }
    }
}
