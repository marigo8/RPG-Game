using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    public CharacterData character;
    public FloatData camRotateSpeed;
    
    private NavMeshAgent agent;
    private Vector3 movement;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void InputMove()
    {
        // Input
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        movement.Set(hInput, 0, vInput);
        movement = Vector3.ClampMagnitude(movement, 1f);
        
        // Factor Rotation
        movement = transform.TransformDirection(movement);

        // Move Speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= character.runSpeed.value;
        }
        else
        {
            movement *= character.moveSpeed.value;
        }
        
        // Apply
        agent.Move(movement * Time.deltaTime);
    }

    public void InputRotation()
    {
        var yInput = Input.GetAxis("Yaw");

        var rotation = transform.eulerAngles;
        rotation.y += yInput * camRotateSpeed.value * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
