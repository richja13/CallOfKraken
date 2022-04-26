using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator anim ;
    public float horizontal = 0f;
    public bool isGrounded;
    public int DoubleJump = 1;
    public bool moving = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
   

    // Update is called once per frame
    void Update()
    {
        if (moving == true)
        {
            anim.SetFloat("Move", Mathf.Abs(Input.GetAxis("Horizontal")));
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            Jump();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")  && DoubleJump <= 2)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 18f), ForceMode2D.Impulse);
            DoubleJump++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
           
            DoubleJump = 1;
        }
    }


}
