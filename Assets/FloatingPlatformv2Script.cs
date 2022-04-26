using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformv2Script : MonoBehaviour
{
    public Vector2 StartingPosition;
    public Vector2 EndingPosition;
    public bool direction;


    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        EndingPosition = new Vector2(transform.position.x - 3f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= StartingPosition.x)
        {
            direction = false;
        }

        if (transform.position.x <= EndingPosition.x)
        {
            direction = true;
        }

        if (direction)
        {
            transform.position = new Vector2(transform.position.x + 0.6f * Time.deltaTime , StartingPosition.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 0.6f * Time.deltaTime, StartingPosition.y);
        }




    }
}
