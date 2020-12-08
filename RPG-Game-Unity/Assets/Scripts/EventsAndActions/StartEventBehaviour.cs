using UnityEngine.Events;

public class StartEventBehaviour : EventsBehaviour
{
    public UnityEvent startEvent;

    private void Start()
    {
        startEvent.Invoke();
    }
}
