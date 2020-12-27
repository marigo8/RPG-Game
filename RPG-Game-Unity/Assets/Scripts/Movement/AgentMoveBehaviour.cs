using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NavMeshObstacle))]
public class AgentMoveBehaviour : MonoBehaviour
{
    public GameAction moveStartAction, moveEndAction;
    
    private NavMeshAgent agent;
    private NavMeshObstacle obstacle;
    private NavMeshPath path;

    private bool moving;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        obstacle = GetComponent<NavMeshObstacle>();
        
        path = new NavMeshPath();
    }

    public void MoveToDestination(Vector3 destination)
    {
        StartCoroutine(Move(destination));
    }

    public void MoveToDestination(Transform destinationObj)
    {
        StartCoroutine(Move(destinationObj.position));
    }

    private IEnumerator Move(Vector3 destination)
    {
        // Already Moving?
        if (moving) yield break;
        moving = true;
        
        // Prepare for Path Calculation
        moveStartAction.Raise();
        
        obstacle.enabled = false; // obstacle carves the navmesh, so it needs to be disabled before calculating the path
        yield return new WaitUntil(() => true); // wait one frame so that the navmesh can update.
        
        // Calculate Path
        agent.enabled = true;
        agent.CalculatePath(destination, path);
        agent.enabled = false;

        // Move to each corner of the path
        foreach (var corner in path.corners)
        {
            yield return new WaitWhile(() => MoveToCorner(corner));
        }
        
        // Finish
        obstacle.enabled = true;
        moveEndAction.Raise();
        moving = false;
    }

    private bool MoveToCorner(Vector3 corner)
    {
        // Get a point between the agent and the corner
        var between = Vector3.MoveTowards(transform.position, corner, agent.speed*Time.deltaTime);
        
        // Stop if arrived at corner
        if (Vector3.Distance(corner, between) <= 0) return false;

        // Snap to Nav Mesh
        if (NavMesh.SamplePosition(between, out var hit, 10f, agent.areaMask))
        {
            between = hit.position;
        }
        
        // Apply Movement
        transform.position = between;

        // Continue Loop
        return true;
    }
    
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.DrawWireSphere(transform.position, agent.stoppingDistance);
        var i = 0;
        foreach (var corner in path.corners)
        {
            Gizmos.color = i == 0 ? Color.red : Color.yellow;

            Gizmos.DrawWireSphere(corner,.25f);
            i++;
        }
    }
}
