using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCannonsRangeScript : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public bool LeftClicked;
    public bool RightClicked;
    public Button LeftButton;
    public Button RightButton;
    // Start is called before the first frame update
    void Start()
    {
        OnRightExit();
        OnLeftExit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRightEnter()
    {
        StartCoroutine("FadeInRight");
    }

    public void OnRightExit()
    {
        StartCoroutine("FadeOutRight");
    }


    public void OnLeftEnter()
    {
        StartCoroutine("FadeInLeft");
    }

    public void OnLeftExit()
    {
        StartCoroutine("FadeOutLeft");
    }



       IEnumerator FadeOutLeft()
    {
        for (float f = 0.5f; f >= -0.05f; f -= 0.5f)
        {
            Color a = Left.GetComponent<SpriteRenderer>().color;
            Color c = Left.GetComponent<SpriteRenderer>().color;
            c.a = f;
            //a.a = f;
            Left.GetComponent<SpriteRenderer>().color = c;
            //Left.GetComponent<SpriteRenderer>().color = a;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator FadeInLeft()
    {
        for (float f = 0.05f; f <= 0.5f; f += 0.2f)
        {
            Color a = Left.GetComponent<SpriteRenderer>().color;
            Color c = Left.GetComponent<SpriteRenderer>().color;
            c.a = f;
            //a.a = f;
            Left.GetComponent<SpriteRenderer>().color = c;

            yield return new WaitForSeconds(0.005f);
        }
    }

      IEnumerator FadeOutRight()
    {
        for (float f = 0.5f; f >= -0.05f; f -= 0.5f)
        {
            Color a = Right.GetComponent<SpriteRenderer>().color;
            Color c = Right.GetComponent<SpriteRenderer>().color;
            c.a = f;
            //a.a = f;
            Right.GetComponent<SpriteRenderer>().color = c;
            //Left.GetComponent<SpriteRenderer>().color = a;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator FadeInRight()
    {
        for (float f = 0.05f; f <= 0.5f; f += 0.2f)
        {
            Color a = Right.GetComponent<SpriteRenderer>().color;
            Color c = Right.GetComponent<SpriteRenderer>().color;
            c.a = f;
            //a.a = f;
            Right.GetComponent<SpriteRenderer>().color = c;

            yield return new WaitForSeconds(0.005f);
        }
    }
}
