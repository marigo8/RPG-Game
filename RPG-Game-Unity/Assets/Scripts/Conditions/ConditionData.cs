using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConditionData : ValueData
{
    public virtual bool TestCondition()
    {
        return false;
    }

    public override string GetString()
    {
        return "huh?";
    }
}
