using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentDestinationBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetStoppingDistance(float stoppingDistance)
    {
        agent.stoppingDistance = stoppingDistance;
    }

    public void SetDestination(Transform transformObj)
    {
        agent.SetDestination(transformObj.position);
    }

    private void Update()
    {
        if (agent.hasPath)
        {
            Debug.Log(agent.remainingDistance);
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.DrawWireSphere(transform.position, agent.stoppingDistance);
        if (!agent.hasPath) return;
        foreach (var corner in agent.path.corners)
        {
            Gizmos.DrawWireSphere(corner,.25f);
        }
    }
}
