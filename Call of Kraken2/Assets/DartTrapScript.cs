using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrapScript : MonoBehaviour
{
    private bool CanShoot = true;
    public GameObject Dart;
    public GameObject FirePosition1;
    public GameObject FirePosition2;
    public GameObject FirePosition3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.007f);
        CanShoot = false;
        Instantiate(Dart, FirePosition1.transform.position, FirePosition1.transform.rotation);
        Instantiate(Dart, FirePosition2.transform.position, FirePosition2.transform.rotation);
        Instantiate(Dart, FirePosition3.transform.position, FirePosition3.transform.rotation);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.007f);
        CanShoot = true;
    }
}
