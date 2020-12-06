using UnityEngine;

public class DisableOnStartBehaviour : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
