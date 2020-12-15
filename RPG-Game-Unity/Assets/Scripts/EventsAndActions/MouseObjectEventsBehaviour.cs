using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseObjectEventsBehaviour : EventsBehaviour
{
    public UnityEvent mouseDownEvent, mouseUpEvent, mouseOverEvent, mouseExitEvent;

    private void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        mouseUpEvent.Invoke();
    }

    private void OnMouseOver()
    {
        mouseOverEvent.Invoke();
    }

    private void OnMouseExit()
    {
        mouseExitEvent.Invoke();
    }
}
