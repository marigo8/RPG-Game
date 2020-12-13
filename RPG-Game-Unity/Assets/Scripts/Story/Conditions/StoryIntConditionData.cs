using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Story/Condition/Int")]
public class StoryIntConditionData : StoryConditionData
{
    public enum Condition
    {
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo,
        EqualTo,
        NotEqualTo,
        DiceGreaterThanOrEqualTo
    }

    public IntData intA;
    public Condition condition;
    public IntData intB;

    public override void ConditionalInvoke()
    {
        bool result;
        switch (condition)
        {
            case Condition.GreaterThan:
                result = intA.value > intB.value;
                break;
            case Condition.GreaterThanOrEqualTo:
                result = intA.value >= intB.value;
                break;
            case Condition.LessThan:
                result = intA.value < intB.value;
                break;
            case Condition.LessThanOrEqualTo:
                result = intA.value <= intB.value;
                break;
            case Condition.EqualTo:
                result = intA.value == intB.value;
                break;
            case Condition.NotEqualTo:
                result = intA.value != intB.value;
                break;
            case Condition.DiceGreaterThanOrEqualTo:
                var roll = Random.Range(0, intA.value);
                result = roll >= intB.value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (result)
        {
            trueEvent.Invoke();
        }
        else
        {
            falseEvent.Invoke();
        }
    }
}
