using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static int AttackDmg = 12;
    public static int Stamina = 75;
    public static int Hp = 30;
    public static int BoatHp = 800;
    public static int BoatAttack = 15;
    public static float BoatCrew = 85;
    public static int Money;
    public static int Sugar;
    public static int Rum;
    public static int Tea;
    public static int KeysCollected;
    static int notFirstGame = 0;
    public List<GameObject> Keys;
    public List<Vector2> SpawnPlace;
    public static float GunTime = 30;
    public static float GunDamage = 0.2f;
    // Start is called before the first frame update
    void Awake()
    {
         
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        
        notFirstGame = PlayerPrefs.GetInt("notFirstGame");
        
        if(notFirstGame == 0)
        {
            notFirstGame = 1;
            BoatCrew = 85;
            AttackDmg = 12;
            Stamina = 75;
            Hp = 30;
            BoatHp = 1000;
            BoatAttack = 20;
            BoatCrew = 85;
            Money = 0;
            Sugar = 0;
            Rum = 0;
            Tea = 0;
            KeysCollected = 0;
        }
        else
        {
            AttackDmg = PlayerPrefs.GetInt("AttackDmg");
            Stamina = PlayerPrefs.GetInt("Stamina");
            Hp = PlayerPrefs.GetInt("Hp");
            BoatHp = PlayerPrefs.GetInt("BoatHp");
            BoatAttack = PlayerPrefs.GetInt("BoatAttack");
            BoatCrew = PlayerPrefs.GetFloat("BoatCrew");
            Money = PlayerPrefs.GetInt("Money");
            Sugar = PlayerPrefs.GetInt("Sugar");
            Rum = PlayerPrefs.GetInt("Rum");
            Tea = PlayerPrefs.GetInt("Tea");
            KeysCollected = PlayerPrefs.GetInt("Key");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("notFirstGame",notFirstGame);
        PlayerPrefs.SetInt("Hp", Hp);
        PlayerPrefs.SetInt("BoatHp", BoatHp);
        PlayerPrefs.SetInt("Stamina",Stamina);
        PlayerPrefs.SetInt("BoatAttack",BoatAttack);
        PlayerPrefs.SetInt("AttackDmg", AttackDmg);
        PlayerPrefs.SetFloat("BoatCrew",BoatCrew);
        PlayerPrefs.SetInt("Money",Money);
        PlayerPrefs.SetInt("Sugar",Sugar);
        PlayerPrefs.SetInt("Tea",Tea);
        PlayerPrefs.SetInt("Key",KeysCollected);

        if(Input.GetKey(KeyCode.W))
        {
            Money+=1230;
        }
    }
    public void SpawnFirstKey()
    {
        Instantiate(Keys[0], SpawnPlace[0],transform.rotation);
    }

    public void SpawnSecondKey()
    {
        Instantiate(Keys[1], SpawnPlace[1],transform.rotation);
    }
}

