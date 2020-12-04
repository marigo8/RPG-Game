using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ActionEventsBehaviour : EventsBehaviour
{
    [System.Serializable]
    public struct ActionEventPair
    {
        public GameAction action;

        public UnityEvent actionEvent;

        public void Initialize()
        {
            if (action == null) return;

            action.Action += OnAction;
        }

        private void OnAction()
        {
            actionEvent.Invoke();
        }
    }

    public List<ActionEventPair> actionEventPairs = new List<ActionEventPair>(1);

    private void Start()
    {
        foreach (var pair in actionEventPairs)
        {
            pair.Initialize();
        }
    }
}
