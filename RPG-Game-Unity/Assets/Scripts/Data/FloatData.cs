using UnityEngine;

[CreateAssetMenu(menuName = "Values/Float")]
public class FloatData : ValueData
{
    public float value;

    public override string GetString()
    {
        return "" + value;
    }
}
