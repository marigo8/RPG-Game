using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Condition/Int Condition")]
public class IntConditionData : ConditionData
{
    public enum Condition
    {
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo,
        EqualTo,
        NotEqualTo,
    }

    public IntData intA;
    public Condition condition;
    public IntData intB;

    public override bool TestCondition()
    {
        switch (condition)
        {
            case Condition.GreaterThan:
                return intA.value > intB.value;
            
            case Condition.GreaterThanOrEqualTo:
                return intA.value >= intB.value;
            
            case Condition.LessThan:
                return intA.value < intB.value;
            
            case Condition.LessThanOrEqualTo:
                return intA.value <= intB.value;
            
            case Condition.EqualTo:
                return intA.value == intB.value;
            
            case Condition.NotEqualTo:
                return intA.value != intB.value;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
