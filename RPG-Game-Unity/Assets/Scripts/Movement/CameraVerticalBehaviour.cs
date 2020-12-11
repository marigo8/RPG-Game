using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraVerticalBehaviour : MonoBehaviour
{
    public IDContainer playerMoveState;
    
    public FloatData sensitivity;
    public float min, max;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineOrbitalTransposer orbitalTransposer;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        orbitalTransposer = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    private void LateUpdate()
    {
        var yInput = Input.GetAxis("Mouse Y");
        var offset = orbitalTransposer.m_FollowOffset;
        
        offset.y -= yInput * sensitivity.value * Time.deltaTime;

        offset.y = Mathf.Clamp(offset.y, min, max);

        orbitalTransposer.m_FollowOffset = offset;
    }
}
