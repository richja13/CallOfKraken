using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate_combat : MonoBehaviour
{
   
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AttackCounter;
    public int AttackTimer;
    public bool Stamina = true;
    public GameObject pistolAmmo;
    public Transform PistolPosition;

    
   

    // Update is called once per frame
    void Update()
    {
       

        if (Stamina == true)
        {
            AttackTimer++;
            if (Input.GetKeyDown(KeyCode.E))
            {
                AttackTimer = 0;
                AttackCounter++;
                Attack();
             
            }


            if (AttackTimer >= 170)
            {
                AttackTimer = 0;

                AttackCounter = 1;
            }
            if (AttackCounter >= 4)
            {
                AttackCounter = 1;
            }

            anim.SetFloat("AttackCounter", AttackCounter);

            if (Input.GetMouseButtonDown(0))
             {
                anim.SetTrigger("GunFire");
              Shooting();
             }
        }
    }
    void Attack()
    {
        //Attack Animation
     
        anim.SetTrigger("Attack");
        //Detect Enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
          
        }

    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    void Shooting()
    {

        Instantiate(pistolAmmo,PistolPosition); 

        if (transform.rotation.y >= 180)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(12f, 0f), ForceMode2D.Impulse);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-12f, 0f), ForceMode2D.Impulse);
        }
        

    }

}


