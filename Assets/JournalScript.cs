using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    public ParticleSystem PicUpParticles;
    public RectTransform Note;
    public GameObject arrow;
    public GameObject hiddencave;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Note.anchoredPosition = new Vector2(0,209);
            if(ProjectMaster.IActMissionNumber == 3)
            {
                ProjectMaster.IActMissionNumber = 4;
            }
            Instantiate(PicUpParticles, transform.position, transform.rotation);
            arrow.SetActive(true);
            hiddencave.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
