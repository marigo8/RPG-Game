using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class StateBehaviour : MonoBehaviour
{
    [System.Serializable]
    public struct State
    {
        public string name;
        public ID id;
        public UnityEvent onUpdate;
    }

    public IDContainer currentIdContainer;
    public List<State> states = new List<State>(1);

    private State currentState;

    private void ChangeState()
    {
        foreach (var state in states)
        {
            if (state.id != currentIdContainer.id) continue;
            currentState = state;
            return;
        }
        // Default
        currentState = states[0];
    }

    private void Start()
    {
        currentState = states[0];
        ChangeState();
    }

    private void Update()
    {
        if(currentIdContainer.id != currentState.id) 
            ChangeState();
        
        currentState.onUpdate.Invoke();
    }
}
