using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraBehaviour : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
