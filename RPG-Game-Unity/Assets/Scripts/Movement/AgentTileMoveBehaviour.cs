using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NavMeshObstacle))]
public class AgentTileMoveBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshObstacle obstacle;
    private NavMeshPath path;

    private void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
        agent = GetComponent<NavMeshAgent>();
        EnableAgent(false);
        path = new NavMeshPath();
    }

    public void MoveToPoint(Vector3 destination)
    {
        EnableAgent(true);
        if (!agent.CalculatePath(destination, path)) return;
        if (path.status != NavMeshPathStatus.PathComplete) return;
        agent.SetPath(path);

        StartCoroutine(DisableAgentAtDestination());
    }

    private IEnumerator DisableAgentAtDestination()
    {
        yield return new WaitUntil(() => agent.remainingDistance <= 0.05f);
        EnableAgent(false);
    }

    private void EnableAgent(bool enable)
    {
        // obstacle and agent have to be disabled and enabled in this order. Otherwise Unity throws a warning message.
        if (enable)
        {
            //obstacle.enabled = false;
            agent.enabled = true;
        }
        else
        {
            agent.enabled = false;
            //obstacle.enabled = true;
        }
    }

    // public bool CalculatePath(Vector3 destination)
    // {
    //     destination.x = Mathf.RoundToInt(destination.x);
    //     destination.z = Mathf.RoundToInt(destination.z);
    //
    //     return agent.CalculatePath(destination, path);
    // }
    //
    // public void DebugPath(Transform destination)
    // {
    //     Debug.Log(CalculatePath(destination.position));
    //     Debug.Log(path.status);
    // }
    //
    // public void MoveOnPath()
    // {
    //     if (path.status != NavMeshPathStatus.PathComplete) return;
    //     agent.SetPath(path);
    // }
    //
    // private void OnDrawGizmos()
    // {
    //     if (path == null) return;
    //
    //     foreach (var corner in path.corners)
    //     {
    //         Gizmos.DrawWireSphere(corner, .5f);
    //     }
    // }
}
