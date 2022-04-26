using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;


    void Update()
    {
        speed = Random.Range(50f, 150f);
        rb.velocity = -transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
