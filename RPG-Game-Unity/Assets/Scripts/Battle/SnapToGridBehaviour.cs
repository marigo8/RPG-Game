using UnityEngine;
using UnityEngine.AI;

public class SnapToGridBehaviour : MonoBehaviour
{
    public float lerpSpeed;
    
    public void Snap()
    {
        Snap(transform.position);
    }
    
    public void Snap(Transform target)
    {
        Snap(target.position);
    }
    
    public void Snap(Vector3 position)
    {
        transform.position = GetSnappedPosition(position);
    }

    public void LerpSnap()
    {
        LerpSnap(transform.position);
    }

    public void LerpSnap(Transform target)
    {
        LerpSnap(target.position);
    }

    public void LerpSnap(Vector3 position)
    {
        position = GetSnappedPosition(position);
        position = Vector3.Lerp(transform.position, position, lerpSpeed * Time.deltaTime);

        transform.position = position;
    }

    private Vector3 GetSnappedPosition(Vector3 position)
    {
        position.x = Mathf.RoundToInt(position.x);
        position.z = Mathf.RoundToInt(position.z);

        if (NavMesh.SamplePosition(position, out var hit, 10f, NavMesh.AllAreas))
        {
            position = hit.position;
            position.x = Mathf.RoundToInt(position.x);
            position.z = Mathf.RoundToInt(position.z);
        }

        return position;
    }
}
