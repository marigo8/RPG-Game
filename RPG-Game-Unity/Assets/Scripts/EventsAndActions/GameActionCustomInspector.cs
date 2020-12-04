using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameAction))]
public class GameActionCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var gameAction = (GameAction) target;

        if (Application.isPlaying)
        {
            if (GUILayout.Button("Raise Action"))
            {
                gameAction.Raise();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Enter Play Mode to see \"Raise Action\" button.");
        }
    }
}
