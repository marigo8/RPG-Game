using UnityEngine;

[CreateAssetMenu(menuName = "Values/String")]
public class StringData : ValueData
{
    public string value;

    public override string GetString()
    {
        return value;
    }
}
