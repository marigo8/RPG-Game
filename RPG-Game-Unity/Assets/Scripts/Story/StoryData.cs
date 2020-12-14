using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Story/Story Data")]
public class StoryData : ScriptableObject
{
    [System.Serializable]
    public struct Line
    {
        [TextArea()] 
        public string name; // the dialogue to display. Using "name" so that the inspector displays it instead of "Element 0, Element 1..."
        public CharacterData character;

        public LineData lineData;
    }

    [System.Serializable]
    public struct LineData
    {
        public bool pauseStory;
        public UnityEvent lineEvent;
    }

    [System.Serializable]
    public struct Option
    {
        public string name;
        [TextArea()] 
        public string description;
        
        public UnityEvent optionEvent;
    }

    public UnityEvent onStart;

    public List<ValueData> variables;

    public List<Line> lines;

    public List<Option> options;

    public UnityEvent onEnd;
}
