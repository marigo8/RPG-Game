using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityAction Action;

    public void Raise()
    {
        Action?.Invoke();
    }
}
