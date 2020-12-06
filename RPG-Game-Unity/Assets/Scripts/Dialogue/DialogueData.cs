using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public struct Line
    {
        public CharacterData character;
        
        [TextArea()]
        public string text;

        public LineData lineData;
    }

    [System.Serializable]
    public struct LineData
    {
        public bool hideName;
        public UnityEvent lineEvent;
    }

    public UnityEvent onDialogueStart, onDialogueEnd;
    public List<Line> lines;
}
