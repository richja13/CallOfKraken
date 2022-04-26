using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OutPostScript : MonoBehaviour
{

    public RectTransform IslandButton;
    // Start is called before the first frame update
    void Start()
    {
        IslandButton = GameObject.FindGameObjectWithTag("Door").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Vector2.Distance(transform.position, collision.gameObject.transform.position) < 200f)
        {
            IslandButton.anchoredPosition = new Vector2(193,31);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IslandButton.anchoredPosition = new Vector2(287, -300);
        }
    }
}
