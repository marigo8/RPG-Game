using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateBehaviour : MonoBehaviour
{
    [System.Serializable]
    public struct State
    {
        public string name;
        public ID id;
        public UnityEvent onUpdate;
    }

    public ID currentId;
    public List<State> states = new List<State>(1);

    private State currentState;

    private void ChangeState()
    {
        foreach (var state in states)
        {
            if (state.id != currentId) continue;
            currentState = state;
            break;
        }
    }

    private void Start()
    {
        currentState = states[0];
        ChangeState();
    }

    private void Update()
    {
        if(currentId != currentState.id) 
            ChangeState();
        
        currentState.onUpdate.Invoke();
    }
}
