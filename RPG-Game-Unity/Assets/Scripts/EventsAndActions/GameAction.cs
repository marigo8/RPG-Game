using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityAction Action;
    public UnityAction<GameObject> GameObjectAction;

    public void Raise()
    {
        Action?.Invoke();
    }

    public void Raise(GameObject obj)
    {
        GameObjectAction?.Invoke(obj);
    }
}
