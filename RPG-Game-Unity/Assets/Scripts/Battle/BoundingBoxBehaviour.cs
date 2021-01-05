using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(BoxCollider))]
public class BoundingBoxBehaviour : MonoBehaviour
{
    public BattleGridData grid;

    private Vector3Int min, max;

    private BoxCollider box;

    private void Start()
    {
        box = GetComponent<BoxCollider>();
        
        min = Vector3Int.RoundToInt(box.bounds.min);
        max = Vector3Int.RoundToInt(box.bounds.max);

        for (var x = min.x; x <= max.x; x++)
        {
            for (var y = min.y; y <= max.y; y++)
            {
                for (var z = min.z; z <= max.z; z++)
                {
                    var key = new Vector3Int(x,y,z);
                    if (NavMesh.SamplePosition(key, out var hit, .5f, NavMesh.AllAreas))
                    {
                        var snappedPosition = hit.position;
                        snappedPosition.x = Mathf.RoundToInt(snappedPosition.x);
                        snappedPosition.z = Mathf.RoundToInt(snappedPosition.z);
                        
                        if(Vector3.Distance(hit.position, snappedPosition) > .125f) continue;
                        grid.value.Add(key, hit.position);
                    }
                }
            }
        }
        Debug.Log($"{grid.value.Count} tiles generated");
    }

    private void OnDrawGizmosSelected()
    {
        var center = Vector3.Lerp(min, max, .5f);
        
        var size = max - min;
        Gizmos.DrawWireCube(center, size);

        foreach (var tile in grid.value)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(tile.Value,.125f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(tile.Key, Vector3.one * .25f);
        }
    }
}
