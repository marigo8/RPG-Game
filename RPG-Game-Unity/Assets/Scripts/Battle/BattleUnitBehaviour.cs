using UnityEngine;

[RequireComponent(typeof(AgentMoveBehaviour))]
public class BattleUnitBehaviour : MonoBehaviour
{
    public CharacterData character;

    public int health;
    
    private AgentMoveBehaviour agentMove;

    public void TakeDamage(DamageBehaviour damage)
    {
        health -= damage.baseDamage.value;
    }

    private void Start()
    {
        agentMove = GetComponent<AgentMoveBehaviour>();

        health = character.baseHealth.value;
    }
}
