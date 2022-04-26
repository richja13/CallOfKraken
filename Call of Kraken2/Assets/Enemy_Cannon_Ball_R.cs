using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy_Cannon_Ball_R : MonoBehaviour
{
    public ParticleSystem HitParticle;
    public float speed;
    public Rigidbody2D rb;


    void Update()
    {
        speed = Random.Range(50f, 150f);
        rb.velocity = transform.up * speed;
    }


  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "s_galeon")
        { 
            var ParticleRotation = transform.rotation;
            ParticleRotation.z = transform.rotation.z - 180;
            Instantiate(HitParticle, transform.position, ParticleRotation);
            Invoke("DestroyObject", 3f);
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            CameraShaker.Instance.ShakeOnce(1f, 2f, 2f, 0.5f);
        }
        
    }
    void OnBecameInvisible()
    {   
        Invoke("DestroyObject", 3f);
    }


    void DestroyObject ()
    {
        Destroy(gameObject);
    }
}

