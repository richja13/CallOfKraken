using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class SonOfKrakenScript : MonoBehaviour
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
    public Animator anim;
    public int BossStage;
  //private bool ChangeStage;
    public bool WalkState;
    public bool UltimateState;
    public bool AttackState;
    public bool IdleState;

    public bool pickRandom;
    public bool CanChangeState;
    public ParticleSystem DeathParticles;
    public ParticleSystem DeathBlow;
    public bool StillAlive;
    public Sprite det;
    public DialogueManagerScript Dialog;
    public Sprite JackSprite;
    
    void Start()
    {
        pickRandom = true;
        anim.SetBool("OnAreaEnter" , true);
        BossGate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    
        if(this.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Invoke("ChangeColor", 0.2f);
        }

        OnBossAreaEnter();
        HpBarSlider.value = HP;

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
            //MainCamera.GetComponent<>().BossDeath = true;
            //CameraShaker.Instance.StartShake(1f,2f,49f);
            //Invoke("BossBoom",2f);
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = det;
            //DeathParticles.Play();
            Dialog.CallDialog();
            anim.enabled = false;
        }
    }

  

    void OnBossAreaEnter()
    { 
        if(MainCamera.GetComponent<IslandCamerScript>().BossFight == true)
        {
            BossGate.SetActive(true);
            HpBar.anchoredPosition = Vector2.Lerp(HpBar.anchoredPosition, new Vector2(HpBar.anchoredPosition.x,39), 0.06f);
            StartCoroutine("FadeIn");
            Invoke("DramaticBlackBars", 0.3f);
            Invoke("DramaticBlackBarsCancel", 4f);
            //BossGate.transform.position = Vector3.Lerp(BossGate.transform.position, GateClosed, 0.3f);
        }
        else
        {
            HpBar.anchoredPosition = Vector2.Lerp(HpBar.anchoredPosition, new Vector2(HpBar.anchoredPosition.x,-100), 0.2f);
            //BossGate.transform.position = Vector3.Lerp(BossGate.transform.position, GateOpen, 0.3f);
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
         //  IDLE();
          // BossStage = 4;
           BossName.text = "Capt. Jack Son of Kraken";
           BottomBar.anchoredPosition = Vector2.Lerp(BottomBar.anchoredPosition , new Vector2(-3,32), 0.09f);
           TopBar.anchoredPosition = Vector2.Lerp(TopBar.anchoredPosition, new Vector2(-3, -32), 0.09f);
        }
    }

    void DramaticBlackBarsCancel()
    {
        BarsInvoked = true;
        BottomBar.anchoredPosition = Vector2.Lerp(BottomBar.anchoredPosition , new Vector2(-3,-50), 0.08f);
        TopBar.anchoredPosition = Vector2.Lerp( TopBar.anchoredPosition, new Vector2(-3, 50), 0.08f);
        anim.SetBool("OnAreaEnter" , false);
    }

    public void BossBoom()
    {
        Debug.Log("PARIS");
        //Destroy(this.gameObject, 1.5f);
        DeathParticles.Stop();
        //DeathBlow.Play(); // Continue normal emissions
        DeathBlow.Play();
        //DeathBlow.Stop();
        //anim.SetBool("Jack", true);
        anim.GetComponent<SpriteRenderer>().sprite = JackSprite;
        anim.GetComponent<SpriteRenderer>().flipX = true;
        anim.enabled = false;
        StillAlive = true;
        HP = 0.000001f;
        BossGate.transform.position = Vector3.Lerp(BossGate.transform.position, GateOpen, 3f);
        BossGate.GetComponent<BoxCollider2D>().enabled = false;
        //MainCamera.GetComponent<HorizontalCameraScript>().BossDeath = false;
        //this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
        if(ProjectMaster.IActMissionNumber == 47)
        {
            ProjectMaster.IActMissionNumber = 48;
        }
    }
}
