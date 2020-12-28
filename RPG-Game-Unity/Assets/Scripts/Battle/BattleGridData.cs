using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Grid")]
public class BattleGridData : ScriptableObject
{
    public Dictionary<Vector3Int, Vector3> value = new Dictionary<Vector3Int, Vector3>();
}
