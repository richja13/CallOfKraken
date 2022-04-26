using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {

     
        
    }
 IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1f; f += 0.01f)
        {
            Color a = this.gameObject.GetComponent<SpriteRenderer>().color;
            a.a = f;
            this.gameObject.GetComponent<SpriteRenderer>().color = a;

            yield return new WaitForSeconds(0.005f);
        }
    }

    

}
