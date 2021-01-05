using UnityEngine;

[RequireComponent(typeof(AgentMoveBehaviour))]
public class BattleUnitBehaviour : MonoBehaviour
{
    public CharacterData character;
    public MoveSetData attacks;

    public int health;
    
    private AgentMoveBehaviour agentMove;

    public void TakeDamage(DamageData damage)
    {
        health -= damage.baseDamage;
    }

    private void Start()
    {
        agentMove = GetComponent<AgentMoveBehaviour>();

        health = character.baseHealth.value;
    }
}
