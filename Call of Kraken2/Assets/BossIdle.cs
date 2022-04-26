using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
{
    Transform Player;
    Rigidbody2D rb;
    public float UltimateAttackRange;
    public float AttackRange;
    int RandomNumber;   

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RandomNumber = Random.Range(1,35); 
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        //Debug.Log(RandomNumber);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector2.Distance(Player.position, rb.position) >= AttackRange && RandomNumber > 5)
        {
            animator.SetBool("walk", true);
        }

        if(Vector2.Distance(Player.position, rb.position) <= UltimateAttackRange && RandomNumber <= 5)
        {
            animator.SetTrigger("UltimateAttack");        
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         if(Vector2.Distance(Player.position, rb.position) <= UltimateAttackRange)
        {
            //animator.SetTrigger("UltimateAttack");
        }
    }

}
