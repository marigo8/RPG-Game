﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBehaviour : MonoBehaviour
{
    public void DebugEvent(string message)
    {
        Debug.Log(message);
    }

    public void DebugEvent(Object obj)
    {
        Debug.Log(obj.name);
    }
    
    public void DestroyObject(GameObject other)
    {
        Destroy(other);
    }
    
    public void DestroyObject(Collider other)
    {
        Destroy(other.gameObject);
    }
}
