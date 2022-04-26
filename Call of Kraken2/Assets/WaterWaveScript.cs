using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveScript : MonoBehaviour
{
    private float Timer = 1.68f;
    private bool CanMove;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            MoveToRandomPosition();
        }

        Timer -= Time.fixedDeltaTime;

        if (Timer <= 0)
        {
            Timer = 0;
            CanMove = true;
        }

        if (CanMove == true)
        {
            CanMove = false;
            Timer = 1.7f;
            //MoveToRandomPosition();
        }
    }

    void MoveToRandomPosition()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        transform.position = screenPosition;

    }

}
