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
        public UnityEvent onStateEnter, onUpdate;
    }

    public IDContainer currentIdContainer;
    public List<State> states = new List<State>(1);
    public State defaultState;

    private State currentState;

    private void ChangeState()
    {
        foreach (var state in states)
        {
            if (state.id != currentIdContainer.id) continue;
            currentState = state;
            currentState.onStateEnter.Invoke();
            return;
        }
        // Default
        currentState = defaultState;
    }

    private void Start()
    {
        ChangeState();
    }

    private void Update()
    {
        if(currentIdContainer.id != currentState.id) 
            ChangeState();
        
        currentState.onUpdate.Invoke();
    }
}
