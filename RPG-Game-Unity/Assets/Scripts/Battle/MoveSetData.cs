using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Move Set")]
public class MoveSetData : ScriptableObject
{
    [System.Serializable]
    public struct Move
    {
        public string name;
        public GameObject prefab;
        public int coolDownTime;

        private int coolDownProgress;
    }
}
