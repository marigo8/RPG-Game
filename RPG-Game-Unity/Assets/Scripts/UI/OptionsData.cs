using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Options")]
public class OptionsData : ScriptableObject
{
    [System.Serializable]
    public class Option
    {
        public string name;
        [TextArea()] 
        public string description;
        
        public UnityEvent optionEvent;

        public Option(string optionName, string optionDescription)
        {
            name = optionName;
            description = optionDescription;
            optionEvent = new UnityEvent();
        }
    }

    public List<Option> options;

    public Option NewOption(string optionName, string optionDescription)
    {
        var option = new Option(optionName, optionDescription);
        options.Add(option);
        return option;
    }

    public void ClearOptions()
    {
        options.Clear();
    }
}
