﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public GameMasterScript gm;

    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMasterScript>();
    }

  void OnTriggerEnter2D(Collider2D collision)
  {
      if(collision.CompareTag("Player"))
      {
          gm.lastCheckPointPos = transform.position;
      }
  }
}
