using UnityEngine;

[CreateAssetMenu(menuName = "Values/Vector3")]
public class Vector3Data : ValueData
{
    public Vector3 value;

    public void SetValueFromPosition(Transform transform)
    {
        value = transform.position;
    }

    public void SetValueFromIntPosition(Transform transform)
    {
        value = Vector3Int.RoundToInt(transform.position);
    }

    public void RoundHorizontalAxisToInt()
    {
        value.x = Mathf.RoundToInt(value.x);
        value.z = Mathf.RoundToInt(value.z);
    }

    public void SetPositionFromValue(Transform transform)
    {
        transform.position = value;
    }

    public override string GetString()
    {
        return value.ToString();
    }
}
