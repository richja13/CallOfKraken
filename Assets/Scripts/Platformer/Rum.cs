using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rum : MonoBehaviour
{
    public GameObject P;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        Collect Player = P.GetComponent<Collect>();
        if (collision.collider.tag == "Player")
        {
            
            Destroy(this.gameObject);
            //Player.RumBarells++;
        }

    }
}
