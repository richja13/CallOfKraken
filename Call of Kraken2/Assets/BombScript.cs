using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject Boom;
    public GameObject BomberSkeleton;
    public GameObject ThrowPlace;
    public GameObject Player;
    public float speed = 5;
    private float FirePlaceX;
    private float targetX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    private bool BombCreated = false;


    // Start is called before the first frame update
    void Start()
    {
        BombCreated = false;
        //BomberSkeleton = GameObject.FindGameObjectWithTag("BomberSkeleton");
        ThrowPlace = GameObject.FindGameObjectWithTag("ThrowPlace");
        Player = GameObject.FindGameObjectWithTag("Player");

        
           

        //Debug.Log(targetX);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        height = 2 * (nextX - FirePlaceX) * (nextX - targetX)/(-0.25f * dist * dist);
        targetX = Player.transform.position.x;   
        dist = targetX - FirePlaceX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX,speed * Time.deltaTime);
        //baseY = Mathf.Lerp(ThrowPlace.transform.position.y, Player.transform.position.y,(nextX - FirePlaceX)/dist);

        Vector3 movePosition = new Vector3(nextX, transform.position.y, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        
        //FirePlaceX = ThrowPlace.transform.position.x;
        //targetX = Player.transform.position.x;
        //BombCreated = true;
        //dist = targetX - FirePlaceX;
        //nextX = Mathf.MoveTowards(transform.position.x, targetX,speed * Time.deltaTime);
        //baseY = Mathf.Lerp(ThrowPlace.transform.position.y, Player.transform.position.y,(nextX - FirePlaceX)/dist);
        //height = 2 * (nextX - FirePlaceX) * (nextX - targetX)/(-0.25f * dist * dist);


    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0,0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Boom,transform.position,transform.rotation);
        //Destroy(Boom, 0.5f);
        //Destroy(this.gameObject, 1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
