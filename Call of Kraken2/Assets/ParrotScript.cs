using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotScript : MonoBehaviour
{

    public float distance;
    public float rangeToFollow;
    public bool attack;
    public bool isFollowingThePlayer;
    public GameObject target;
    public float moveSpeed;
    public Vector3 targetStoredPosition;
    public float attackRange;
    public float attackingSpeed;
    public Animator anim;
    public LayerMask PlayerLayer;
    public GameObject AttackPoint;
    float AttackRange = 0.12f;

    // Start is called before the first frame update
    void Start()
    {
             
    }

    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, PlayerLayer);
        foreach(Collider2D playerenemy in hitPlayer)
        {
            playerenemy.GetComponent<PlayerMovement>().HpBar.value -= 100f / PlayerStatsScript.Hp;
            playerenemy.GetComponent<PlayerMovement>().GetHit = true;
            playerenemy.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


    // Update is called once per frame
   void Update () {
 
        distance = Vector3.Distance (transform.position, target.transform.position);

        if(transform.position.x > target.transform.position.x)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
        else
        {
            transform.eulerAngles = new Vector2(0,0);
        }

 
        if (!attack) {
       
            if (distance < rangeToFollow) {
 
                isFollowingThePlayer = true;
 
                transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);
 
                targetStoredPosition = target.transform.position;
            
                if (distance < attackRange) 
                {
                    attack = true; 
                }
 
            }
 
        }
        
            if(attack){
 
                isFollowingThePlayer = false;
 
                transform.position = Vector3.MoveTowards (transform.position, targetStoredPosition, attackingSpeed * Time.deltaTime);
                
                if(distance > 0.6f){
 
                    attack = false;
                }
            }
    }
}
