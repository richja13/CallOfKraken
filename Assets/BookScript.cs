using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{
    public ParticleSystem PicUpParticles;
    public RectTransform Note;
    public GameObject Arrow;

    void Start()
    {
        Arrow.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(ProjectMaster.IActMissionNumber == 11)
            {
                ProjectMaster.IActMissionNumber = 12;
            }
            
            Note.anchoredPosition = new Vector2(0,225);
            //ProjectMaster.IActMissionNumber = 4;
            //Instantiate(PicUpParticles, transform.position, transform.rotation);
            //Destroy(this.gameObject);
            Arrow.SetActive(true);
        }
    }
}
