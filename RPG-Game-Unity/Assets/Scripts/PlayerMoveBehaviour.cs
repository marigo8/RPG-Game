using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    public CharacterData character;
    
    private NavMeshAgent agent;
    private Vector3 movement;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // switch(characterState)

        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        movement.Set(hInput, 0, vInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= character.runSpeed.value;
        }
        else
        {
            movement *= character.moveSpeed.value;
        }
        
        agent.Move(movement * Time.deltaTime);
    }
}
