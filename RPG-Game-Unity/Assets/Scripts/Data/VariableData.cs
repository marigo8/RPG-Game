using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Variable")]
public class VariableData : ScriptableObject
{
    [System.Serializable]
    public struct Variable
    {
        public string name;
        public ValueData value;
    }

    public List<Variable> variables;
}