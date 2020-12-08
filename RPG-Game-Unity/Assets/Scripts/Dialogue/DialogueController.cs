using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue/Controller")]
public class DialogueController : ScriptableObject
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
    
    public GameAction enterAction, lineAction, exitAction;

    public List<TextTag> textTags;
    
    private DialogueData dialogue;
    private DialogueData.Line currentLine;
    private int lineIndex;

    public void StartDialogue(DialogueData newDialogue)
    {
        if (newDialogue == null) return;
        dialogue = newDialogue;
        lineIndex = 0;
        currentLine = dialogue.lines[0];
        
        enterAction.Raise();
        dialogue.onDialogueStart.Invoke();
        
        lineAction.Raise();
    }

    public void EndDialogue()
    {
        exitAction.Raise();
        dialogue.onDialogueEnd.Invoke();

        dialogue = null;
    }

    public void GetNextLine()
    {
        lineIndex++;
        if (lineIndex < dialogue.lines.Capacity)
        {
            currentLine = dialogue.lines[lineIndex];
            lineAction.Raise();
        }
        else
        {
            EndDialogue();
        }
    }

    public void DisplayName(Text textObj)
    {
        var character = currentLine.character;

        if (character == null) return;
        
        textObj.text = character.characterName;
        textObj.color = character.color;
    }

    public void DisplayLine(Text textObj)
    {
        textObj.text = ParseTags(currentLine.text);
        if (currentLine.character == null) return;
        textObj.color = currentLine.character.color;
    }

    private string ParseTags(string text)
    {
        foreach (var textTag in textTags)
        {
            text = textTag.Replace(text);
        }

        return text;
    }

    // private IEnumerator RevealString(Text textObj, float charDelay)
    // {
    //     var text = currentLine.text;
    //     textObj.text = "";
    //     
    //     var wait = new WaitForSeconds(charDelay);
    //     foreach (var character in text)
    //     {
    //         yield return wait;
    //         textObj.text += character;
    //     }
    // }
}
