using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackScene : MonoBehaviour
{
    public GameObject LastChest;
    public GameObject Jack;
    bool CanDestroy;
    public DialogueManagerScript Dialog;
    // Start is called before the first frame update
    void Start()
    {
        CanDestroy = true;
        LastChest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(LastChest == null && CanDestroy)
        {
            if(ProjectMaster.IActMissionNumber == 46)
            {
                ProjectMaster.IActMissionNumber = 47;
            }
            FreeJack();
            CanDestroy = false;
        }
    }

    public void CreateChest()
    {
        LastChest.SetActive(true);
    }

    public void FreeJack()
    {
        Jack.GetComponent<SonOfKrakenScript>().BossBoom();
        Invoke("StartDialog", 3f);
    }

    public void StartDialog()
    {
        Dialog.CallDialog();
    }

}
