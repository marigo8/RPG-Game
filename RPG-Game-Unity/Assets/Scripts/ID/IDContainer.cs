using UnityEngine;

[CreateAssetMenu(menuName = "ID/Container")]
public class IDContainer : ScriptableObject
{
    public ID id;

    public void ChangeID(ID newId)
    {
        id = newId;
    }
}
