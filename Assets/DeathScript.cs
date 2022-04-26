using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public GameObject Player;
    public RectTransform DeathScreen;
    public GameObject RedScreen;
    public SceneTransitionAnimationScript SceneManager;
    public AudioSource DeathSound;
    public AudioSource ButtonClick;
    public bool Dead;
    public bool Platformer;
    bool restarted;
    // Start is called before the first frame update
    void Start()
    {
        restarted = false;
        Dead = false;
        DeathScreen.anchoredPosition = new Vector2(0,2300);
        RedScreen.GetComponent<RawImage>().color = Color.clear;
        if(SceneManager.topDown == false)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Platformer)
        {
            if(Player.GetComponent<PlayerMovement>().HpBar.value <= 0)
            {
                Dead = true;
            }
        }
        else
        {
            if(Player.GetComponent<Ship_hp>().Health <= 0)
            {
                Dead = true;
            }
        }

        if(Dead)
        {
            IsDet();
        }
    }

    void IsDet()
    {
        if(!restarted)
        {
            DeathScreen.anchoredPosition = Vector2.Lerp(DeathScreen.anchoredPosition,new Vector2(0,0),4f * Time.deltaTime);
        }
        RedScreen.GetComponent<RawImage>().color = new Color(0.1981132f,0.0252314f,0.0252314f,0.73f);
        
    }

    public void RestartLvl()
    {
        DeathScreen.anchoredPosition = new Vector2(3000,3000);
        SceneManager.SceneName = SceneManager.Current;
        SceneManager.ChangeScene();
        restarted = true;
        Debug.Log("HALO");
    }

    public void BackToShip()
    {
        SceneManager.SceneName = "topDown";
        SceneManager.ChangeScene();
    }

    public void Sound()
    {
        ButtonClick.Play(1);
    }
}
