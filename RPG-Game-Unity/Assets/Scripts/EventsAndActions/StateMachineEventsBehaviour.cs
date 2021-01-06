using UnityEngine;
using UnityEngine.Events;

public class StateMachineEventsBehaviour : StateMachineBehaviour
{
    public UnityEvent<Animator,AnimatorStateInfo,int> enterEvent, updateEvent, exitEvent;

     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enterEvent.Invoke(animator,stateInfo,layerIndex);
    }

     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        updateEvent.Invoke(animator,stateInfo,layerIndex);
    }

     // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        exitEvent.Invoke(animator,stateInfo,layerIndex);
    }

    public void DestroySelf(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
    
    public void DebugEvent(string message)
    {
        Debug.Log(message);
    }
}
