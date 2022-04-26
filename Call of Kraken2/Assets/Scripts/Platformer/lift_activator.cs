using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift_activator : MonoBehaviour
{
    [SerializeField] 
    private Vector3 velocity;
    public float timer = 0f;
    public bool moving;
    private bool timerstart = false;
    public GameObject Player;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (timerstart)
            {
                timer++;
                if (timer > 0f && timer < 82f)
                {
                    moving = true;
                    Player.GetComponent<PirateMovement>().moving = false;
                }
                else
                {
                    moving = false;
                    Player.GetComponent<PirateMovement>().moving = true;
                }
                if (timer == 82f)
                {
                    Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 27f), ForceMode2D.Impulse);
                    timerstart = false;
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            if (collision.gameObject.tag == "Player")
            {
                timerstart = true;

            }
        
    }


   
    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }

}
