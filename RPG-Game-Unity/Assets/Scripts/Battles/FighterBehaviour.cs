using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(NavMeshAgent))]
public class FighterBehaviour : MonoBehaviour
{
    public FighterData data;

    public int currentHealth;
    public float stoppingDistance;

    public GameAction turnFinishedAction;
    
    private NavMeshAgent agent;
    private MeshRenderer meshRenderer;

    private Vector3 startPosition;

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
    }

    public void BlockNextAttack(int chance, bool counter)
    {
        Debug.Log(counter ? $"{chance}% chance of counter" : $"{chance}% chance of block");
    }

    public IEnumerator Attack(FighterBehaviour target, SkillData attack)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.destination = target.transform.position;
        yield return new WaitUntil(() => agent.remainingDistance < stoppingDistance + 0.05f);
        attack.skillEvent.Invoke(this, target);

        agent.stoppingDistance = 0f;
        agent.destination = startPosition;
        yield return new WaitUntil(() => agent.remainingDistance < 0.05f);
        turnFinishedAction.Raise();
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        
        name = data.name;
        meshRenderer.material.color = data.color;
        currentHealth = data.baseHealth;

        startPosition = transform.position;
    }
}
