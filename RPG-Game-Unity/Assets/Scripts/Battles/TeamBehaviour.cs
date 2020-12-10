using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TeamBehaviour : MonoBehaviour
{
    public BattleController controller;
    [FormerlySerializedAs("fighters")] public List<FighterBehaviour> fighterBehaviours;

    public void SetUpTeam(TeamData teamData)
    {
        var capacity = Math.Min(teamData.fighters.Capacity, fighterBehaviours.Capacity);

        for (var i = 0; i < capacity; i++)
        {
            fighterBehaviours[i].data = teamData.fighters[i];
            fighterBehaviours[i].gameObject.SetActive(true);
        }
    }
}
