using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Complex String")]
public class ComplexStringData : StringData
{
    public List<ValueData> variables;

    public override string GetString()
    {
        var result = value;
        for (var i = 0; i < variables.Count; i++)
        {
            result = result.Replace($"[{i}]", variables[i].GetString());
        }

        return result;
    }
}
