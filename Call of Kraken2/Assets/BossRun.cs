using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    float speed = 1.5f;
    static float Timer;
    int RandomNumber;
    Transform Player;
    Transform Boss;
    Rigidbody2D rb;
    public float AttackRange;
    public float UltimateAttackRange;
    private bool CanUlt;

    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RandomNumber = Random.Range(1,34); 
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Boss = animator.GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        //Debug.Log(RandomNumber);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {      
        Vector2 target = new Vector2(Player.transform.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target,speed * Time.fixedDeltaTime);
        //rb.MovePosition(newPos);
        Boss.position = Vector2.Lerp(rb.position,target, speed * Time.fixedDeltaTime);
        
        if(Vector2.Distance(Player.position, rb.position) <= AttackRange && (RandomNumber > 5 && RandomNumber < 15 ))
        {
            animator.SetTrigger("Attack");
        }

        if(Vector2.Distance(Player.position, rb.position) <= AttackRange && (RandomNumber > 15 && RandomNumber <= 35 ))
        {
            animator.SetTrigger("Attack2");
        }

        if(Vector2.Distance(Player.position, rb.position) <= UltimateAttackRange && RandomNumber <= 5)
        {
            animator.SetTrigger("UltimateAttack");        
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack");
       animator.ResetTrigger("UltimateAttack");
    }
  
}
