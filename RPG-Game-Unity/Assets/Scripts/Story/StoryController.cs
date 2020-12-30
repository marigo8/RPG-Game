using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Events;

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

    //[System.Serializable]
    public class Option
    {
        public string name;
        public string description;
        public List<Option> subOptions = new List<Option>();
        public UnityEvent optionEvent;

        public Option(string newName, string newDescription, Option parent)
        {
            name = newName;
            description = newDescription;
            parent.subOptions.Add(this);
        }

        public Option(string newName)
        {
            name = newName;
        }

        public Option GetSubOption(string optionName)
        {
            foreach (var subOption in subOptions)
            {
                if (subOption.name == optionName)
                {
                    return subOption;
                }
            }

            return null;
        }
    }
    
    public StoryData story;

    public int lineIndex;

    public StoryData.Line CurrentLine => story.lines[lineIndex];

    public GameAction startAction, lineAction, optionsAction, endAction, pauseAction, resumeAction;
    
    public Option optionsRoot = new Option("root");

    public List<TextTag> textTags;

    public void StartStory(StoryData newStory)
    {
        ClearOptions();
        story = newStory;

        lineIndex = 0;
        
        story.onStart.Invoke();
        
        startAction.Raise();
        
        CurrentLine.lineData.lineEvent.Invoke();
        lineAction.Raise();
    }

    public void StartConditionalStory(ConditionalStoryData conditionalStoryData)
    {
        StartStory(conditionalStoryData.GetStory());
    }

    public void EndStory()
    {
        story = null;
        endAction.Raise();
    }

    public void NextLine()
    {
        lineIndex++;
        if (lineIndex >= story.lines.Capacity)
        {
            if (story.optionsData.options.Count == 0)
            {
                story.onEnd.Invoke();
                return;
            }
            ParseOptionNames();
            optionsAction.Raise();
        }
        else
        {
            CurrentLine.lineData.lineEvent.Invoke();
            lineAction.Raise();
        }
    }

    public void ParseOptionNames()
    {
        foreach (var optionHierarchy in story.optionsData.options)
        {
            var fullString = optionHierarchy.name;
            fullString = ParseVariables(fullString);
            var stringList = fullString.Split('/');

            var parentOption = optionsRoot;

            foreach (var option in stringList)
            {
                var existingOption = parentOption.GetSubOption(option);
                if (existingOption == null)
                {
                    var newOption = new Option(option, ParseVariables(optionHierarchy.description), parentOption);
                    parentOption = newOption;
                }
                else
                {
                    parentOption = existingOption;
                }
            }

            parentOption.optionEvent = optionHierarchy.optionEvent;
        }
    }

    public void ClearOptions()
    {
        optionsRoot.subOptions.Clear();
    }

    public string ParseTags(string text)
    {
        foreach (var tag in textTags)
        {
            text = tag.Replace(text);
        }

        return text;
    }

    public string ParseVariables(string text)
    {
        foreach (var variable in story.variableData.variables)
        {
            text = text.Replace($"[{variable.name}]", variable.value.GetString());
        }

        return text;
    }
}
