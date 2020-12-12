using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUIBehaviour : MonoBehaviour
{
    public StoryController controller;
    public Text nameText, dialogueText;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnStoryStart()
    {
        gameObject.SetActive(true);
    }

    public void DisplayDialogue()
    {
        var dialogue = controller.CurrentLine.name;
        dialogue = controller.ParseTags(dialogue);
        dialogueText.text = dialogue;
    }

    public void DisplayName()
    {
        var characterName = controller.CurrentLine.character.characterName;
        characterName = controller.ParseTags(characterName);

        nameText.text = characterName;
    }
}
