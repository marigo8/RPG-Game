using UnityEngine;

[CreateAssetMenu(menuName = "Condition/Dice Condition")]
public class DiceConditionData : ConditionData
{
    public IntData dice, par;

    public override bool TestCondition()
    {
        var roll = Random.Range(1, dice.value+1);
        return roll > par.value;
    }

    public override string GetString()
    {
        var chance = par.value * 1f / dice.value;
        chance = 1 - chance;
        if (chance <= 0)
        {
            return "0%";
        }
        chance *= 100;
        return Mathf.RoundToInt(chance) + "%";
    }

    public void DebugCondition(int iterations)
    {
        Debug.Log(GetString());
        for (var i = 0; i < iterations; i++)
        {
            Debug.Log(TestCondition());
        }
    }
}
