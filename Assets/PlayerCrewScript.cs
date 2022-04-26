using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrewScript : MonoBehaviour
{
    //public GameObject Enemy;
    private float AttackSpeed;
    public Animator anim;
    private bool Attack;
    private float Speed;
    public float AttackRange;
    private bool EnemyDetection;

    public LayerMask EnemyLayer; 

    public GameObject AttackPoint;

    public List<Transform> EnemyList;

    private Transform nearestEnemy;

    public void Start()
    {
        Speed = 0.5f;
    }


    public void Update()
    {
      /*  FindPlayer();
        
        float minimumDistance = Mathf.Infinity;

        nearestEnemy = null;

        foreach (Transform EnemySkeleton in EnemyList)
        {
            float distance = Vector3.Distance(transform.position, EnemySkeleton.position);

            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = EnemySkeleton;
            }
        }

        if (Vector2.Distance(nearestEnemy.transform.position, transform.position) <= AttackRange)
        {
   
            Attack = true;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Invoke("SwordAttack", 0.2f);
        }

     
     
       
            if (Attack == true)
            {
                anim.SetBool("Attack", true);

                anim.SetBool("Moving", false);

                if (transform.position.x > nearestEnemy.transform.position.x)
                {
                    var PlayerLookAt = new Vector2(nearestEnemy.transform.position.x, nearestEnemy.transform.position.y);
                    PlayerLookAt.y = 0;
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                else if (transform.position.x < nearestEnemy.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    Invoke("SwordAttack", 0.2f);
                }
            }
            else
            {
                anim.SetBool("Attack", false);
            }

        Invoke("EndAttack", 0.2f);

          

            //Debug.DrawLine(this.transform.position, nearestEnemy.transform.position, Color.red);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(nearestEnemy.transform.position.x, transform.position.y), Speed * Time.deltaTime);

            anim.SetBool("Moving", true);

            if (transform.position.x > nearestEnemy.position.x)
            {
                var PlayerLookAt = new Vector2(nearestEnemy.transform.position.x, nearestEnemy.transform.position.y);
                PlayerLookAt.y = 0;

                //target is left
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (transform.position.x < nearestEnemy.transform.position.x)
            {
                //target is right
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            */
     // if (Vector2.Distance(EnemyList[1].position, transform.position) <= AttackRange)
      //{
        //  Attack = true;
      //}
      
      
    }

    public void FindPlayer()
    {
        var closestEnemy = GameObject.FindGameObjectWithTag("Player");

       //Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.blue); 
    }

    public void EndAttack()
    {
        Attack = false;
    }

    public void SwordAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, EnemyLayer);
    }

    void Awake()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyList.Add(go.GetComponent<Transform>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.transform.position, AttackRange);
    }
}
