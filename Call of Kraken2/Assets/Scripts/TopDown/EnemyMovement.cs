using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public float speed;
    public bool moveRight;

    private void Update()
    {
       if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0, 0);
           // zmiana skali obiektu --> transform.localScale = new Vector2(-2, 2);
        }
       else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            //transform.localScale = new Vector2(-2, 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }

}
