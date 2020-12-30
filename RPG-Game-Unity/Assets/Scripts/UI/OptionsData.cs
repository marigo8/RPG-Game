using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Options")]
public class OptionsData : ScriptableObject
{
    [System.Serializable]
    public struct Option
    {
        public string name;
        [TextArea()] 
        public string description;
        
        public UnityEvent optionEvent;
    }

    public List<Option> options;
}
