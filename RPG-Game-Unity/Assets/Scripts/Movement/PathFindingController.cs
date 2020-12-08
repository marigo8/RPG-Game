using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class PathFindingController : ScriptableObject
{
    public AgentTileMoveBehaviour selectedFighter;
    public Vector3 target;

    public void SelectFighter(AgentTileMoveBehaviour fighter)
    {
        selectedFighter = fighter;
    }

    public void MoveFighter()
    {
        selectedFighter.MoveToPoint(target);
    }
}
