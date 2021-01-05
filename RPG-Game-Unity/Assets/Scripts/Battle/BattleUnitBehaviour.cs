using UnityEngine;

[RequireComponent(typeof(AgentMoveBehaviour))]
public class BattleUnitBehaviour : MonoBehaviour
{
    public CharacterData character;
    public PrefabListData attacks;

    public int health;
    
    private AgentMoveBehaviour agentMove;

    public void TakeDamage(AttackData damage)
    {
        health -= damage.baseDamage;
    }

    private void Start()
    {
        agentMove = GetComponent<AgentMoveBehaviour>();

        health = character.baseHealth.value;
    }
}
