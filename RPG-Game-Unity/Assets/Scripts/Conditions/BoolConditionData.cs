using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Condition/Bool Condition")]
public class BoolConditionData : ConditionData
{
    public enum Condition
    {
        Equal,
        Not,
        And,
        Or,
        True,
        False
    }

    public bool invert;
    public BoolData boolA;
    public Condition condition;
    public BoolData boolB;

    public override bool TestCondition()
    {
        bool result;
        switch (condition)
        {
            case Condition.Equal:
                result = boolA.value == boolB.value;
                break;
            
            case Condition.Not:
                result = boolA.value != boolB.value;
                break;
                
            case Condition.And:
                result = boolA.value && boolB.value;
                break;
                
            case Condition.Or:
                result = boolA.value || boolB.value;
                break;
                
            case Condition.True:
                result = boolA.value == true;
                break;
                
            case Condition.False:
                result = boolA.value == false;
                break;
                
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (invert)
        {
            result = !result;
        }

        return result;
    }
}
