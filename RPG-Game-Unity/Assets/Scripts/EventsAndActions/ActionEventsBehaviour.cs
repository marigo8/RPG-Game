using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ActionEventsBehaviour : EventsBehaviour
{
    [System.Serializable]
    public struct ActionEventPair
    {
        public string name;
        
        public GameAction action;

        public UnityEvent actionEvent;
        public UnityEvent<GameObject> gameObjectActionEvent;

        public void Initialize()
        {
            if (action == null) return;

            action.Action += OnAction;
            action.GameObjectAction += OnGameObjectAction;
        }

        public void Remove()
        {
            if (action == null) return;

            action.Action -= OnAction;
            action.GameObjectAction -= OnGameObjectAction;
        }

        private void OnAction()
        {
            actionEvent.Invoke();
        }

        private void OnGameObjectAction(GameObject obj)
        {
            gameObjectActionEvent.Invoke(obj);
        }
    }

    public List<ActionEventPair> actionEventPairs = new List<ActionEventPair>(1);

    private void OnEnable()
    {
        foreach (var pair in actionEventPairs)
        {
            pair.Initialize();
        }
    }

    private void OnDestroy()
    {
        foreach (var pair in actionEventPairs)
        {
            pair.Remove();
        }
    }
}
