using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite swordSprite;
    public Sprite GunSprite;
    public Sprite HatSprite;
    public Sprite JacketSprite;
    public Sprite BeltSprite;
    public Sprite ShoesSprite;
}
