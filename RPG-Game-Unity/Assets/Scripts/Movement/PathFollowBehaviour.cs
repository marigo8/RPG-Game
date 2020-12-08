using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollowBehaviour : MonoBehaviour
{
    public FloatData moveSpeed;

    public void MoveAlongPath(NavMeshPath path)
    {
        StartCoroutine(MoveAlongPathIE(path.corners));
    }

    private IEnumerator MoveAlongPathIE(Vector3[] corners)
    {
        foreach (var corner in corners)
        {
            yield return new WaitUntil(() => MoveToCorner(corner));
        }

    }

    private bool MoveToCorner(Vector3 corner)
    {
        var newPosition = Vector3.MoveTowards(transform.position, corner, moveSpeed.value * Time.deltaTime);

        var distance = Vector3.Distance(transform.position, newPosition);

        transform.position = newPosition;

        return distance == 0;
    }
}
