using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalSceneScript : MonoBehaviour
{
    public IslandCamerScript CamScript;
    public Image Journal;
    public Collider2D PitCollision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Dziennik();
        }
    }

    void Dziennik()
    {
        Journal.rectTransform.anchoredPosition = new Vector2(0,0);

        if(ProjectMaster.IActMissionNumber == 13)
        {
            ProjectMaster.IActMissionNumber = 14;
        }
    }

    public void Dziennit()
    {
        Journal.rectTransform.anchoredPosition = new Vector2(0,3000);
        this.gameObject.SetActive(false);
    }
}
