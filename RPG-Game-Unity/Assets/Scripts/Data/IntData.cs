using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Int")]
public class IntData : ValueData
{
    public int value;

    public override string GetString()
    {
        return "" + value;
    }
}
