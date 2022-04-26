using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveScript : MonoBehaviour
{
    public Tilemap CaveChildrens1;
    public Tilemap CaveChildrens2;

    SpriteRenderer rend;


    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color a = CaveChildrens2.color;
            Color c = CaveChildrens1.color;
            c.a = f;
            a.a = f;
            CaveChildrens1.color = c;
            CaveChildrens2.color = a;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color a = CaveChildrens2.color;
            Color c = CaveChildrens1.color;
            c.a = f;
            a.a = f;
            CaveChildrens1.color = c;
            CaveChildrens2.color = a;

            yield return new WaitForSeconds(0.005f);
        }
    }

        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {


                StartCoroutine("FadeOut");

                //Debug.Log("NIEZNAJOMY");
                //CaveChildrens1.color = Color.clear;
                // CaveChildrens2.color = Color.clear;


            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine("FadeIn");

                //StartCoroutine("FadeOut");

                //CaveChildrens1.color = Color.white;
                // CaveChildrens2.color = Color.white;
            }
        }
    }

