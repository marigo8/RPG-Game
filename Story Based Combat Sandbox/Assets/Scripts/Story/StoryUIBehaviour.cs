using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUIBehaviour : MonoBehaviour
{
    public StoryController controller;
    public Text nameText, dialogueText;
    public GameObject namePanel;

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
        var character = controller.CurrentLine.character;
        if (character == null)
        {
            namePanel.SetActive(false);
            return;
        }
        namePanel.SetActive(true);
        
        var characterName = character.characterName;
        
        characterName = controller.ParseTags(characterName);

        nameText.text = characterName;
    }
}
