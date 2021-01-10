using UnityEngine;

public class LookAtBehaviour : MonoBehaviour
{
    public float degrees;
    public bool lockX, lockY, lockZ;

    public void LookAtTarget(Vector3 target)
    {
        var originalRotation = transform.eulerAngles;
        transform.LookAt(target);
        var newRotation = transform.eulerAngles;

        if (lockX)
        {
            newRotation.x = originalRotation.x;
        }
        if (lockY)
        {
            newRotation.y = originalRotation.y;
        }
        if (lockZ)
        {
            newRotation.z = originalRotation.z;
        }

        if (degrees > 0)
        {
            newRotation += Vector3.one; // prevents flickering
            newRotation /= degrees;
            newRotation = Vector3Int.RoundToInt(newRotation);
            newRotation *= degrees;
        }

        transform.eulerAngles = newRotation;
    }

    public void LookAtTarget(Vector3Data target)
    {
        LookAtTarget(target.value);
    }
}
