using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Sprite OpenLeft;
    public Sprite OpenRight;
    public Sprite Closed;
    public SpriteRenderer SpR;
    public GameObject Player;
    public Collider2D coll;

    void Start()
    {
        coll = this.gameObject.GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        if(this.gameObject.GetComponent<DoorOpening>().enabled == true)
        {
            if (SpR.sprite == Closed && Player.transform.position.x < transform.position.x)
            {
                SpR.sprite = OpenRight;
                //coll.enabled = false;
                coll.isTrigger = true;

            }
            else if (SpR.sprite == Closed && Player.transform.position.x > transform.position.x)
            {
                SpR.sprite = OpenLeft;
                coll.isTrigger = true;
                //coll.enabled = false;
            }
            else if (SpR.sprite != Closed)
            {
                //coll.enabled = true;
                SpR.sprite = Closed;
                coll.isTrigger = false;
            }
        }
        else
        {
            SpR.sprite = Closed;
            coll.isTrigger = false;
        }
    }
}
