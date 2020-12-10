using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Battle/Skill")]
public class SkillData : ScriptableObject
{
    public ID category;

    public int value;

    public UnityEvent<FighterBehaviour, FighterBehaviour> skillEvent;

    public void DamageTargetHealth(FighterBehaviour user, FighterBehaviour target)
    {
        target.UpdateHealth(-value);
    }

    public void HealTargetHealth(FighterBehaviour user, FighterBehaviour target)
    {
        target.UpdateHealth(value);
    }

    public void BlockNextAttack(FighterBehaviour user, FighterBehaviour target)
    {
        user.BlockNextAttack(value, true);
    }

    public void CounterNextAttack(FighterBehaviour user, FighterBehaviour target)
    {
        user.BlockNextAttack(value, false);
    }
}
