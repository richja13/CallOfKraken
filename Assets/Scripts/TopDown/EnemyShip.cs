using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 iniTransformPosition;
    public GameObject Player;
    public GameObject Player2;
    private float targetDistance;
    public float Speed;
    public float turning;
    private float turnSpeed;
    public float moveSpeed;
    public bool moving;
    public GameObject Sprite;
    public GameObject Acceletator;
    public float distance;
    public float Time1;
    public GameObject ChildPosition;
    public GameObject PlayerPosition;
    public float PlayerSpeed;
    public float PpDistance;
    public bool FireMode;
    private Vector3 PlayerLastPosition;
    public bool TimerTrue;
    public bool TestowyTimer;
    public float TIMER1;
    public float Hp;
    public float MaxHp;
    public bool Abord = false;
    public Button AbordButton;
    public Button AbordSloop;
    private bool Finish;
    private bool Finished;
    public bool Boss;
    public ParticleSystem DestroyShipParticle;
    public ShipsSpawnerScript Spawn;
    public GameObject MoneyBox;
    public Transform HealtBar;
    public bool MissionShip;
    public bool BFast;
    public Material HitMaterial;
    public Material NormalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        if(!Boss || !MissionShip)
        {
            if(GetComponent<Renderer>().isVisible)
            {
                Spawn.ShipsInAttack -= 0.5f;
                Destroy(this.gameObject);
            }
        }


        Hp = MaxHp;
        PlayerLastPosition = Player.transform.position;
        //ChildPosition = this.gameObject.transform.Find("PlayerPosition").gameObject;
        //moving = true;
        Speed = Random.Range(15, 31);
        turnSpeed = Random.Range(0.005f, 0.016f);
    }

    void Awake()
    {
        if(!Boss || !MissionShip)
        {
            Spawn = GameObject.FindGameObjectWithTag("ShipsRange").GetComponent<ShipsSpawnerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!MissionShip)
        {
            if(Vector2.Distance(Player.transform.position, transform.position) > 350 && Spawn == true)
            {
                DestroyShip();
                Destroy(this.gameObject);
            }
        }
        
        if (Hp <= 0)
        {
            Abord = true;
        }

        if(HealtBar.transform.localScale.x > 0)
        {
            HealtBar.transform.localScale = new Vector2(Hp/MaxHp, 1);
        }
        else
        {
            HealtBar.transform.localScale = new Vector2(0,0);
        }

        if (Abord == false)
        {
            PlayerSpeed = Player2.GetComponent<Ship_Move>().moveSpeed;

            distance = Vector2.Distance(transform.position, PlayerPosition.transform.position);

            Time1 = (distance / Speed);

            if (moving == true)
            {
                var Fire = new Vector3(Player.transform.position.x, PlayerPosition.transform.position.y + 2,
                Player.transform.position.z);
                targetPosition = PlayerPosition.transform.position;
               // targetPosition = Fire;
                targetDistance = Vector2.Distance(targetPosition, transform.position);
                iniTransformPosition = transform.position;


               SpeedFunction();


                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddRelativeForce(Vector3.up * moveSpeed / 23);

                //transform.Translate(Vector3.up * Time.deltaTime * 12);

                var newRotation = Quaternion.LookRotation(transform.position - targetPosition, Vector3.forward);
                newRotation.y = 0f;
                newRotation.x = 0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
                //transform.rotation = Quaternion.Slerp(newRotation, transform.rotation, Time.deltaTime * turnSpeed);
            }
            
            PpDistance = (PlayerSpeed * Time1) / 240;

            PlayerPosition.transform.position = Player2.transform.TransformPoint(0, PpDistance + 28, 0);
            PlayerPosition.transform.localRotation = Player.transform.rotation;
        }
        else
        {
            if(Finish == true)
            {
                if(!Boss)
                {
                    DestroyShip();
                }
                else
                {
                    this.gameObject.GetComponent<EnemyCannons>().enabled = false;
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }

       
    }
    

    public void NormalMaterialFunction()
    {
          this.gameObject.GetComponent<SpriteRenderer>().material = NormalMaterial;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag != "ShipsRange")
        {
            //Spawn.ShipsInAttack -= 0.5f;
            Debug.Log("ORTALION");
            Destroy(this.gameObject);
        }
        */

        if (Abord == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                moving = true;
            }
            else
            {
                //TIMER1 = 0;
                FireMode = false;
                //TimerTrue = false;
            }

            if (collision.gameObject.name == "FireActivator")
            {
                TimerTrue = true;
                // Quaternion Rotation = Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y, Player.transform.localRotation.z + 90);

                Rigidbody2D rb = GetComponent<Rigidbody2D>();

                if (TimerTrue == true)
                {
                    TIMER1 += 3f;
                }

                if (TIMER1 >= 40)
                {
                    FireMode = true;
                    moving = false;
                }

                if (FireMode == true && Player2.GetComponent<Rigidbody2D>().velocity.magnitude <= 10)
                {
                    float angle = Mathf.Atan2(transform.position.y - Player.transform.position.y, transform.position.x - Player.transform.position.x) * Mathf.Rad2Deg;
                    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed / 9);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                    moving = false;
                    if (TIMER1 >= 120)
                    {
                        //transform.RotateAround(PlayerLastPosition, Vector3.forward , 12 * Time.deltaTime);
                    }
                }
                else if (FireMode == true && Player2.GetComponent<Rigidbody2D>().velocity.magnitude > 10)
                {
                    PlayerLastPosition = Player.transform.position;
                    //Quaternion Fire = Quaternion.Euler(Player.transform.position.x + 4, ChildPosition.transform.position.y, Player.transform.position.z);
                    // Quaternion Fire = Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y, Player.transform.rotation.z);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Fire, turnSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Player2.transform.rotation,
                    turnSpeed / 40 * Time.deltaTime * 5);
                    //targetPosition = Fire;
                    moving = false;
                    rb.AddRelativeForce(Vector3.up * moveSpeed / 80);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Fire, turnSpeed * Time.deltaTime);
                }
                //else
                //{

                //Debug.Log("sZAJK");
                //PlayerLastPosition = Player.transform.position;
                //}

            }
            else
            {
                TimerTrue = false;
            }
        }
        else
        {
            Invoke("Finisher",0f);
           
            if (collision.gameObject.tag == "Player")
            {
                if(Boss)
                {
                    if(Finish == true)
                    {
                        AbordButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, 28);
                        AbordSloop.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, 86);

                        if(ProjectMaster.IActMissionNumber == 15)
                        {
                            ProjectMaster.IActMissionNumber = 16;
                        }
                    }
                    else
                    {
                        AbordButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, -100);
                        AbordSloop.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, -213);
                    }


                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        AbordShip();
                    }
                }
            }
        }
    } 
    //*/
    
    public void Finisher()
    {
        if(Finished == false)
        {
            Finished = true;
            Finish = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AbordButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, -100);
            AbordSloop.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, -200);
        }
    }

  


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            Hp -= 10 * (PlayerStatsScript.BoatAttack/10);
            Mig();
        }

        if(Finish && collision.gameObject.tag == "CannonBall")
        {
            if(!Boss)
            {
                DestroyShip();
            }
        }
    }

    void Mig()
    {
        this.gameObject.GetComponent<SpriteRenderer>().material = HitMaterial;
        Invoke("NormalMaterialFunction", 0.25f);
    }

    
    void DestroyShip()
    {
        var a = Instantiate(MoneyBox,transform.position,transform.rotation);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear; // dodac fade effect
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(this.gameObject,2f);
        Spawn.ShipsInAttack -= 0.5f;
        DestroyShipParticle.Play();
        Finish = false;
    }

    public void AbordShip()
    {
        SceneManager.LoadScene("ShipPlatform-YoungRoboKomp");
    }

    public void AbordSloopShip()
    {
        SceneManager.LoadScene("SloopScene");
    }


    void SpeedFunction()
    {
        if(Vector2.Distance(transform.position, Player.transform.position) > 80)
        {
            BFast = true;
        }

        if(!BFast)
        {
            moveSpeed = (Speed * 25);
            turnSpeed = (turning * targetDistance);
        }
        else
        {
            moveSpeed = (Speed * targetDistance) / 3;
            turnSpeed = (turning * targetDistance);

            if(Vector2.Distance(transform.position, Player.transform.position) < 55)
            {
                Debug.Log("GŁUPI JASIO");
                BFast = false;
            }
        }
    }
}

        
          

