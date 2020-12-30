using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Prefab List")]
public class PrefabListData : ScriptableObject
{
    [System.Serializable]
    public struct PrefabData
    {
        public string name;
        public GameObject prefab;
    }

    public List<PrefabData> prefabs;

    public GameObject GetPrefab(string prefabName)
    {
        foreach (var prefabData in prefabs)
        {
            if (prefabData.name != prefabName) continue;
            return prefabData.prefab;
        }

        return null;
    }
}
