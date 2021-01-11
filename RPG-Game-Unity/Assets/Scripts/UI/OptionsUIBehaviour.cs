using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsUIBehaviour : MonoBehaviour
{
    public OptionsController controller;
    
    public GameObject optionButtonPrefab, descriptionBox;

    public Text descriptionText;

    public Transform cancelButton;

    public List<GameObject> optionButtons;

    public void DisplayOptions(OptionsData data)
    {
        ClearOptions();
        foreach (var option in data.options)
        {
            var optionObj = Instantiate(optionButtonPrefab, transform);
            optionButtons.Add(optionObj);
            var button = optionObj.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = option.name;
            button.onClick.AddListener(option.optionEvent.Invoke);
            
            if (option.description != "")
            {
                var eventTrigger = optionObj.GetComponent<EventTrigger>();
                
                var pointerEnter = new EventTrigger.Entry();
                pointerEnter.eventID = EventTriggerType.PointerEnter;
                pointerEnter.callback.AddListener(delegate { ShowDescription(option.description); });
                eventTrigger.triggers.Add(pointerEnter);
                
                var pointerExit = new EventTrigger.Entry();
                pointerExit.eventID = EventTriggerType.PointerExit;
                pointerExit.callback.AddListener(delegate { HideDescription(); });
                eventTrigger.triggers.Add(pointerExit);
            }
        }
        cancelButton.SetAsLastSibling();
    }

    public void ClearOptions()
    {
        foreach (var optionButton in optionButtons)
        {
            Destroy(optionButton);
        }
    }

    

    public void ShowDescription(string description)
    {
        descriptionBox.SetActive(true);
        descriptionText.text = description;
    }

    public void HideDescription()
    {
        descriptionText.text = "";
        descriptionBox.SetActive(false);
    }

    private void Start()
    {
        controller.DisplayAction += DisplayOptions;
    }
}
