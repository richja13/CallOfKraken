using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneScript : MonoBehaviour
{
    public List<GameObject> CursedSoldiers;
    public GameObject SonOfKraken;
    public DialogueManagerScript Dialog;
    public HorizontalCameraScript Cam;
    public ParticleSystem Particle;
    bool PlayParticles;
    public GameObject BackToShip;

    // Start is called before the first frame update
    void Start()
    {
        PlayParticles = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Dialog.Lol == false)
        {
            if(PlayParticles == true)
            {
                if(ProjectMaster.IActMissionNumber == 35)
                {
                    ProjectMaster.IActMissionNumber = 36;
                }
                PlayParticles = false;
                Particle.Play();
                BackToShip.SetActive(true);
                CursedSoldiers[0].SetActive(true);
                CursedSoldiers[1].SetActive(true);
                CursedSoldiers[2].SetActive(true);
            }
            SonOfKraken.SetActive(false);
        }
        else
        {
            SonOfKraken.SetActive(true);
           CursedSoldiers[0].SetActive(false);
            CursedSoldiers[1].SetActive(false);
          CursedSoldiers[2].SetActive(false);
          BackToShip.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Cam.OnBossArea = true;
            Dialog.CallDialog();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Cam.OnBossArea = false;
        }
    }
}
