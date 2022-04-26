using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackUlt : MonoBehaviour
{
    public GameObject Hitbox;
    // Start is called before the first frame update
    void Start()
    {
        Hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UltimateAttack()
    {
        Hitbox.SetActive(true);
    }

    void RevokeAttack()
    {
        Hitbox.SetActive(false);
    }
}
