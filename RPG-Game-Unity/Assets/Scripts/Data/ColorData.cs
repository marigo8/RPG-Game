﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Color")]
public class ColorData : ValueData
{
    public Color value = Color.white;

    public override string GetString()
    {
        return value.ToString();
    }
}
