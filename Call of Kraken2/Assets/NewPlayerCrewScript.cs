using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class NewPlayerCrewScript : MonoBehaviour
{
    public float Speed = 0.7f;
    public float WalkingSpeed = 0.9f;
    public float Timer1 = 0f;
    public bool MoveRight;
    public Animator anim;
    public Rigidbody2D Rb;
    public ParticleSystem RunningParticle;
    public Transform Enemy;
    public bool EnemyDetection;
    public int Health;
    public float HealthAmmount;
    public GameObject HealthBar;
    public Vector2 HealthBarWidth;
    public bool Attack;
    public float AttackRange = -10f;
    public float HitTimer;
    public bool Hit;
    public LayerMask EnemyLayer;
    public float DistGround;
    public Transform AttackPoint;
    public List<Transform> EnemyList;
    private Transform nearestEnemy;
    public float RayDistance;
    private bool MoveToR;
    private bool MoveToL;
    public float AttackRate = 0.2f;
    private float NextAttackTime = 0f;
    public float DezetTime;
    public float StartDezetTime;
    public bool Stun;
    public float HitColor;
    public Collider2D[] wall;
    
    void Start()
    {
        HitColor = 0.3f;
        MoveToR = true;
        Health = 70;
        HealthAmmount = 0.14f;
        HitTimer = 0.5f;
        DistGround = gameObject.GetComponent<Collider2D>().bounds.extents.y;
    }

    void Update()
    {
        if(MoveToR == true)
        {
            MoveToRight();
        }
        else if(MoveToL == true)
        {
            MoveToLeft(); 
        }
        if (EnemyDetection == false)
        {
            isGrounded();
        }
        
        if (Time.time >= NextAttackTime)
        {
            if (Attack == true)
            {
             
                anim.SetBool("Attack", true);
                anim.SetBool("Moving", false);
                WalkingSpeed = 0f;
                Speed = 0f;
                NextAttackTime = Time.time + 0.153f / AttackRate;
                if (transform.position.x > Enemy.position.x)
                {
                    var PlayerLookAt = new Vector2(Enemy.position.x, Enemy.position.y);
                    PlayerLookAt.y = 0;
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                else if (transform.position.x < Enemy.position.x)
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
                WalkingSpeed = 0.9f;
                Speed = 0.7f;
                anim.SetBool("Attack", false);
            }
        }
        
      

        //if(Vector2.Distance(this.gameObject.transform.position,nearestEnemy.transform.position) <= AttackRange)
        //{
          //Attack = true;
        //}
        
        WallDetection();
        
        
        
        if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            HitColor -= Time.deltaTime;
            if(HitColor <= 0f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            HitColor = 0.3f;
        }
        
        FindPlayer();
        
        if (Stun == true)
        {
            stun();
        }

        HealthBarWidth = new Vector2(HealthAmmount, 0.019f);
        HealthBar.transform.localScale = HealthBarWidth;

        if (Hit == true)
        {
            HitTimer -= Time.deltaTime;
            if (HitTimer <= 0)
            {
                Hit = false;
                HitTimer = 0.5f;
            }
        }

        if (Health <= 0) Destroy(this.gameObject);

        
       
        float minimumDistance = Mathf.Infinity;

        nearestEnemy = null;

        foreach (Transform EnemyCrew in EnemyList)
        {
            float distance = Vector3.Distance(transform.position, EnemyCrew.position);

            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = EnemyCrew;
            }
        }


  
 

        Debug.DrawLine(this.transform.position, nearestEnemy.position, Color.green);
        //Debug.DrawLine(this.transform.position, nearestEnemy.position, Color.red);

        if (Vector2.Distance(nearestEnemy.position, transform.position) >= AttackRange)
        {
            
            Invoke("EndAttack", 0.2f);
          
            if (EnemyDetection == false)
            {
        
                /*   Timer1 += 60 * Time.deltaTime;
                   if (Timer1 >= 0 && Timer1 < 130)
                   {
                       anim.SetBool("Moving", true);
                       MoveToRight();
                   }
                   else if (Timer1 >= 130 && Timer1 < 190)
                   {
                       anim.SetBool("Moving", false);
                   }
                   else if (Timer1 >= 190 && Timer1 < 320)
                   {
                       anim.SetBool("Moving", true);
                       MoveToLeft();
                   }
                   else if (Timer1 >= 320 && Timer1 < 380)
                   {
                       anim.SetBool("Moving", false);
                   }
                   else if (Timer1 >= 380)
                   {
                       Timer1 = 0;
                   }
                   else
                   {
                       //anim.SetBool("Moving", false);
                   }                  
 */             isGrounded();
            }
            
            if (EnemyDetection == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(nearestEnemy.transform.position.x, transform.position.y), Speed * Time.deltaTime);
                anim.SetBool("Moving", true);
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
            }
        }
        //}
    }

    public void stun()
    {
        if (DezetTime <= 0)
        {
            WalkingSpeed = 0.9f;
            Speed = 0.7f;
            Stun = false;
        }
        else
        {
            WalkingSpeed = 0f;
            Speed = 0f;
            anim.SetBool("Moving", false);
            anim.SetBool("Attack", false);
            DezetTime -= Time.deltaTime;
        }
    }
    
    public void EndAttack()
    {
        Attack = false;
    }

    public void isGrounded()
    {
  
      
        
        Vector2 pos = transform.position;
        pos.y = transform.position.y - 0.22f;
        Vector2 direction = Vector2.down;
        RayDistance = 0.01f;
        if (transform.eulerAngles.y == 180)
        {
            pos.x = transform.position.x - 0.2f;
        }
        else
        {
            pos.x = transform.position.x + 0.2f;
        }

        RaycastHit2D ground = Physics2D.Raycast(pos, direction, DistGround + 0.01f);

        if (transform.eulerAngles.y == 180 && ground.collider == null)
        {
           
            MoveToR = true;
            MoveToL = false;
        }
        else if(transform.eulerAngles.y == 0 && ground.collider == null)
        {
            MoveToR = false;
            MoveToL = true;
      
        }
      //  Debug.DrawRay(pos, Vector2.down,Color.blue);
    }

    void WallDetection()
    {
        Vector2 pos = transform.position;
        Vector2 direction = Vector2.right - new Vector2(0.75f, 0f);
        RayDistance = 0.001f;
        if (transform.eulerAngles.y == 180)
        {
            pos.x = transform.position.x - 0.2f;
        }
        else
        {
            pos.x = transform.position.x + 0.2f;
        }
        
        RaycastHit2D wall = Physics2D.Raycast(pos, direction, DistGround + 0.001f);
        
        if (transform.eulerAngles.y == 180 && (wall.collider == this.wall[0] || (wall.collider == this.wall[1] || wall.collider == this.wall[2] || wall.collider == this.wall[3])))
        {
            MoveToR = true;
            MoveToL = false;
        }
        else if(transform.eulerAngles.y == 0 && (wall.collider == this.wall[0] || (wall.collider == this.wall[1] || wall.collider == this.wall[2] || wall.collider == this.wall[3])))
        {
            MoveToR = false;
            MoveToL = true;

        }
        
        
    
        
        
        
       // Debug.DrawRay(pos, Vector2.right - new Vector2(0.75f,0f),Color.red);
    }
    
    public void SwordAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, EnemyLayer);
        Enemy.GetComponent<PlayerMovement>().HpBar.value -= 5f;
        if (Enemy.transform.position.x > transform.position.x && Enemy.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            Enemy.GetComponent<Transform>().Translate((Vector2.left + Vector2.up * 1f) * Time.deltaTime * 2f);
        }
        else if (Enemy.transform.position.x > transform.rotation.x && Enemy.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            Enemy.GetComponent<Transform>().Translate((Vector2.right + Vector2.up * 1f) * Time.deltaTime * 2f);
        }
        else if (Enemy.transform.position.x < transform.rotation.x && Enemy.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            Enemy.GetComponent<Transform>().Translate((Vector2.right + Vector2.up * 1f) * Time.deltaTime * 2f);
        }
        else if (Enemy.transform.position.x < transform.rotation.x && Enemy.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            Enemy.GetComponent<Transform>().Translate((Vector2.right + Vector2.up * 1f) * Time.deltaTime * 2f);
        }
    }
    public void FindPlayer()
    {
        var closestEnemy = GameObject.FindGameObjectWithTag("PlayerCrew");

        //Debug.Log(closestEnemy);

        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.cyan);
    }


    void Awake()
    {
        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyList.Add(Enemy.GetComponent<Transform>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.transform.position, AttackRange);
    }

    public void MoveToRight()
    {
        
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
        transform.rotation = Quaternion.Euler(0,0,0);
        anim.SetBool("Moving", true);
    }

    public void MoveToLeft()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
        transform.rotation = Quaternion.Euler(0, -180, 0);
        anim.SetBool("Moving", true);
    }

    public void PatrolPause()
    {
        //MoveToL = false;
       //MoveToR = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyDetection = true;

            nearestEnemy = collision.gameObject.GetComponent<Transform>();
        }
        else
        {
            Attack = false;
            EnemyDetection = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(),this.gameObject.GetComponent<Collider2D>());
        }
    }                                                                                                                                                                                                                                                                                                                                                                
}



