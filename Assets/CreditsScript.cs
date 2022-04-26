using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    bool Opened;
    public RectTransform lecymyDude;

    void Update()
    {
        if(Opened)
        {
            lecymyDude.anchoredPosition = new Vector2(0,0);
        }
        else
        {
           lecymyDude.anchoredPosition = new Vector2(3000,3000); 
        }
    }

    public void OpenSailingSong()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=OY_gV_3A7MU&ab_channel=DarrenCurtisMusic");
    }

    public void OpenJungleSong()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=6I2uD7WKWeg&ab_channel=SilvermanSoundStudios");
    }

    public void OpenShipSong()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=iTVxFPhbAtk&ab_channel=UntoldJourney");
    }

    public void OpenFbSite()
    {
        Application.OpenURL("https://www.facebook.com/ELCO-Gaming-102295465009663");
    }

    public void OpenIgProfile()
    {
        Application.OpenURL("https://www.instagram.com/uhddod_mg/");
    }

    public void OpenPanel()
    {
        if(Opened == false)
        {
            Opened = true;
        }
        else 
        {
            Opened = false;
        }
    }

}
