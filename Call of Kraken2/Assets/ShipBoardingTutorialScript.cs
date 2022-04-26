using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoardingTutorialScript : MonoBehaviour
{
  
  static bool canOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canOpen)
        {
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3000,-3000);
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0.5f;
        }
    }

    public void CloseMenu()
    {
        canOpen = false;
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3000,-3000);
    }
}
