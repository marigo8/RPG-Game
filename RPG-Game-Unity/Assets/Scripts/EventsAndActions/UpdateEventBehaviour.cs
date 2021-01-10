using UnityEngine;
using UnityEngine.Events;

public class UpdateEventBehaviour : MonoBehaviour
{
    public UnityEvent updateEvent;

    private void Update()
    {
        updateEvent.Invoke();
    }
}
