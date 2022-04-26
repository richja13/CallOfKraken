using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRunningScript : StateMachineBehaviour
{
    GameObject Player;
    Transform Skeleton;
    float speed = 0.025f;
    float AttackRange = 0.3f;
    bool PlayerDetected;
    bool Turn;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Turn = animator.GetComponent<EnemySkeletonScript>().Turn;
        Player = GameObject.FindGameObjectWithTag("Player");

        Skeleton = animator.GetComponent<Transform>();
      
        //animator.SetBool("Moving", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        PlayerDetected = animator.GetComponent<EnemySkeletonScript>().PlayerDetection;

        if(PlayerDetected)
        {
            if(AttackRange < Vector2.Distance(Player.transform.position, Skeleton.position))
            {
                if(Skeleton.eulerAngles.y == 0)
                {
                    Skeleton.position = new Vector2(Skeleton.position.x + 1.5f * Time.deltaTime, Skeleton.position.y);
                }
                else
                {
                    Skeleton.position = new Vector2(Skeleton.position.x - 1.5f * Time.deltaTime, Skeleton.position.y);
                }
                    
                animator.GetComponent<EnemySkeletonScript>().Movement();
               
            }
            else
            {
                animator.SetBool("Moving", false);
                animator.SetTrigger("SkeletonAttack");
            }
        }
        else
        {

            if(Turn == true)
            { 
                Skeleton.eulerAngles = new Vector2(0,180);
              
            }
            else
            {
                Skeleton.eulerAngles = new Vector2(0,0); 
               
            }


            animator.GetComponent<EnemySkeletonScript>().Movement();

       

            

            if(Skeleton.eulerAngles.y == 0)
            {
                Skeleton.position = new Vector2(Skeleton.position.x + 1f * Time.deltaTime, Skeleton.position.y);
            }
            else
            {
                Skeleton.position = new Vector2(Skeleton.position.x - 1f * Time.deltaTime, Skeleton.position.y);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }    
}
