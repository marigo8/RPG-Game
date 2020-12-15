using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/Conditional Story")]
public class ConditionalStoryData : ScriptableObject
{
    public ConditionData condition;
    public StoryData trueStory, falseStory;

    public StoryData GetStory()
    {
        if (condition.TestCondition())
        {
            Debug.Log(true);
            return trueStory;
        }
        else
        {
            Debug.Log(false);
            return falseStory;
        }
    }
}
