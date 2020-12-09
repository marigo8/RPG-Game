using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehaviour : EventsBehaviour
{
    public UnityEvent<Collider> triggerEnterEvent, triggerStayEvent, triggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke(other);
    }
    
    private void OnTriggerStay(Collider other)
    {
        triggerStayEvent.Invoke(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke(other);
    }
}
