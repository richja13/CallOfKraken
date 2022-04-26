using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed;
    public float Distance;
    public float Time1;
    private float Turn;
    private Vector2 position;
    private Vector2 targetPosition;
    public GameObject EnemyShip;
    private float EnemySpeed;
    public Transform PlayerRotation;
    
    // Start is called before the first frame update
    void Start()
    {
//        transform.localPosition = Player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        

        // transform.localRotation = Player.transform.rotation;
        // transform.rotation = PlayerRotation.rotation;


        // GetComponent<Rigidbody2D>().velocity = new Vector2(0, Distance);


        // transform.position = new Vector2 (Player.transform.localPosition.x , Player.transform.localPosition.y + Distance);
         

        //transform.position = transform.up;
       // transform.up = new Vector2(Player.transform.position.x, Player.transform.position.y);

        // transform.rotation = Quaternion.FromToRotation(new Vector2(Player.transform.position.x, Player.transform.position.y + Distance), Player.transform.forward); 
        // PlayerRotation = Player.GetComponent<Ship_Move>().AcceleratorQuanternion;

        EnemySpeed = EnemyShip.GetComponent<EnemyShip>().moveSpeed;

        
        MoveSpeed = Player.GetComponent<Ship_Move>().moveSpeed;

        targetPosition = Player.GetComponent<Ship_Move>().targetPosition;


        // Debug.Log(Distance);

        Time1 = EnemyShip.GetComponent<EnemyShip>().Time1;
        

         // s = V * t
         Distance = MoveSpeed * Time1 / 160;
         

        
                 //Debug.Log(Time1);
                //Vector2 postion = new Vector2 (0, Time1);
               //this.transform.Translate(position * Time.deltaTime, Space.World);
               
        

    }
}
