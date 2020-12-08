using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingCursorBehaviour : MonoBehaviour
{
    public PathFindingController controller;

    public void Update()
    {
        controller.target = transform.position;
    }
}
