using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersScript : MonoBehaviour
{
    private RectTransform Sliders;
    private Vector2 StartPos;
    private Vector2 NewPos;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Sliders = this.gameObject.GetComponent<RectTransform>();
        StartPos = Sliders.anchoredPosition;
        NewPos = new Vector2(0,125);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Shooting>().Shooting_mode == false)
        {
            Sliders.anchoredPosition = Vector2.Lerp(Sliders.anchoredPosition,StartPos, 0.2f);
        }
        else
        {
            Sliders.anchoredPosition = Vector2.Lerp(Sliders.anchoredPosition, NewPos , 0.2f);
        }
    }
}
