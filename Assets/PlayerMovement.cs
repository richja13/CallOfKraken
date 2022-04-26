using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public bool OnBossArea;
    public float moveSpeed = 0;
    private Rigidbody2D Rb;
    public Animator anim;
    public bool isGrounded;
    private float JumpHigher;
    private float AttackTimer;
    private bool Attack;
    private bool Attack2;
    private float ComboTimer;
    public bool ComboTimerActivator;
    public int AttackCounter;
    public ParticleSystem FallHitParticle;
    public ParticleSystem RunningParticle;
    public GameObject GroundDetector;
    public GameObject AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayer;
    public LayerMask BomberLayer;
    public float AttackRate = 0.2f;
    private float NextAttackTime = 0f;
    public Slider HpBar;
    public Slider StaminaBar;
    private float StaminaRecover = 4f;
    private bool StaminaTimer;
    private float inputVertical;
    public float distance;
    public LayerMask Rope;
    private bool Climbing;
    public Joystick joystick;
    public bool AttackButton;
    public float DistGround;
    public Camera mainCamera;
    private Vector3 StartCameraPosition;
    private bool CameraRecovery;
    public bool JumpTrue;
    public bool DownTrue;
    private bool AttackButtonPressed;
    public bool GetHit;
    public ParticleSystem BloodParticle;
    private float maxSpeed = 2f;
    float deltaTime = 0.0f;
    public Text FpsText;
    private float JumpHeight;
    public Text ResText;
    private float StaminaStats;
    private float DamageStats;
    private float HpStats;
    public GameObject BossCamera;
    public GameObject Boss;
    public LayerMask BossLayer;
    public LayerMask Boss2Layer;
    public LayerMask GunEnemyLayer;
    public ParticleSystem Money;
    public List<ParticleCollisionEvent> collisionEvents;
    public ParticleSystem PickUpParticle;
    public int Keg;
    public ParticleSystem kegParticles;
    public GameObject Bullet;
    public Transform Fireplace;
    public bool Blocking;
    public RaycastHit2D RopeInfo;
    public GameMasterScript gm;
    public bool WallDetection;
    public AudioSource SwordSwooh;
    public AudioSource SwordHit;
    public AudioSource PlayerRunning;
    public AudioSource FallSound;
    public AudioSource JumpSound;
    public AudioSource GunShot;
    public RectTransform AdRewarded;
     public SceneTransitionAnimationScript nextScene;
     public LayerMask ChestLayer;
     public bool Island;
     Slider GunSlider;
        AudioSource CoinSound;
     bool CanShoot;
     public float GunTimer;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;


    private void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        CanShoot = true;
        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMasterScript>();
        Application.targetFrameRate = 35;
        //StartCameraPosition = mainCamera.transform.position;
        DistGround = gameObject.GetComponent<Collider2D>().bounds.extents.y;
        collisionEvents = new List<ParticleCollisionEvent>();
        GunSlider = GameObject.FindGameObjectWithTag("GunSlider").GetComponent<Slider>();
        Time.timeScale = 1f;

        //ItemWorld.SpawnItemWorld(new Vector3(-37,0,0), new Item {itemType = Item.ItemType.hat, amount = 1});
     //   ItemWorld.SpawnItemWorld(new Vector3(-35,0,0), new Item {itemType = Item.ItemType.Jacket, amount = 1});
    }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
  
    }

    void Update()
    {

        if(CoinSound == null)
        {
            CoinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        }

        WallDetect();   
        GroundDetect();
       
        DamageStats = PlayerStatsScript.AttackDmg;
        StaminaStats = PlayerStatsScript.Stamina;
        HpStats = PlayerStatsScript.Hp;

        HpBar.maxValue = ((HpStats*100)/PlayerStatsScript.Hp);

              if(!anim.GetCurrentAnimatorStateInfo(0).IsTag("Block"))
{
    //anim.SetBool("Block", false);
        if (GetComponent<SpriteRenderer>().color == Color.red)
        {
            Invoke("ColorChange",0.1f);
        }

            if (GetHit)
            {
                anim.SetTrigger("GetHit");
            }
            else
            {
                anim.ResetTrigger("GetHit");
            }

            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("UF"))
            {   

                GetHit = false;

                if (isGrounded == false && (Rb.velocity.y == 0))
                {
                //Rb.gravityScale = 1.5f;
                }

       

                //Zmienia maks liczbe fps Application.targetFrameRate;

         

            if (Input.GetKey(KeyCode.P))
            {
                SceneManager.LoadScene("topDown");
            }

            if (HpBar.value <= 0)
            {
                //Destroy(this.gameObject);
                //var current = SceneManager.GetActiveScene().name;
                //SceneManager.LoadScene(current);
            }
        
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack2"))
            {
                AttackButtonPressed = true;
            }
            else
            {
                AttackButtonPressed = false;
            }

            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                //anim.ResetTrigger("SwordAttack");

                anim.SetBool("Attack", false);
                Attack = true;
                // AttackButton = false;
            }

            if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Shoot"))
            {
                Attack=true;
            }


            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack2"))
            {
                //anim.ResetTrigger("SwordAttack2");

                anim.SetBool("Attack2", false);
                Attack = true;
                //AttackButton = false;
            }

            if (joystick.Vertical > -0.9f && joystick.Vertical < 0.9f)
            {
                // anim.SetFloat("Velocity", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
                anim.SetFloat("Velocity", Mathf.Abs(joystick.Horizontal));
                //  anim.SetFloat("Horizontal",Math.Abs(joystick.Vertical));

            }


            if(joystick.Horizontal == 0)
            {
                moveSpeed = 0.5f;
            }


            if (joystick.Vertical > -0.8f && joystick.Vertical < 0.8f && anim.GetBool("Attack") == false && anim.GetBool("Attack2") == false)
            {
                
                if(WallDetection == false && transform.eulerAngles.y == 180)
                {
                    if (joystick.Horizontal < -0.2)
                    {
                        if(moveSpeed < maxSpeed)
                        {
                            moveSpeed += 0.2f;
                        }
                        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                
                    }
                }
                   
                if (Input.GetAxisRaw("Horizontal") < 0 || joystick.Horizontal <= -.12 && joystick.Horizontal != 0)
                {
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 || joystick.Horizontal <= -.12 && joystick.Horizontal != 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }

            if (joystick.Vertical > -0.9f && joystick.Vertical < 0.9f && anim.GetBool("Attack") == false && anim.GetBool("Attack2") == false)
            {
                if(WallDetection == false && transform.eulerAngles.y == 0)
                {
                    if (joystick.Horizontal > 0.2)
                    {

                        if (moveSpeed < maxSpeed)
                        {
                            moveSpeed += 0.2f;
                        }
                        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                    }
                }
                    
                if(Input.GetAxisRaw("Horizontal") > 0 || joystick.Horizontal >= 0.12 && joystick.Horizontal != 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 || joystick.Horizontal >= 0.12 && joystick.Horizontal != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Running"))
            {
                RunningParticle.Emit(1);
            }
            else
            {
                RunningParticle.Emit(0);
            }

            if (Input.GetKey(KeyCode.I))
            {
                //Rb.gravityScale = 10f;
            }

            if (Input.GetButtonDown("Jump") || JumpTrue)  
            {
                JumpTrue = false;
                anim.SetBool("Jumping", true);
                //Rb.AddForce((Vector2.up * 250f * Time.deltaTime), ForceMode2D.Impulse);
                Rb.velocity = Vector2.up * Time.deltaTime * JumpHeight;
            }

          

            if (isGrounded == false && Rb.velocity.y < 0)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
                Rb.gravityScale = 1f;
            }
            else if(isGrounded == true && Rb.velocity.y <= 0)
            {
                  anim.SetBool("Jumping", false);
                  anim.SetBool("Falling", false);
            }
            else
            {
                Rb.gravityScale = 1f;
                anim.SetBool("Falling", false);
            }

            if (StaminaBar.value < StaminaBar.maxValue)
            {
                if (StaminaRecover > -20)
                {
                    // while (StaminaBar.value < StaminaBar.maxValue)
                    // {
               
                    StaminaBar.value += 0.7f * (PlayerStatsScript.Stamina/3) * Time.deltaTime;
                    //   }
                }

                if (StaminaRecover > -100f)
                {
                    StaminaRecover -= Time.deltaTime;
                }
            }

                if(StaminaBar.value < 25)
                {
                AttackButton = false;
                }

                if (Time.time >= NextAttackTime)
                {
                    if (((Input.GetKeyDown(KeyCode.E) || AttackButton) && AttackCounter == 0 && Attack && StaminaBar.value >= 25f) && AttackButtonPressed == false)
                    {
                    //Invoke("CamAttackSlide", 0.2f);
                    StaminaRecover = 4f;
                    SwordSwooh.Play(1);
                    StaminaBar.value -= 2000f/(PlayerStatsScript.Stamina);
                    NextAttackTime = Time.time + 0.153f / AttackRate;
                    anim.SetBool("Attack", true);
                    //Invoke("PlayerAttack", 0.2f);
                    AttackCounter = 1;
                    Invoke("AttackEnd", 3.5f);
                    anim.SetTrigger("SwordAttack");
                    AttackButton = false;
                    }
                     else if (((Input.GetKeyDown(KeyCode.E) || AttackButton) && AttackCounter == 1 && Attack && StaminaBar.value >= 25f) && AttackButtonPressed == false)
                    {
                    //  Invoke("CamAttackSlide", 0.2f);
                    SwordSwooh.Play(1);
                    StaminaRecover = 4f;
                    StaminaBar.value -= 2000f/(PlayerStatsScript.Stamina);
                    NextAttackTime = Time.time + 0.153f / AttackRate;
                    anim.SetBool("Attack2", true);
                    //Invoke("PlayerAttack", 0.2f);
                    AttackCounter = 0;
                    Invoke("AttackEnd", 3.5f);
                    anim.SetTrigger("SwordAttack2");
                    AttackButton = false;
                    }
                }
            }
            else
            { 
                anim.SetBool("Attack2", false);
                anim.ResetTrigger("SwordAttack2");
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", false);
                anim.SetFloat("Velocity", 0);
                BloodParticle.Play();
            }
    }
    else
    {
        anim.SetBool("Attack2", false);
        anim.ResetTrigger("SwordAttack2");
        anim.SetBool("Jumping", false);
        anim.SetBool("Falling", false);
        anim.SetFloat("Velocity", 0);
        //anim.SetBool("Block", true);
    } 

    GunSlider.maxValue = PlayerStatsScript.GunTime;  
    GunSlider.value = GunTimer;

    if(CanShoot == false)
    {
        if(GunTimer < PlayerStatsScript.GunTime)
        {
            GunTimer += Time.deltaTime;
        }
        else
        {
            GunTimer = PlayerStatsScript.GunTime;
            CanShoot = true;
        }
    }
   
    }

    public void PickUpGun()
    {
        if(CanShoot)
        {
            GunTimer = 0;
            CanShoot = false;
            anim.SetTrigger("Fire");
            
        }
    }    

    void Shoot()
    {
        Instantiate(Bullet,new Vector3(Fireplace.transform.position.x, Fireplace.transform.position.y, 1),new Quaternion(-Fireplace.transform.rotation.x,Fireplace.transform.rotation.y, Fireplace.transform.rotation.z, Fireplace.transform.rotation.w));
    }

    private void FixedUpdate()
    {
        RopeInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, Rope);
    }

    public void Elevator()
    {
        if(RopeInfo.collider != null)
        {
            anim.SetBool("Jumping", true);
            Rb.velocity = Vector2.up * Time.deltaTime * 230;
        }
    }

    public void BlockFunctionEnter()
    {
        Blocking = true;
        anim.SetBool("Block", true);
    }

    public void BlockFunctionExit()
    {
        Blocking = false;
        anim.SetBool("Block",false);
    }

    public void ParryFunction()
    {

    }

    public void Jump()
    {
        if (isGrounded == true && Climbing == false)
        {
            JumpSound.Play(1);
            JumpTrue = true;
            JumpHeight = 140;
           
        }
    }
    
    public void JumpHigherHigherFunction()
    {
        if(anim.GetBool("Falling") == false && (RopeInfo.collider == null))
        {
            Rb.velocity = Vector2.down * 0.5f * Time.deltaTime; 
        }
    }

    public void JumpHigherFunction()
    {
        Invoke("JumpHigherHigherFunction", 0.11f);   
    }

    public void AttackEnd()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Attack2", false);
   
    }

    public void BackToShip()
    {
        SceneManager.LoadScene("topDown");
    }


    public void Stamina()
    {
        /* 
          if (StaminaBar.value <= 0)
          {
              if(StaminaRecover <= 0)
              {
                  StaminaRecover = 1f;
              }
              StaminaRecover -= Time.deltaTime;    
              if( StaminaBar.value < StaminaBar.maxValue)
              {
                  StaminaTimer = true;
              }
              else
              {
                  StaminaTimer = false;
                  StaminaRecover = 1f;
              }
          }

          if(StaminaTimer == true)
          {
              StaminaBar.value += 1f;
              if (StaminaBar.value >= StaminaBar.maxValue)
              {
                  StaminaTimer = false;
              }
          }*/
    }

    private void GroundDetect()
    {
        Vector2 pos = transform.position;
        pos.y = transform.position.y - 0.2f;
        Vector2 direction = Vector2.down;
        if (transform.eulerAngles.y == 180)
        {
            pos.x = transform.position.x + 0.1f;
        }
        else
        {
            pos.x = transform.position.x - 0.1f;
        }

        RaycastHit2D grounded = Physics2D.Raycast(pos, direction, 0.1f);

        //Debug.Log(grounded.collider.gameObject);

        //Debug.Log(grounded.collider);
        //Debug.Log(ground.collider);


        if (grounded == true && (grounded.collider.gameObject.tag == "Ground" || grounded.collider.gameObject.tag == "WheelPlatform" || grounded.collider.gameObject.tag == "Spikes"))
        {
            isGrounded = true;       
        }
        else
        {
            JumpTrue = false;
            JumpHigher = 0;
            isGrounded = false;    
        }
        Debug.DrawRay(pos, direction,Color.blue);
    }
    
    public void PlayerAttack()
    {
        Collider2D[] HitBoss = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, BossLayer);

        foreach(Collider2D Boss in HitBoss)
        {
            SwordHit.Play(1);
            Boss.GetComponent<SonOfKrakenScript>().HP -= DamageStats * 2.5f/4;
            //Boss.GetComponent<BomberSkeletonScript>().Blood.Play();
            Boss.GetComponent<SpriteRenderer>().color = Color.red;
        }

        Collider2D[] HitChest = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, ChestLayer);

        foreach(Collider2D chest in HitChest)
        {
            Destroy(chest.gameObject);
        }

        Collider2D[] HitBoss2 = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, Boss2Layer);

        foreach(Collider2D Boss in HitBoss2)
        {
            SwordHit.Play(1);
            Boss.GetComponent<MichaelScript>().HP -= DamageStats * 2.5f/4;
            //Boss.GetComponent<BomberSkeletonScript>().Blood.Play();
            Boss.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("ŚWIAT");
        }

        Collider2D[] hitBomber = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, BomberLayer);

        foreach(Collider2D bomber in hitBomber)
        {
            SwordHit.Play(1);
            bomber.GetComponent<BomberSkeletonScript>().HpValue -= (DamageStats * 0.5f)/20;
            bomber.GetComponent<BomberSkeletonScript>().Blood.Play();
            bomber.GetComponent<SpriteRenderer>().color = Color.red;

            if (bomber.transform.position.x > transform.position.x)
            {
                bomber.GetComponent<Rigidbody2D>().AddForce((Vector2.right * 2.1f) * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (bomber.transform.position.x < transform.position.x)
            {
                bomber.GetComponent<Rigidbody2D>().AddForce((Vector2.left * 2.1f) * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, EnemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            SwordHit.Play(1);
            //enemy.GetComponent<EnemySkeletonScript>().DezetTime = enemy.GetComponent<EnemySkeletonScript>().StartDezetTime;          
            enemy.GetComponent<EnemySkeletonScript>().Blood.Play();
            //enemy.GetComponent<EnemySkeletonScript>().Stun = true;
            enemy.GetComponent<EnemySkeletonScript>().HealthBarWidth -= (DamageStats * 0.8f)/20;
            //enemy.GetComponent<EnemySkeletonScript>().Hit = true;
            //enemy.GetComponent<EnemySkeletonScript>().HealthAmmount -= 0.047f;
            //enemy.GetComponent<GunSkeletonScript>().Hit = true;
            enemy.GetComponent<Animator>().SetTrigger("GetHit");
            if (enemy.transform.position.x > transform.position.x)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce((Vector2.right * 2.1f) * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (enemy.transform.position.x < transform.position.x)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce((Vector2.left * 2.1f) * Time.deltaTime, ForceMode2D.Impulse); 
            }
        }

        Collider2D[] GunEnemies = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, GunEnemyLayer);

        foreach(Collider2D GunEnemy in GunEnemies)
        {
            //enemy.GetComponent<EnemySkeletonScript>().DezetTime = enemy.GetComponent<EnemySkeletonScript>().StartDezetTime;          
            //GunEnemy.GetComponent<GunSkeletonScript>().Blood.Play();
            //enemy.GetComponent<EnemySkeletonScript>().Stun = true;

            //GunEnemy.GetComponent<GunSkeletonScript>().HealthBarWidth -= (DamageStats * 0.8f)/20;
            
            SwordHit.Play(1);
            //enemy.GetComponent<EnemySkeletonScript>().Hit = true;
            //enemy.GetComponent<EnemySkeletonScript>().HealthAmmount -= 0.047f;
            //enemy.GetComponent<GunSkeletonScript>().Hit = true;
            GunEnemy.GetComponent<GunSkeletonScript>().Blood.Play();
            GunEnemy.GetComponent<Animator>().SetTrigger("GetHit");
            GunEnemy.GetComponent<SpriteRenderer>().color = Color.red;
            GunEnemy.GetComponent<GunSkeletonScript>().HealthBarWidth -= 0.35f;
            if (GunEnemy.transform.position.x > transform.position.x)
            {
                GunEnemy.GetComponent<Rigidbody2D>().AddForce((Vector2.right * 2.1f) * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (GunEnemy.transform.position.x < transform.position.x)
            {
                GunEnemy.GetComponent<Rigidbody2D>().AddForce((Vector2.left * 2.1f) * Time.deltaTime, ForceMode2D.Impulse); 
            }
        }

        if (this.gameObject.transform.rotation.y < 0 && anim.GetBool("Attack") == true || anim.GetBool("Attack2") == true)
        {
            transform.Translate(Vector2.right * 0.1f);
            Attack = false;
        }
        else if(anim.GetBool("Attack") == true || anim.GetBool("Attack2") == true)
        {
            Attack = false;
            transform.Translate(Vector2.right * 0.1f);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.transform.position, AttackRange);
    }

    public void OnCollisionExit2D(Collision2D collision)
    { 
        if (collision.gameObject.name == "PlatformTilemap")
        {
            //isGrounded = false;
            //FallHitParticle.Emit(1);
        }
        else
        {
            //FallHitParticle.Emit(0);
        }
    }

   
   void OnParticleCollision(GameObject other)
   {
     ParticlePhysicsExtensions.GetCollisionEvents(Money, other,collisionEvents);
       for(int i = 0; i < collisionEvents.Count ;i++)
       {
          CoinCollider(collisionEvents[i]);
        
       }
   }

   void CoinCollider(ParticleCollisionEvent particleCollisionEvent)
   { 
        PlayerStatsScript.Money += 1;
        var kurwa = collisionEvents[collisionEvents.Count].colliderComponent.gameObject;
        Destroy(kurwa);
   }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ItemWorld itemWorld = collision.gameObject.GetComponent<ItemWorld>();
        
        if(itemWorld != null)
        {
        
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }



        if(collision.gameObject.tag == "GM")
        {
            Invoke("GmCollision",0.1f);
            Time.timeScale = 0.2f;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            HpBar.value -= 15;
        }

        if(collision.gameObject.tag == "Coin")
        {
            //Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        {
            FallSound.Play(1);
            FallHitParticle.Play();
        }

        if(collision.gameObject.tag == "WheelPlatform")
        {
            this.transform.parent = collision.transform;
        }
        else
        {
            this.transform.parent = null;
        }

        if(collision.gameObject.tag == "CannonBall")
        {
            HpBar.value -= 25;
            SwordHit.Play(1);
            GetHit = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

         if (collision.gameObject.tag == "Bullet")
        {
            SwordHit.Play(1);
            HpBar.value -= 15;
            GetHit = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }


        if (collision.gameObject.name == "PlatformTilemap")
        {
            //FallHitParticle.Emit(1);
            //isGrounded = true;
        }
       
        if (collision.gameObject.name == "PlatformTilemap" && isGrounded == true)
        {
            FallSound.Play(1);
            FallHitParticle.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "BossEntrance")
        {
            BossCamera.GetComponent<HorizontalCameraScript>().OnBossArea = false;
        }    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.name == "DoorKey")
        {
            collision.gameObject.SetActive(false);
        }

        if(collision.gameObject.tag=="Ult")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            HpBar.value -= 29;
        }

        if(collision.gameObject.tag=="LegendaryKeys")
        {
            PlayerStatsScript.KeysCollected += 1;
            Destroy(collision.gameObject);  
            nextScene.name = "TopDown";
            nextScene.ChangeScene();
        }

        if(collision.gameObject.name=="BossEntrance")
        {
            OnBossArea = true;
            if(Island)
            {   
                if(ProjectMaster.IActMissionNumber == 45)
                {
                    ProjectMaster.IActMissionNumber = 46;
                }
                mainCamera.GetComponent<IslandCamerScript>().BossFight = true;
            }
            else
            {
                if(ProjectMaster.IActMissionNumber == 45)
                {
                    ProjectMaster.IActMissionNumber = 46;
                }
                mainCamera.GetComponent<CameraFollowScript>().BossFight = true;
            }
        }

        if(collision.gameObject.tag == "GM")
        {
            Invoke("GmCollision",0.1f);
            Time.timeScale = 0.2f;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            HpBar.value -= 10;
        }

  
        if(collision.gameObject.tag == "Keg")
        {
            Keg+=1;
            Destroy(collision.gameObject);
            Instantiate(kegParticles,collision.gameObject.transform.position,collision.gameObject.transform.rotation);
        }

        if(collision.gameObject.tag == "GoldenCrate")
        {
            PlayerStatsScript.Money += 40;
            Destroy(collision.gameObject);
            //Instantiate(PickUpParticle, collision.transform.position, collision.transform.rotation);
        }

        if(collision.gameObject.tag == "TeaCrate")
        {
            PlayerStatsScript.Tea += 1;
            Instantiate(PickUpParticle, collision.transform.position, collision.transform.rotation);
        }

        if(collision.gameObject.tag == "GoldenCoin")
        {
            
            CoinSound.Play(); 
            PlayerStatsScript.Money += 150;
            Instantiate(PickUpParticle, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
              
        }

        if(collision.gameObject.tag == "Sugar")
        {
            PlayerStatsScript.Sugar += 1;
            Destroy(collision.gameObject);
            Instantiate(PickUpParticle, collision.transform.position, collision.transform.rotation);
        }

        if(collision.gameObject.tag == "Rum")
        {
            PlayerStatsScript.Rum += 1;
            Destroy(collision.gameObject);
            Instantiate(PickUpParticle, collision.transform.position, collision.transform.rotation);
        }
        
        if(collision.gameObject.tag == "BoxAds")
        {
            AdRewarded.anchoredPosition = new Vector2(0,0);
        }

        if(collision.gameObject.name == "BossEntrance")
        {
            BossCamera.GetComponent<HorizontalCameraScript>().OnBossArea = true;
        }

        if (collision.gameObject.tag == "Dart")
        {
            HpBar.value -= 4;
            GetHit = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if(collision.gameObject.tag == "DiamondChest")
        {
            PlayerStatsScript.Money += 1000;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Spikes")
        {
            HpBar.value -= 14;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }


        if (collision.gameObject.tag == "Heal")
        {
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            HpBar.value += 35f;
            //collision.gameObject.transform.position = new Vector2(-5585, 59595);
            collision.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.clear);
            
            Destroy(collision.gameObject, 0.7f);
        }
    }

    public void PressedAttackButton()
    {
        if (AttackButtonPressed == false)
        {
            AttackButton = true;
        }
    }

    void GmCollision()
    {
        Time.timeScale = 1f;
        transform.position = gm.lastCheckPointPos;
    }

    public void ColorChange()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
   
    void WallDetect()
    {
        Vector2 pos = transform.position;
        Vector2 direction = Vector2.right - new Vector2(0.75f, 0f);
        //var RayDistance = 0.001f;
        if (transform.eulerAngles.y == 180)
        {
            pos.x = transform.position.x - 0.2f;
        }
        else
        {
            pos.x = transform.position.x + 0.08f;
        }
        
        RaycastHit2D wall = Physics2D.Raycast(pos, direction, DistGround + 0.0001f);

        //Debug.Log(wall.collider);

        if(wall && (wall.collider.gameObject.tag == "Ground" || wall.collider.gameObject.tag == "Wall"))
        {
            WallDetection = true;
        }
        else
        {
            WallDetection = false;    
        }

        Debug.DrawRay(pos,direction,Color.red, DistGround + 0.0001f);
    }

    public void PlayerRunningSound()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Running"))
        {
            PlayerRunning.Play(1);
        }
        else
        {
            PlayerRunning.Play(0);
        }
    }

    public void GunShotSound()
    {
        GunShot.Play(1);
    }

    public void CloseAdPanel()
    {
        AdRewarded.anchoredPosition = new Vector2(1000,1000);
    }
}
