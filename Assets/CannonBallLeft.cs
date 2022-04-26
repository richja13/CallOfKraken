using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLeft : MonoBehaviour
{
    public Rigidbody2D R;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        R.AddForce(Vector2.left * 2 * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
