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

    private void Update()
    {
        // switch(characterState)

        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        var yInput = Input.GetAxis("Yaw");

        var rotation = transform.eulerAngles;
        rotation.y += yInput * camRotateSpeed.value * Time.deltaTime;
        transform.eulerAngles = rotation;

        movement.Set(hInput, 0, vInput);

        movement = Vector3.ClampMagnitude(movement, 1f);
        movement = transform.TransformDirection(movement);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= character.runSpeed.value;
        }
        else
        {
            movement *= character.moveSpeed.value;
        }
        
        agent.Move(movement * Time.deltaTime);
    }
}
