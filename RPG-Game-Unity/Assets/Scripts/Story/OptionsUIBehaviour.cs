using UnityEngine;
using UnityEngine.UI;

public class OptionsUIBehaviour : MonoBehaviour
{
    public GameObject optionButtonPrefab, cancelButtonPrefab;

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

    public void DisplaySubOptions(StoryController.Option option)
    {
        ClearOptions();
        foreach (var subOption in option.subOptions)
        {
            var button = Instantiate(optionButtonPrefab, transform).GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = subOption.name;
            if (subOption.subOptions.Count == 0)
            {
                button.onClick.AddListener(subOption.optionEvent.Invoke);
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
