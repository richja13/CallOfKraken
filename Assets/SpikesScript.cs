using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikesScript : MonoBehaviour
{
    
    private float Timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(Timer > 0)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
            Timer -= 0.1f;
        }
        else
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            Timer = 5;
        }

        

    }

   /* void OnCollisionEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }
    */
}
