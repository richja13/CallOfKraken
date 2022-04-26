using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    RectTransform canvas;
    RectTransform HealthBar;
    Vector3 startingPosition;
    public float speed;
    public bool HealtDamage;
    public GameObject s_galeon;
    void Start()
    {
        HealthBar = this.gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = transform.position;
        speed = -3f;
    }

    void Update()
    {
        HealtDamage = s_galeon.GetComponent<Ship_hp>().HealthDamage;
        if (HealtDamage == true)
        {
            if (HealthBar.anchoredPosition.y > -10)
            {
                transform.Translate(0f, speed, 0f);
                //transform.position = new Vector3(startingPosition.x, canvas.rect.height + HealthBar.rect.height, startingPosition.z);
            }
        }
        else
        {
            if (HealthBar.anchoredPosition.y <= 200)
            {
                transform.Translate(0f, 5, 0f);
            }
        }
    }
}

