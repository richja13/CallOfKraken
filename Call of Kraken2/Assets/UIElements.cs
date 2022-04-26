using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElements : MonoBehaviour
{
    public GameObject Player;

    public void OnMouseDown()
    {
        Player.GetComponent<Ship_Move>().CursorOnUI = true;
    }

    public void OnMouseExit()
    {
        Player.GetComponent<Ship_Move>().CursorOnUI = false;
    }
}
