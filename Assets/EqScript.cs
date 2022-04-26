using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EqScript : MonoBehaviour
{
    private bool OpenEq;
    private RectTransform transRect;

    int Money,sugar,rum,tea;
    public Text MoneyText,SugarText,RumText,TeaText,BoatAttackText,AttacText,BoatHpText,HpText,StaminaText,CrewText;
    
    public List<GameObject> Keys;
    
    public SceneTransitionAnimationScript Transition;
    public GameObject MuteButton;
    public Sprite Mute;
    public Sprite UnMute;

    // Start is called before the first frame update
    void Start()
    {
        transRect = GetComponent<RectTransform>();
        OpenEq = false;
        Transition = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitionAnimationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenEq == false && this.gameObject.GetComponent<RectTransform>().position == new Vector3(0,0,0))
        {
            this.gameObject.GetComponent<RectTransform>().position = new Vector3(3000,3000,0);
        }


        Money = PlayerStatsScript.Money;
        sugar =  PlayerStatsScript.Sugar;
        rum =  PlayerStatsScript.Rum;
        tea =  PlayerStatsScript.Tea;

        MoneyText.text = "$" + Money;
        SugarText.text = "+" + sugar;
        RumText.text = "+" + rum;
        TeaText.text  = "+" + tea;

        switch (PlayerStatsScript.KeysCollected)
        {
            case 0:
                for(var i = 0; i < Keys.ToArray().Length; i++)
                {
                    Keys[i].SetActive(false);
                }
            break;

            case 1:
                //Keys[0].SetActive(true);
            break;            

            case 2:
                Keys[0].SetActive(true);
                Keys[1].SetActive(true);
            break;

            case 3:
                Keys[0].SetActive(true);
                Keys[1].SetActive(true);
                Keys[2].SetActive(true);
            break;

            case 4:
                Keys[0].SetActive(true);
                Keys[1].SetActive(true);
                Keys[2].SetActive(true);
                Keys[3].SetActive(true);
            break;

        }

        BoatAttackText.text = "Attack" + "\n" + PlayerStatsScript.BoatAttack;
        AttacText.text = "Attack" + "\n" + PlayerStatsScript.AttackDmg;
        BoatHpText.text = "Hp" + "\n" + PlayerStatsScript.BoatHp;
        HpText.text = "Hp" + "\n" + PlayerStatsScript.Hp;
        StaminaText.text = "Flintlock" + "\n" + PlayerStatsScript.GunDamage * 10; 
        CrewText.text = "Crew" + "\n" + PlayerStatsScript.BoatCrew;


        if(OpenEq)
        {
           
            GetComponent<RectTransform>().anchoredPosition = new Vector2(transRect.anchoredPosition.x, 0);
        }
        else if(!OpenEq)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(transRect.anchoredPosition.x, -1500);
        }

    }

    public void OpenEQ()
    {
        if (OpenEq == false)
        {
            Time.timeScale = 0.1f;
            OpenEq = true;
        }
        else if (OpenEq == true)
        {
            Time.timeScale = 1;
            OpenEq = false;
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RESTART()
    {
        Transition.SceneName = Transition.Current;
        Transition.ChangeScene();
        Time.timeScale = 1;
    }
    
    public void MuteAll()
    {
        if(AudioListener.pause == false)
        {
            AudioListener.pause = true;
            MuteButton.GetComponent<Image>().sprite = Mute;
        }
        else if(AudioListener.pause == true)
        {
            AudioListener.pause = false;
            MuteButton.GetComponent<Image>().sprite = UnMute;
        }
    }

}
