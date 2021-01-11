using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AgentMoveBehaviour))]
public class BattleUnitBehaviour : MonoBehaviour
{
    public CharacterData character;

    public int health;

    public UnityEvent updateHealthEvent;
    
    private AgentMoveBehaviour agentMove;

    private GameObject attackInstance;

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

    public void InstantiateAttack(AttackData attack)
    {
        if(attackInstance != null) Destroy(attackInstance);

        attackInstance = Instantiate(attack.prefab, transform.position, Quaternion.identity);
        
        attackInstance.GetComponent<AttackContainerBehaviour>().SetAttacker(this);
    }

    public void ShowAttackOptions(OptionsData optionsData)
    {
        foreach (var attack in character.moveSet.attacks)
        {
            var description = attack.staminaCost.ToString();
            var option = optionsData.NewOption(attack.attackName, description);
            option.optionEvent.AddListener(delegate { InstantiateAttack(attack); });
        }
    }

    private void Start()
    {
        agentMove = GetComponent<AgentMoveBehaviour>();

        health = character.baseHealth;
        updateHealthEvent.Invoke();
    }
}
