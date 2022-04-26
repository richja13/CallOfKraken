using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    // Start is called before the first frame update

    public void CloseNote()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-393);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
