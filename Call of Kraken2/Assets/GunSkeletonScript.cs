using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class GunSkeletonScript : MonoBehaviour
{
    public ParticleSystem Blood;
    public Animator anim;
    private bool Shoot;
    public GameObject BulletR;
    public GameObject BulletL;
    public GameObject ShootPlace;
    public bool Hit = false;
    public float Speed = 0.7f;
    public float WalkingSpeed = 0.9f;
    public float Timer1 = 0f;
    public bool MoveRight;
    public Rigidbody2D Rb;
    public ParticleSystem RunningParticle;
    public Transform Player;
    public bool PlayerDetection = false;
    public int Health;
    public float HealthAmmount;
    public GameObject HealthBar;
    public float HealthBarWidth;
    public bool Attack;
    public float AttackRange = -10f;
    public float HitTimer;
    public LayerMask PlayerLayer;
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
    private float GunReloadTime = 6f;
    private bool GunReloaded;
    private bool BulletSpawned;
    public float ShootingTimer = 6;
    bool CanShoot;
    float ShootingRange = 1.5f;
    public bool Turn;
    public AudioSource GunShot;
    GameObject Money;
    // Start is called before the first frame update
    void Start()
    {
        Money = GameObject.FindGameObjectWithTag("GoldenCoin");
        HealthBarWidth = 1;
        GunReloaded = true;
        HitColor = 0.3f;
        MoveToR = true;
        Health = 70;
        HealthAmmount = 0.14f;
        HitTimer = 0.5f;
        DistGround = gameObject.GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Invoke("ColorHit", 0.05f);
        }


        if(HealthBarWidth <= 0)
        {
            
            //var money2 =
         
            Instantiate(Money, transform.position, transform.rotation);
            
            //money2.SetActive(true);
            Destroy(this.gameObject);
        }


        if (HealthBarWidth > 0)
        {
            HealthBar.transform.localScale = new Vector2(HealthBarWidth, 1);
        }
        else
        {
            HealthBar.transform.localScale = new Vector2(0, 0);
        }

         if(!CanShoot)
        {
            ShootingTimer -= Time.deltaTime;
        }

        if(ShootingTimer <= 0)
        {
            CanShoot = true;
        }
        if(PlayerDetection)
        {
        if(CanShoot)
        {
           // if(ShootingRange < Vector2.Distance(transform.position, Player.transform.position))
            //{
                //anim.SetBool("Moving", true);
            //}
            //else
            //{
              //  anim.SetTrigger("Shoot");
            //}

            CanShoot = false;
            ShootingTimer = 6f;
        }

        if(Player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        else
        {
            transform.eulerAngles =  new Vector2(0,180);
        }
        }
    }
    
    void Fire()
    {
        if(transform.eulerAngles.y == 180)
        {
            Instantiate(BulletR, ShootPlace.transform.position, ShootPlace.transform.rotation);
        }
        else
        {
           Instantiate(BulletR, ShootPlace.transform.position, ShootPlace.transform.rotation);
        }
    }
    void Bullet()
    {
        if (transform.eulerAngles.y == 180 && BulletSpawned == false)
        {
            BulletSpawned = true;
            Shoot = false;
            GunReloaded = false;
            Instantiate(BulletL, ShootPlace.transform.position, ShootPlace.transform.rotation);
        }
        else if(transform.eulerAngles.y == 0 && BulletSpawned == false)
        {
            BulletSpawned = true;
            Shoot = false;
            GunReloaded = false;
            Instantiate(BulletR, ShootPlace.transform.position, ShootPlace.transform.rotation);
        }
    }

    void ColorHit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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

        if (transform.eulerAngles.y == 180 && ground.collider == null)
        {
            anim.SetBool("Moving",false);
            Turn = false;
        }
        else if(transform.eulerAngles.y == 0 && ground.collider == null)
        {
            anim.SetBool("Moving",false);
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

        if (wall == true && transform.eulerAngles.y == 180 && (wall.collider.gameObject.tag == "Wall" || wall.collider.gameObject.tag == "Door"))
        {
            anim.SetBool("Moving",false);       
            Turn = false;   
        }
        else if(wall == true && transform.eulerAngles.y == 0 && (wall.collider.gameObject.tag == "Wall" || wall.collider.gameObject.tag == "Door"))
        {     
            anim.SetBool("Moving",false);
            Turn = true;
        }                            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDetection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerDetection = false;
        }
    }

    public void GunShotSound()
    {
        GunShot.Play(1);
    }
}
