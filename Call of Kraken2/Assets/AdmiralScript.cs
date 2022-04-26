using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmiralScript : MonoBehaviour
{
    MichaelScript MainScript;
    PlayerMovement PlayerScript;
    public GameObject Sword;
    public Transform throwPlace;

    // Start is called before the first frame update
    void Start()
    {
        Sword.SetActive(false);
        MainScript = this.gameObject.GetComponent<MichaelScript>();
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MainScript.HP <=  1)
        {
            MainScript.admiral = true;
            this.gameObject.GetComponent<Animator>().SetTrigger("Shoot");
            PlayerScript.HpBar.value = 0.3f;
            PlayerScript.GetComponent<Animator>().SetBool("Det", true);
            PlayerScript.enabled = false;
            
            if(ProjectMaster.IActMissionNumber == 33)
            {
                ProjectMaster.IActMissionNumber = 34;
            }
        }
    }

    public void ThrowSword()
    {
        Sword.SetActive(true);
    }

    public void GrabSword()
    {
        Sword.SetActive(false);
    }
}
