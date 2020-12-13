using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryConditionData : ScriptableObject
{
    public UnityEvent trueEvent, falseEvent;

    public virtual void ConditionalInvoke()
    {
        
    }
}
