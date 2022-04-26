using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootL : MonoBehaviour
{
   
    public bool shoot;   
   private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "s_galeon")
        {
            shoot = true;
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "s_galeon")
        {
            shoot = false;
        }
    }
}
