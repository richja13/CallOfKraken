using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSkeletonIdleScript : StateMachineBehaviour
{
  GameObject Player;
    Transform Skeleton;
    float speed = 2.5f;
    float AttackRange;
    bool PlayerDetected;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Skeleton = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerDetected = animator.GetComponent<GunSkeletonScript>().PlayerDetection;

        if(PlayerDetected)
        {
            animator.SetBool("Moving",true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Moving", true);
    }
}
