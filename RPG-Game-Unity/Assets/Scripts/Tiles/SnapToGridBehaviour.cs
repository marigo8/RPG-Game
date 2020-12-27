using UnityEngine;
using UnityEngine.AI;

public class SnapToGridBehaviour : MonoBehaviour
{
    public void Snap(Transform target)
    {
        Snap(target.position);
    }
    
    public void Snap(Vector3 position)
    {
        position.x = Mathf.RoundToInt(position.x);
        position.z = Mathf.RoundToInt(position.z);

        if (NavMesh.SamplePosition(position, out var hit, 10f, NavMesh.AllAreas))
        {
            position = hit.position;
            position.x = Mathf.RoundToInt(position.x);
            position.z = Mathf.RoundToInt(position.z);
        }

        transform.position = position;
    }
}
