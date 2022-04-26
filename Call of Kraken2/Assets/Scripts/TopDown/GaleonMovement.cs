using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GaleonMovement : MonoBehaviour
{

    public bool moving = false;

    private Vector3 targetPosition;
    private Vector3 iniTransformPosition;

    private float targetDistance;

    private float turnSpeed;
    private float moveSpeed;
    

    void Start()
    {
       

    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {


            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetDistance = Vector3.Distance(targetPosition, transform.position);
            iniTransformPosition = transform.position;

        
            moving = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            moving = false;
        }


        if (moving)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(transform.up * moveSpeed * Time.deltaTime);

            var newRotation = Quaternion.LookRotation(transform.position - targetPosition, Vector3.forward);
            newRotation.x = 0f;
            newRotation.y = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
        }
    }
}