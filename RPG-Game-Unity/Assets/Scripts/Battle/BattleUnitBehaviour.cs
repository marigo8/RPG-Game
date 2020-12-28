using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentMoveBehaviour))]
public class BattleUnitBehaviour : MonoBehaviour
{
    public StringData unitName;
    private AgentMoveBehaviour agentMove;

    private void Start()
    {
        agentMove = GetComponent<AgentMoveBehaviour>();
    }
}
