using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class SelectBehaviour : MonoBehaviour
{
    public AgentMoveBehaviour hoveredUnit, selectedUnit;
    
    public GameObject tilePreviewer;

    public BattleGridData grid;

    public GameAction obstaclesEnable, obstaclesDisable;
    public UnityEvent selectEvent;
    
    private List<GameObject> tilePreviews = new List<GameObject>();
    private List<Vector3Int> range = new List<Vector3Int>();

    public void ShowUnitRange(AgentMoveBehaviour agentMove)
    {
        StartCoroutine(CalculateUnitRange(agentMove));
    }

    private IEnumerator CalculateUnitRange(AgentMoveBehaviour agentMove)
    {
        obstaclesEnable.Raise();
        agentMove.obstacle.enabled = false;

        yield return new WaitUntil(() => true);
        
        foreach (var tile in grid.value)
        {
            if (!agentMove.CanMoveTo(tile.Value)) continue;
            PreviewTile(tile.Value);
        }
        
        obstaclesDisable.Raise();
    }

    public void ClearPreview()
    {
        foreach (var preview in tilePreviews)
        {
            Destroy(preview);
        }
        tilePreviews.Clear();
        range.Clear();
    }

    private void PreviewTile(Vector3 position)
    {
        var preview = Instantiate(tilePreviewer, position, Quaternion.identity);
        
        tilePreviews.Add(preview);
        range.Add(Vector3Int.RoundToInt(position));
    }

    public void InputSelect()
    {
        if (!Input.GetButtonDown("Submit")) return;
        if (hoveredUnit == null) return;
        selectedUnit = hoveredUnit;
        
        ClearPreview();
        ShowUnitRange(selectedUnit);
        
        selectEvent.Invoke();
    }

    public void InputSetDestination()
    {
        if (!Input.GetButtonDown("Submit")) return;

        var key = Vector3Int.RoundToInt(transform.position);

        if (!grid.value.ContainsKey(key)) return;

        if (!range.Contains(Vector3Int.RoundToInt(transform.position))) return;
        
        ClearPreview();
        
        selectedUnit.MoveToDestination(grid.value[key]);
    }

    private void OnTriggerEnter(Collider col)
    {
        var unit = col.GetComponent<AgentMoveBehaviour>();
        if (unit == null) return;

        hoveredUnit = unit;
    }

    private void OnTriggerExit(Collider col)
    {
        var unit = col.GetComponent<AgentMoveBehaviour>();
        if (unit == null) return;

        if (unit != hoveredUnit) return;

        hoveredUnit = null;
    }
}
