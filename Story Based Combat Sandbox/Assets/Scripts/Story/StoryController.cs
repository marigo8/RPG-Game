using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Story/Controller")]
public class StoryController : ScriptableObject
{
    [System.Serializable]
    public struct TextTag
    {
        public string name;
        public Color color;

        public string Replace(string text)
        {
            text = text.Replace($"<{name}>", $"<b><color=#{ColorUtility.ToHtmlStringRGBA(color)}>");
            text = text.Replace($"</{name}>", "</color></b>");
            return text;
        }
    }
    
    public StoryData story;

    public int lineIndex;

    public StoryData.Line CurrentLine => story.lines[lineIndex];

    public GameAction startAction, lineAction, optionsAction;

    public List<TextTag> textTags;

    public void StartStory(StoryData newStory)
    {
        story = newStory;

        lineIndex = 0;
        
        startAction.Raise();
        lineAction.Raise();
    }

    public void NextLine()
    {
        lineIndex++;
        if (lineIndex >= story.lines.Capacity)
        {
            optionsAction.Raise();
        }
        else
        {
            lineAction.Raise();
        }
    }

    public string ParseTags(string text)
    {
        foreach (var tag in textTags)
        {
            text = tag.Replace(text);
        }

        return text;
    }
}
