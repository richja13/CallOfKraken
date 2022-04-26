using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    private GameMasterScript instance;
    public Vector2 lastCheckPointPos;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollision2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.transform.position = lastCheckPointPos;
        }
    }

}
