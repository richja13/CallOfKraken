using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MichaelScript : MonoBehaviour
{
    public GameObject Player;
    public bool BossEntrence;
    public GameObject BossGate;
    public GameObject MainCamera;
    public Vector3 GateClosed;
    public Vector3 GateOpen;
    public RectTransform TopBar;
    public RectTransform BottomBar;
    public RectTransform HpBar;
    private bool BarsInvoked;
    public Text BossName;
    public Slider HpBarSlider;
    public float HP = 100;
    float MaxHp;
    public Animator anim;
    public ParticleSystem DeathParticles;
    public ParticleSystem DeathBlow;
    public bool StillAlive;
    public LayerMask PlayerLayer;
    public GameObject AttackPoint;
    public float AttackRange;
    public bool CanDeflect;
    public ParticleSystem SwordSparks;
    public DialogueManagerScript dialog;
    public SceneTransitionAnimationScript transition;
    public bool KegsCollected;
    public TimeManagerScript kegs;
    public AudioSource AttackSound;
    public AudioSource DashSound;
    public AudioSource blockSound;
    public string BossNameText;
    public GameObject UltiDash;
    public bool admiral;
    void Start()
    {
        MaxHp = HP;
        UltiDash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!admiral)
        {
            if(kegs.Collected)
            {
                KegsCollected = true; 
            }
        }

        
        if(this.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Invoke("ChangeColor", 0.2f);
        }

        HpBarSlider.value = (HP*100)/MaxHp;

        OnBossAreaEnter();  
        
        if(HP <= 0)
        {
            StillAlive = false;
        }
        else
        {
            StillAlive = true;
        }


        if(StillAlive)
        {
            if(Player.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector2(0,180);
            }
            else
            {
                transform.eulerAngles = new Vector2(0,0);
            }
        }
        else
        {
            dialog.CallDialog();

            if(ProjectMaster.IActMissionNumber == 9)
            {
                Debug.Log("RODO");
                ProjectMaster.IActMissionNumber = 10;
            }
            //MainCamera.GetComponent<CameraFollowScript>().BossFight = false;
            //MainCamera.GetComponent<CameraFollowScript>().BossDeath = true;
            //CameraShaker.Instance.StartShake(1f,2f,49f);
            //Invoke("BossBoom",2f);
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = det;
            DeathParticles.Play();
            if(admiral == false)
            {
                anim.enabled = false;
            }
        
            //ProjectMaster.IActMissionNumber = 10;
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            HP -= 25;
        }
    }

     void OnBossAreaEnter()
    { 
        if(Player.GetComponent<PlayerMovement>().OnBossArea == true)
        {
            HpBar.anchoredPosition = Vector2.Lerp(HpBar.anchoredPosition, new Vector2(HpBar.anchoredPosition.x,39), 0.06f);
            StartCoroutine("FadeIn");
            Invoke("DramaticBlackBars", 0.3f);
            Invoke("DramaticBlackBarsCancel", 4f);
            BossGate.transform.position = Vector3.Lerp(BossGate.transform.position, GateClosed, 0.3f);
        }
        else
        {
            if(KegsCollected)
            {
                Debug.Log("PATOREAKCJA");
                HpBar.anchoredPosition = Vector2.Lerp(HpBar.anchoredPosition, new Vector2(HpBar.anchoredPosition.x,-100), 0.2f);
                BossGate.transform.position = Vector3.Lerp(BossGate.transform.position, GateOpen, 0.3f);
            }
        }
    }

    void ChangeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1f; f += 0.01f)
        {
            Color a = BossName.color;
            a.a = f;
            BossName.color = a;

            yield return new WaitForSeconds(0.005f);
        }
    }

    void DramaticBlackBars()
    {
        if(BarsInvoked == false)
        { 
           //IDLE();
           //BossStage = 4;
           BossName.text = BossNameText;
           BottomBar.anchoredPosition = Vector2.Lerp(BottomBar.anchoredPosition , new Vector2(-3,32), 0.09f);
           TopBar.anchoredPosition = Vector2.Lerp(TopBar.anchoredPosition, new Vector2(-3, -32), 0.09f);
        }
    }

    void DramaticBlackBarsCancel()
    {
        
        BarsInvoked = true;
        BottomBar.anchoredPosition = Vector2.Lerp(BottomBar.anchoredPosition , new Vector2(-3,-50), 0.08f);
        TopBar.anchoredPosition = Vector2.Lerp( TopBar.anchoredPosition, new Vector2(-3, 50), 0.08f);
        anim.SetBool("OnAreaEnter" , true);
    }
      void BossBoom()
    {
        transition.SceneName = "";
        transition.ChangeScene();

        Destroy(this.gameObject, 1.5f);
        DeathParticles.Stop();
        //DeathBlow.Play(); // Continue normal emissions
        
        Instantiate(DeathBlow,transform.position,transform.rotation);
        //DeathBlow.Stop();
        
        StillAlive = true;
        HP = 0.000001f;
        BossGate.transform.position = Vector3.Lerp(BossGate.transform.position, GateOpen, 3f);
        BossGate.GetComponent<BoxCollider2D>().enabled = false;
        //MainCamera.GetComponent<HorizontalCameraScript>().BossDeath = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        if(ProjectMaster.IActMissionNumber == 9)
        {
            ProjectMaster.IActMissionNumber = 10;
        }
    }

   

    

    public void Dash()
    {
       UltiDash.SetActive(true);

        if(transform.eulerAngles.y == 180)
        {
            transform.position = new Vector2(transform.transform.position.x + 1,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 1,transform.position.y);
        }

       /* var DashDistance = transform.position.x; 
        DashSound.Play(1);
        if(transform.eulerAngles.y == 180)
        {
            transform.position = new Vector2(transform.transform.position.x + 1,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 1,transform.position.y);
        }

        if((DashDistance < Player.transform.position.x && Player.transform.position.x < transform.position.x) || (transform.position.x < Player.transform.position.x && Player.transform.position.x <= DashDistance))
        {
            Player.GetComponent<PlayerMovement>().SwordHit.Play(1);
            Player.GetComponent<PlayerMovement>().HpBar.value -= 250f/PlayerStatsScript.Hp;
            Player.GetComponent<PlayerMovement>().GetHit = true;
            Player.GetComponent<SpriteRenderer>().color = Color.red;
        }
        */
    }

 

     public void SwordAttack()
    {
        AttackSound.Play(1);

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, PlayerLayer);
        foreach(Collider2D playerenemy in hitPlayer)
        {
            if(Player.GetComponent<PlayerMovement>().Blocking == false)
            {
                Debug.Log(playerenemy.name);
                playerenemy.GetComponent<PlayerMovement>().HpBar.value -= 250f/PlayerStatsScript.Hp;
                playerenemy.GetComponent<PlayerMovement>().GetHit = true;
                playerenemy.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if(Player.GetComponent<PlayerMovement>().Blocking && !CanDeflect)
            {
                playerenemy.GetComponent<PlayerMovement>().StaminaBar.value -= 45;
            }
            else
            {
                MainCamera.GetComponent<CamShake>().Shake(0.01f,0.01f);
                anim.SetTrigger("rest");
                Instantiate(SwordSparks,AttackPoint.transform.position,transform.rotation);
                blockSound.Play(1);
            }
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

    public void CancelDash()
    {
        UltiDash.SetActive(false);
    }
}
