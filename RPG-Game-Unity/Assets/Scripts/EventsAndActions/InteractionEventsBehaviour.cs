using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractionEventsBehaviour : EventsBehaviour
{
    public IDContainer playerState;
    public ID requiredState;
    
    public bool holdButtonDown;
    public UnityEvent onInteractionEvent, triggerEnterEvent, triggerExitEvent;
    
    private bool ready;

    private void Update()
    {
        if (!ready) return;
        if (playerState.id != requiredState) return;
        if (holdButtonDown)
        {
            if (Input.GetButton("Submit"))
            {
                onInteractionEvent.Invoke();
            }
        }
        else
        {
            if (Input.GetButtonDown("Submit"))
            {
                onInteractionEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ready = true;
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        ready = false;
        triggerExitEvent.Invoke();
    }
}
