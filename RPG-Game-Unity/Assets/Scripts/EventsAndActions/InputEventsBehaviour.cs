using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventsBehaviour : EventsBehaviour
{
    [System.Serializable]
    public struct InputEventPair
    {
        public string name;
        public bool useInputManager;
        public UnityEvent inputDownEvent, inputEvent, inputUpEvent;

        public void OnUpdate()
        {
            if (useInputManager)
            {
                if (Input.GetButtonDown(name))
                {
                    inputDownEvent.Invoke();
                }

                if (Input.GetButton(name))
                {
                    inputEvent.Invoke();
                }

                if (Input.GetButtonUp(name))
                {
                    inputEvent.Invoke();
                }
            }
            else
            {
                if (Input.GetKeyDown(name))
                {
                    inputDownEvent.Invoke();
                }

                if (Input.GetKey(name))
                {
                    inputEvent.Invoke();
                }

                if (Input.GetKeyUp(name))
                {
                    inputUpEvent.Invoke();
                }
            }
        }
    }

    public List<InputEventPair> inputEventPairs;

    private void Update()
    {
        foreach (var pair in inputEventPairs)
        {
            pair.OnUpdate();
        }
    }
}
