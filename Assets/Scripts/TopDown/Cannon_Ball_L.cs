using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball_L : MonoBehaviour
{
    public ParticleSystem HitParticle;
    public float speed;
    public Rigidbody2D rb;
  
    void Update()
    {
        speed = Random.Range(50f, 150f);
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip" || collision.gameObject.tag == "RoyalNavyShip" || collision.gameObject.tag == "MichaelsFleet")
        {
            var ParticleRotation = transform.rotation;
            ParticleRotation.z = transform.rotation.z - 180;
            Instantiate(HitParticle, transform.position, ParticleRotation);
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

