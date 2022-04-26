using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFoams : MonoBehaviour
{
    public float Timer;
    public float WaveSpowner;
    private Transform NewPosition;
    private Transform OldPosition;
    public ParticleSystem WaveR;
    public ParticleSystem WaveL;
    public ParticleSystem WaveFoams;
    public AudioSource WaveHit;
    public GameObject WaterFoamsSound;
    GameObject sound;
    public bool canCreateSound;

    private void Start()
    {
        canCreateSound = true;
    }

    void Update()
    {


        Timer -= 1f;

        if (Timer <= 0f)
        {
            WaveSpowner = Random.Range(1, 8);
            Timer = 20f;
        
        }
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
        
        if (WaveSpowner == 3 && GetComponent<Ship_Move>().moveSpeed > 0)
        {
            WaveHit.Play(1);
            WaveR.Emit(1);
            WaveL.Emit(1);
        }
        else
        {
            WaveR.Emit(0);
            WaveL.Emit(0);
        }

        if (GetComponent<Ship_Move>().moveSpeed > 0)
        {
            if(canCreateSound)
            {
                sound = Instantiate(WaterFoamsSound);
                canCreateSound = false;
            }

            WaveFoams.Emit(1);
        }
        else
        {
            canCreateSound = true;

            if(sound!=null)
            {
                sound.GetComponent<AudioSource>().volume -= 0.005f;
            }

            Destroy(sound, 4f);
            //WaterFoamsSound.Play(0);
            WaveFoams.Emit(0);
        }
    }
}
