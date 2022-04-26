using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaynardScript : MonoBehaviour
{
    public MichaelScript Skrypt;
    public PlayerStatsScript Stats;
    public GameObject MichaelUltimateCollider;
    public GameObject Bullet;
    public Transform FirePlace;

    void Start()
    {
        MichaelUltimateCollider.SetActive(false);
    }

    void Awake()
    {
        Skrypt = this.gameObject.GetComponent<MichaelScript>();
        Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsScript>();
    }

    void Update()
    {
       if(!Skrypt.StillAlive && Skrypt.HP <= 0)
       {
           Stats.SpawnSecondKey();
           Skrypt = null;
       }
    }

    public void UltimateAttack()
    {
       MichaelUltimateCollider.SetActive(true);
    }

    public void DeleteUlt()
    {
        MichaelUltimateCollider.SetActive(false);
    }

    public void Shoot()
    {
        Instantiate(Bullet,FirePlace.position,FirePlace.rotation);
    }
}
