using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    public Image PlayerIcon;
    public GameObject Player;
    public bool OpenMap;
    private RectTransform MapRtransform;
    private RectTransform IconRtransform;

    // Start is called before the first frame update
    void Start()
    {
        MapRtransform = GetComponent<RectTransform>();
     
    }

    // Update is called once per frame
    void Update()
    {
      
        if (OpenMap == true)
        {
            MapRtransform.anchoredPosition = new Vector2(-5f, 5f);
            PlayerIcon.rectTransform.anchoredPosition = new Vector2(((Player.transform.position.x + (400 * 3) ) / 5f)/2.57143f, ((Player.transform.position.y - (130 * 3) )/ 5f)/2.5714f);
            /* transform.position = new Vector2(955, 535);
             //PlayerIcon.transform.position = new Vector2(PlayerIcon.transform.position.x + 1121f, PlayerIcon.transform.position.y + 1195f);
             PlayerIcon.rectTransform.position = new Vector2(((Player.transform.position.x - this.gameObject.transform.position.x)/5f) + (1121 * 1.2f), ((Player.transform.position.y - this.gameObject.transform.position.y - 4576)/5f) + (1195 * 1.25f));
             */
        }
        else if(OpenMap == false)
        {
            MapRtransform.anchoredPosition = new Vector2(-1200,-1200);


            PlayerIcon.rectTransform.anchoredPosition = new Vector2(Player.transform.position.x / 5f, Player.transform.position.y / 5f) - new Vector2(-1200, -1200);
            /*
            transform.position = new Vector2(-166,  -660);
            PlayerIcon.rectTransform.position =
                new Vector2((Player.transform.position.x - this.gameObject.transform.position.x) / 5f,
                    (Player.transform.position.y - this.gameObject.transform.position.y - 4576) / 5f);
                    */
        }
        
        //PlayerIcon.rectTransform.position = Player.transform.position/5;
        //PlayerIcon.rectTransform.position = new Vector2((Player.transform.position.x - this.gameObject.transform.position.x)/5f, (Player.transform.position.y - this.gameObject.transform.position.y - 4576)/5f);
    }
    
    public void MapOn()
    {
        if (OpenMap == false)
        {
            OpenMap = true;
        }
        else if(OpenMap == true)
        {
            OpenMap = false;
        }
        
    }
    
}
