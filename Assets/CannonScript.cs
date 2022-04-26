using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private float Timer;
    public GameObject CannonBallRight;
    public GameObject CannonBallLeft;
    public Animator anim;
    private bool Shooted;
    public GameObject Lufa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Szut"))
        {
            if (Shooted)
            {
                Instantiate(CannonBallLeft, Lufa.transform.position, transform.rotation);
                Shooted = false;
            }
        }
        else
        {
            Shooted = true;
        }

    }
}
