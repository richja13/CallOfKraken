using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortScript : MonoBehaviour
{
    public GameObject PlayerShip;
    public GameObject EnemyShip;
    public GameObject[] Cannons;
    public GameObject CannonBall;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(CannonBall,Cannons[1].transform.position,Cannons[1].transform.rotation);
            Instantiate(CannonBall,Cannons[2].transform.position,Cannons[2].transform.rotation);
            Instantiate(CannonBall,Cannons[3].transform.position,Cannons[3].transform.rotation);
            Instantiate(CannonBall,Cannons[4].transform.position,Cannons[4].transform.rotation);
            Instantiate(CannonBall,Cannons[5].transform.position,Cannons[5].transform.rotation);
            Instantiate(CannonBall,Cannons[6].transform.position,Cannons[6].transform.rotation);
            Instantiate(CannonBall,Cannons[7].transform.position,Cannons[7].transform.rotation);

        }
    }
}
