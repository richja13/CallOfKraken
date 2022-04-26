using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberSkeletonScript : MonoBehaviour
{
    public GameObject Player;
    private float ThorwRange = 2.5f;
    public GameObject Bomb;
    public GameObject ThrownPlace;
    public bool CanThrow = true;
    public Animator anim;
    public ParticleSystem Blood;
    public GameObject HpBar;
    public float HpValue;
    private bool BombTimer;
    private float BombCreateTime;

    // Start is called before the first frame update
    void Start()
    {
        BombCreateTime = 0;
        CanThrow = true;
        HpValue = 1;
        Physics.IgnoreLayerCollision(1,15);
    }

   /* void Update()
    {
            if(Player.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector2(0,0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0,180);
            }
    }
*/

    // Update is called once per frame

    void Update()
    {
        if(BombCreateTime <= 0)
        {
            BombCreateTime = 0;
            CanThrow = true;
        }

            if(Player.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector2(0,0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0,180);
            }

        if( 2.5f > Vector2.Distance(transform.position, Player.transform.position))
        {
            BombCreateTime -= 0.5f;
            anim.SetBool("Run", false);
        }
        else
        {
        
       /*  if(Player.transform.position.x > transform.position.x)
            {
                MoveToRight();
            }
            else
            {
                MoveToLeft();
            }
         */   
        }


        //NAPRAWIC BOBMER SKELETONA !!!!!!!!!!!!!!!!!!!!

        if(2.5f > Vector2.Distance(transform.position, Player.transform.position) &&  0.8f < Vector2.Distance(transform.position, Player.transform.position)  )
        {
            if(transform.eulerAngles.y == 180)
            {
                MoveToLeft();    
            }
            else
            {
                MoveToRight();
            }
        }

        if(HpValue <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("DestroyObject", 0.4f);
        }
        

        if(HpBar.transform.localScale.x > 0)
        {
            HpBar.transform.localScale = new Vector2(HpValue, 1);
        }
        else
        {
            HpBar.transform.localScale = new Vector2(0, 0);
        }

        if(Vector2.Distance(transform.position, Player.transform.position) <= ThorwRange && CanThrow)
        {
            anim.SetTrigger("rzut");
            //Invoke("CreateBomb", 0.5f);
        }

        if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Invoke("ChangeColor", 0.3f);
        }

        if(!CanThrow)
        {
            anim.ResetTrigger("rzut");
        }
    }

    void CreateBomb()
    {
        
        BombCreateTime = 40;
        CanThrow = false;
        GameObject newBomb = Instantiate(Bomb, ThrownPlace.transform.position, transform.rotation);
        if(transform.eulerAngles.y == 180)
        {
            //newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.7f, 1.5f);
        }
        else
        {
              //newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(1.7f, 1.5f);
        }
        
    }

    public void MoveToRight()
    {  
       // transform.Translate(Vector2.right * Time.deltaTime * 2);

        transform.rotation = Quaternion.Euler(0,0,0);
        anim.SetBool("Run", true);
       
    }

    public void MoveToLeft()
    {
       
        transform.Translate(Vector2.right * Time.deltaTime * 1f);
        transform.rotation = Quaternion.Euler(0, -180, 0);
        anim.SetBool("Run", true);    

    }
    void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void DestroyObject()
    {
       // Destroy(this.gameObject);
    }
   
    void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            HpValue -= 0.4f;
            GetComponent<SpriteRenderer>().color = Color.red;
            Blood.Emit(1);
        }
    }

}
