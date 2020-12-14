using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentDestinationBehaviour : MonoBehaviour
{
    public GameAction onDestinationAction;
    public UnityEvent onDestinationEvent;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        //agent.updateRotation = false;
        agent.updateUpAxis = false;

        var position = transform.position + Vector3.down * agent.baseOffset;
        if (NavMesh.SamplePosition(position, out var hit, 2f, agent.areaMask))
        {
            transform.position = hit.position + Vector3.up * agent.baseOffset;
        }
        
    }

    public void SetDestinationAction(GameAction action)
    {
        onDestinationAction = action;
    }

    public void SetStoppingDistance(float stoppingDistance)
    {
        agent.stoppingDistance = stoppingDistance;
    }

    public void SetDestination(Transform transformObj)
    {
        StartCoroutine(MoveToDestination(transformObj.position));
    }

    private void OnDestination()
    {
        onDestinationAction.Raise();
        onDestinationEvent.Invoke();

        agent.stoppingDistance = 0;
        onDestinationAction = null;
    }

    private IEnumerator MoveToDestination(Vector3 destination)
    {
        agent.ResetPath();
        agent.SetDestination(destination);
        
        yield return new WaitUntil(() => agent.hasPath);

        var path = agent.path;
        
        yield return new WaitWhile(() => MoveAlongPath(path));
        
        OnDestination();
    }

    private bool MoveAlongPath(NavMeshPath path)
    {
        agent.SamplePathPosition(agent.areaMask, agent.speed * Time.deltaTime, out var hit);
        
        transform.position = hit.position + (Vector3.up * agent.baseOffset);
        return agent.remainingDistance > agent.stoppingDistance;
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
