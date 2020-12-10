using UnityEngine;
using UnityEngine.Events;

public class StateMachineEventsBehaviour : StateMachineBehaviour
{
    public UnityEvent enterEvent, updateEvent, exitEvent;

     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enterEvent.Invoke();
    }

     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        updateEvent.Invoke();
    }

     // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        exitEvent.Invoke();
    }
}
