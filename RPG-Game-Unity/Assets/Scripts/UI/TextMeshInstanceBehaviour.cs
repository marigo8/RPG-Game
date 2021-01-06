using System;
using TMPro;
using UnityEngine;

public class TextMeshInstanceBehaviour : MonoBehaviour
{
    public GameObject textMeshPrefab;
    public Color defaultColor = Color.white;
    public Vector3 offset;

    public void InstantiateTextMesh(string text, Color color)
    {
        var instance = Instantiate(textMeshPrefab, transform.position + offset, Quaternion.identity);
        var textMesh = instance.GetComponentInChildren<TextMeshPro>();
        if (textMesh == null) throw new Exception($"{name}: No TextMesh on prefab \"{textMeshPrefab.name}\"!");

        textMesh.text = text;
        textMesh.color = color;
    }

    public void InstantiateTextMesh(string text)
    {
        Debug.Log("huh?");
        InstantiateTextMesh(text,defaultColor);
    }
}
