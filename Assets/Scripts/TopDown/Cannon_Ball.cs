using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball : MonoBehaviour
{ 
    public float speed = 20f;
    [SerializeField] Transform cannon_r;
    public Rigidbody2D rb;




    void Start()
    {



    }

    void Update()
    {
        rb.velocity = cannon_r.up  * speed;
    }
}
