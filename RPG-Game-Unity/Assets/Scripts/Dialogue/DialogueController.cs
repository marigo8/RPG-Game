using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue/Controller")]
public class DialogueController : ScriptableObject
{
    public GameAction enterAction, lineAction, exitAction;
    
    private DialogueData dialogue;
    private DialogueData.Line currentLine;
    private int lineIndex;

    public void StartDialogue(DialogueData newDialogue)
    {
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
        
        textObj.text = character.characterName;
        textObj.color = character.color;
    }

    public void DisplayLine(Text textObj)
    {
        textObj.text = currentLine.text;
        textObj.color = currentLine.character.color;
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
