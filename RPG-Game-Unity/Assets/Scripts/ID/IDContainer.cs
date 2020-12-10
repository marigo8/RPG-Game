using UnityEngine;

[CreateAssetMenu(menuName = "ID/Container")]
public class IDContainer : ScriptableObject
{
    public ID id;
    public ID defaultId;

    public void ChangeID(ID newId)
    {
        id = newId;
    }

    public void SetToDefault()
    {
        id = defaultId;
    }
}
