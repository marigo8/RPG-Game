using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsUIBehaviour : MonoBehaviour
{
    public GameObject optionButtonPrefab, cancelButtonPrefab, descriptionBox;

    public Text descriptionText;

    public StoryController controller;

    public void DisplayRootOptions()
    {
        DisplaySubOptions(controller.optionsRoot);
    }

    public void ClearOptions()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
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

    public void DisplaySubOptions(StoryController.Option option)
    {
        ClearOptions();
        foreach (var subOption in option.subOptions)
        {
            var optionObj = Instantiate(optionButtonPrefab, transform);
            var button = optionObj.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = subOption.name;
            if (subOption.subOptions.Count == 0)
            {
                button.onClick.AddListener(subOption.optionEvent.Invoke);
                if (subOption.description != "")
                {
                    var eventTrigger = optionObj.GetComponent<EventTrigger>();
                    
                    var pointerEnter = new EventTrigger.Entry();
                    pointerEnter.eventID = EventTriggerType.PointerEnter;
                    pointerEnter.callback.AddListener(delegate { ShowDescription(subOption.description); });
                    eventTrigger.triggers.Add(pointerEnter);
                    
                    var pointerExit = new EventTrigger.Entry();
                    pointerExit.eventID = EventTriggerType.PointerExit;
                    pointerExit.callback.AddListener(delegate { HideDescription(); });
                    eventTrigger.triggers.Add(pointerExit);
                }
            }
            else
            {
                button.onClick.AddListener(() => DisplaySubOptions(subOption));
            }
            
        }
        if (option != controller.optionsRoot)
        {
            var button = Instantiate(cancelButtonPrefab, transform).GetComponent<Button>();
        }
    }
}
