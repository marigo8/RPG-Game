using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(NavMeshAgent))]
public class FighterBehaviour : MonoBehaviour
{
    public BattleController controller;
    public FighterData data;
    
    private NavMeshAgent agent;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        
        name = data.name;
        meshRenderer.material.color = data.color;
    }
}
