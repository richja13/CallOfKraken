using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPopUpScript : MonoBehaviour
{
    bool smaller;
    // Start is called before the first frame update
    void Start()
    {
        smaller = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.up * 20) * Time.deltaTime;
        Invoke("DestroyObject",0.5f);

       if(transform.localScale.x == 0)
       {
            Destroy(this.gameObject);
       }
    }

    void DestroyObject()
    {
        //if(smaller)
        //{
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(transform.localScale.x * 0, transform.localScale.y * 0), Time.deltaTime * 5f);
            //smaller = false;
        //}
    }
}
