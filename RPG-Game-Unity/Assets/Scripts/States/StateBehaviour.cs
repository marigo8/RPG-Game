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
        public UnityEvent onStateEnter, onUpdate, stateEvent;
    }

    public IDContainer currentIdContainer;
    public List<State> states = new List<State>(1);
    public State defaultState = new State()
    {
        name = "default",
    };

    private State currentState;

    public void InvokeStateEvent()
    {
        currentState.stateEvent.Invoke();
    }

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
        if (currentState.id == defaultState.id) return;
        currentState = defaultState;
        Debug.Log("Invoking Default onStateEnter");
        currentState.onStateEnter.Invoke();
    }

    private void Start()
    {
        currentState = defaultState;
        ChangeState();
    }

    private void Update()
    {
        if(currentIdContainer.id != currentState.id) 
            ChangeState();
        
        currentState.onUpdate.Invoke();
    }
}
