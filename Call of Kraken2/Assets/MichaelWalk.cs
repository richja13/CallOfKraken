using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelWalk : StateMachineBehaviour
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
        RandomNumber = Random.Range(6,50); 
        //RandomNumber = Random.Range(6,14); 
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Boss = animator.GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        //Debug.Log(RandomNumber);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {      
        Debug.Log(RandomNumber);
        Vector2 target = new Vector2(Player.transform.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target,speed * Time.fixedDeltaTime);
        //rb.MovePosition(newPos);
        Boss.position = Vector2.MoveTowards(rb.position,target, speed * Time.fixedDeltaTime);
        
        if(Vector2.Distance(Player.position, rb.position) <= AttackRange && RandomNumber > 5 && RandomNumber < 15)
        {
            animator.SetTrigger("Attack1");
            animator.SetBool("Walk",false);
        }
        else if(Vector2.Distance(Player.position, rb.position) <= AttackRange && RandomNumber >= 15 && RandomNumber < 30)
        {
            animator.SetTrigger("Attack2");
            animator.SetBool("Walk",false);
        }
        else if(Vector2.Distance(Player.position, rb.position) <= AttackRange && RandomNumber >= 30 && RandomNumber <= 50)
        {
            animator.SetTrigger("Attack3");
            animator.SetBool("Walk",false);
        }
        
        

       /* if(Vector2.Distance(Player.position, rb.position) <= UltimateAttackRange && RandomNumber <= 5)
        {
            animator.SetTrigger("UltimateAttack");
            animator.SetBool("Walk",false);        
        }
        */
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       //animator.ResetTrigger("Attack");
       //animator.ResetTrigger("Attack2");
       //animator.ResetTrigger("Attack3");
      // animator.ResetTrigger("UltimateAttack");
    }
  
}
