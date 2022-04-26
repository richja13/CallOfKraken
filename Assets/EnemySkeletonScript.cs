using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemySkeletonScript : MonoBehaviour
{
    GameObject Money;
    public float Speed = 0.7f;
    public float WalkingSpeed = 0.9f;
    public float Timer1 = 0f;
    public bool MoveRight;
    public Animator anim;
    public Rigidbody2D Rb;
    public ParticleSystem RunningParticle;
    public Transform Player;
    public bool PlayerDetection;
    public int Health;
    public float HealthAmmount;
    public GameObject HealthBar;
    public float HealthBarWidth;
    public bool Attack;
    private float AttackRange = 0.25f;
    public float HitTimer;
    public bool Hit;
    public LayerMask PlayerLayer;
    public float DistGround;
    public Transform AttackPoint;
    public List<Transform> EnemyList;
    private Transform nearestEnemy;
    public float RayDistance;
    private bool MoveToR;
    private bool MoveToL;
    public float AttackRate = 0.35f;
    private float NextAttackTime = 0f;
    public float DezetTime;
    public float StartDezetTime;
    public bool Stun;
    public float HitColor;
    public Collider2D[] wall;
    private float DetectionRange = 1.5f;
    public ParticleSystem Blood;
    public bool Turn;
    public float Distance;
    public GameObject CoinFountain;
    public bool  CanDeflect;
    public GameObject MainCamera;
    public AudioSource PlayerBlock;

    public int EnemyLvl = 1;
    void Start()
    {
        Money = GameObject.FindGameObjectWithTag("GoldenCoin");
        HealthBarWidth = 1;
        HitColor = 0.3f;
        MoveToR = true;
        Health = 35;
        HealthAmmount = 0.14f;
        HitTimer = 0.5f;
        DistGround = gameObject.GetComponent<Collider2D>().bounds.extents.y;
        Physics.IgnoreLayerCollision(9,18,true);
    }


    void Update()
    {    
        if(PlayerDetection)
        {
            if (transform.position.x > Player.transform.position.x)
            {
                transform.eulerAngles = new Vector2(0,180);
            }
            else
            {
                transform.eulerAngles = new Vector2(0,0);
            }

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
        }

        if(HealthBarWidth <= 0)
        {
            //Instantiate(CoinFountain,transform.position, transform.rotation);
            Instantiate(Money, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        
        if (Stun == true)
        {
            stun();
        }

        if (HealthBarWidth > 0)
        {
            HealthBar.transform.localScale = new Vector2(HealthBarWidth, 1);
        }
        else
        {
            HealthBar.transform.localScale = new Vector2(0, 0);
        }

        if (Hit == true)
        {
            HitTimer -= Time.deltaTime;
            if (HitTimer <= 0)
            {
                Hit = false;
                HitTimer = 0.5f;
            }
        }
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


    public void Movement()
    {
        isGrounded();
        WallDetection();
    }


    public void isGrounded()
    {
        Vector2 pos = transform.position;
        pos.y = transform.position.y - 0.22f;
        Vector2 direction = Vector2.down;
        RayDistance = 0.01f;
        if (transform.eulerAngles.y == 180)
        {
            pos.x = transform.position.x - 0.3f;
        }
        else
        {
            pos.x = transform.position.x + 0.2f;
        }

        RaycastHit2D ground = Physics2D.Raycast(pos, direction, DistGround + 0.01f);


        if(ground.collider == null)
        {
            anim.SetBool("Moving",false);
        }

        if (transform.eulerAngles.y == 180 && ground.collider == null)
        {
            Turn = false;
        }
        else if(transform.eulerAngles.y == 0 && ground.collider == null)
        { 
            Turn = true;
           
        }
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

        if (wall == true && transform.eulerAngles.y == 180 && (wall.collider.gameObject.tag == "Wall" || wall.collider.gameObject.tag == "Door" || wall.collider.gameObject.tag == "Ground"))
        {
            Turn = false;
          
            anim.SetBool("Moving",false);       
               
        }
        else if(wall == true && transform.eulerAngles.y == 0 && (wall.collider.gameObject.tag == "Wall" || wall.collider.gameObject.tag == "Door" || wall.collider.gameObject.tag == "Ground"))
        {     
            Turn = true;
            
            anim.SetBool("Moving",false);
           
        }                            
    }

    public void SwordAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, PlayerLayer);

        foreach(Collider2D playerenemy in hitPlayer)
        {
            if(Player.GetComponent<PlayerMovement>().Blocking == false)
            {
                Debug.Log(playerenemy.name);
                playerenemy.GetComponent<PlayerMovement>().HpBar.value -= 250f/PlayerStatsScript.Hp;
                playerenemy.GetComponent<PlayerMovement>().GetHit = true;
                playerenemy.GetComponent<SpriteRenderer>().color = Color.red;
                playerenemy.GetComponent<PlayerMovement>().SwordHit.Play(1);
            }
            else if(Player.GetComponent<PlayerMovement>().Blocking && !CanDeflect)
            {
                playerenemy.GetComponent<PlayerMovement>().StaminaBar.value -= 45;
            }
            else
            {
                PlayerBlock.Play(1);
                anim.SetTrigger("GetHit");
               // MainCamera.GetComponent<CamShake>().Shake(0.01f,0.01f);
            }
        }
    }

    public void FindPlayer()
    {
        //var closestEnemy = GameObject.FindGameObjectWithTag("PlayerCrew");
    }

    /*void OnDrawGizmosSelected()
    {
        if(AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.position,AttackRange);
    }
    */
    void Awake()
    {
      //  foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Player"))
      //  {
            //EnemyList.Add(Enemy.GetComponent<Transform>());
       // }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Player")
        {
            PlayerDetection = true;
        }

        if(collision.gameObject.tag == "Bullet")
        {
            HealthBarWidth -= 0.2f + PlayerStatsScript.GunDamage;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Blood.Play();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerDetection = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }

        if(collision.gameObject.tag == "GunSkeleton")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }
    }
    void CheckIfPlayerBlocking()
    {
        if(Player.GetComponent<PlayerMovement>().Blocking)
        {
            CanDeflect = false;
        }
        else
        {
            CanDeflect = true;
        }
    }
}

