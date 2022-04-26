using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSwordScript : MonoBehaviour
{
    public Sprite BrokenSword;
    public GameObject Player;
    public GameObject HidenExit;
    public GameObject Arrow;
    public ParticleSystem BoomParticles;
    static int canBeDestroyed = 1;
    public CamShake CameraShake;

    // Start is called before the first frame update
    void Awake()
    {
        //canBeDestroyed = PlayerPrefs.GetInt("CanBeDestroyed");
    }

    void Start()
    {
       // if(ProjectMaster.IActMissionNumber == 12)
       // {
            //ProjectMaster.IActMissionNumber = 13;
        //}
    }
    
    void Update()
    {
        if(canBeDestroyed == 1)
        {
            if(Vector2.Distance(transform.position, Player.transform.position) <= 0.4f)
            {
                if(Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack") || Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attack2"))
                {
                    canBeDestroyed = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BrokenSword;
                    BoomParticles.Play();
                    HidenExit.SetActive(false);
                    Arrow.SetActive(false);
                    CameraShake.Shake(0.2f,1.5f);
                    if(ProjectMaster.IActMissionNumber == 37)
                    {
                        ProjectMaster.IActMissionNumber = 39;
                    }
                }
            }
        }
    }
}
