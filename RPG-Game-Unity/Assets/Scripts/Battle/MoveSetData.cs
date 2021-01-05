using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Move Set")]
public class MoveSetData : ScriptableObject
{
    [System.Serializable]
    public struct Move
    {
        public string name;
        public GameObject prefab;
        public int staminaCost;
    }

    public List<Move> attacks;
}
