﻿using System;
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

        public void Initialize()
        {
            if (action == null) return;

            action.Action += OnAction;
        }

        public void Remove()
        {
            if (action == null) return;

            action.Action -= OnAction;
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

    private void OnDestroy()
    {
        foreach (var pair in actionEventPairs)
        {
            pair.Remove();
        }
    }
}
