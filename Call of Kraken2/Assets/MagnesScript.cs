using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnesScript : MonoBehaviour
{
    Transform Player;
    public float Distance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("GaleonSprite").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(Player.position, transform.position) < Distance)
        {
            transform.position = Vector2.Lerp(transform.position, Player.position, Time.deltaTime * 6f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
