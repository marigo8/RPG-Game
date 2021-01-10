using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AgentMoveBehaviour))]
public class BattleUnitBehaviour : MonoBehaviour
{
    public CharacterData character;
    public MoveSetData attacks;

    public int health;

    public UnityEvent updateHealthEvent;
    
    private AgentMoveBehaviour agentMove;

    public void TakeDamage(DamageData damage)
    {
        var totalDamage = damage.GetTotalDamage(this);
        health -= damage.baseDamage;
        updateHealthEvent.Invoke();
    }

    public void DisplayHealth(Image image)
    {
        var fill = health * 1f / character.baseHealth;
        image.fillAmount = fill;
    }

    private void Start()
    {
        agentMove = GetComponent<AgentMoveBehaviour>();

        health = character.baseHealth;
        updateHealthEvent.Invoke();
    }
}
