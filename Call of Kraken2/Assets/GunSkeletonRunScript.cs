using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSkeletonRunScript : StateMachineBehaviour
{
    public GameObject Player;
    float ShootingRange = 1.5f;
    Transform FireSkeleton;
    bool PlayerDetected;
    bool Turn;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        FireSkeleton = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerDetected = animator.GetComponent<GunSkeletonScript>().PlayerDetection;
        Turn = animator.GetComponent<GunSkeletonScript>().Turn;

        if(PlayerDetected)
        {
            if(ShootingRange >= Vector2.Distance(FireSkeleton.position, Player.transform.position))
            {
                animator.SetTrigger("Shoot"); 
                animator.SetBool("Moving", false);
            }
            else
            {
                FireSkeleton.position = Vector2.MoveTowards(FireSkeleton.position, Player.transform.position, 0.5f * Time.deltaTime);
            }
        }
        else
        {
            if(Turn == true)
            {
                FireSkeleton.eulerAngles = new Vector2(0,180);
            }
            else
            {
                FireSkeleton.eulerAngles = new Vector2(0,0);
            }

            animator.GetComponent<GunSkeletonScript>().Movement();

            if(FireSkeleton.eulerAngles.y == 0)
            {
                FireSkeleton.position = new Vector2(FireSkeleton.position.x + 1f * Time.deltaTime, FireSkeleton.position.y);
            }
            else
            {
                FireSkeleton.position = new Vector2(FireSkeleton.position.x - 1f * Time.deltaTime, FireSkeleton.position.y);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}