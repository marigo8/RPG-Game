using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseObjectEventsBehaviour : EventsBehaviour
{
    public UnityEvent mouseDownEvent, mouseUpEvent;

    private void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        mouseUpEvent.Invoke();
    }
}
