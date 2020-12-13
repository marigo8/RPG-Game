using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUIBehaviour : MonoBehaviour
{
    public StoryController controller;
    public Text nameText, dialogueText;
    public GameObject namePanel, dialoguePanel;
    public Color defaultColor = Color.white;

    public void Start()
    {
        if (controller.story != null) return;
        gameObject.SetActive(false);
    }

    public void OnStoryStart()
    {
        gameObject.SetActive(true);
    }

    public void OnStoryEnd()
    {
        gameObject.SetActive(false);
    }

    public void DisplayLine()
    {
        DisplayDialogue();
        DisplayName();
        var delay = controller.CurrentLine.lineData.delay;

        if (delay > 0)
        {
            StartCoroutine(DelayLine(delay));
        }
    }

    private void DisplayDialogue()
    {
        var currentLine = controller.CurrentLine;
        
        var dialogue = currentLine.name;
        var character = currentLine.character;
        
        dialogue = controller.ParseTags(dialogue);
        dialogueText.text = dialogue;

        dialogueText.color = character != null ? character.color : defaultColor;
    }

    private void DisplayName()
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
        nameText.color = character.color;
    }

    private void Update()
    {
        if (!dialoguePanel.activeSelf) return;
        if (Input.GetButtonDown("Submit"))
        {
            controller.NextLine();
        }
    }

    private IEnumerator DelayLine(float delay)
    {
        var dialogueActive = dialoguePanel.activeSelf;
        var nameActive = namePanel.activeSelf;
        
        dialoguePanel.gameObject.SetActive(false);
        namePanel.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(delay);
        
        dialoguePanel.gameObject.SetActive(dialogueActive);
        namePanel.gameObject.SetActive(nameActive);
    }
}
