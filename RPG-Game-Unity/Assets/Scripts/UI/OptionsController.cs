using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class OptionsController : ScriptableObject
{
    public UnityAction<OptionsData> DisplayAction;

    public void DisplayOptions(OptionsData data)
    {
        DisplayAction?.Invoke(data);
    }
}
