using System.Collections;
using UnityEngine;

public class CharacterBattleBehaviour : MonoBehaviour
{
    public CharacterData character;
    
    public Transform idlePoint, attackPoint;

    public Vector3 offset;

    private IEnumerator MoveTo(Transform destination)
    {
        var position = destination.position + offset;
        yield return new WaitUntil(() => Move(position));
    }

    private bool Move(Vector3 destination)
    {
        transform.position = Vector3.Lerp(transform.position, destination, 6f*Time.deltaTime);
        var distance = Vector3.Distance(transform.position, destination);

        return (distance < .1f);
    }
}
