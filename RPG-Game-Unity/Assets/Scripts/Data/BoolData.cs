using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Bool")]
public class BoolData : ValueData
{
    public bool value;

    public override string GetString()
    {
        return value.ToString();
    }
}
