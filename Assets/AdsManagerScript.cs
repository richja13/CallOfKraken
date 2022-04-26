using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class AdsManagerScript : MonoBehaviour, IUnityAdsListener
{
    string mySurfacingId = "rewardedVideo";
    public bool ShowAdOnLvlLoad;   
    static int AdReady; 
    public Button RestartLvlButton;

    // Start is called before the first frame update
    void Awake()
    {
    
    }

    void Update()
    {
        
    }

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("4043585",true);
        RestartLvlButton = GameObject.FindGameObjectWithTag("RestartButton").GetComponent<Button>();
        RestartLvlButton.onClick.AddListener(ShowAd);
    }

    public void ShowAd()
    {   
        //AdReady += 1;
        //if(AdReady >= 2)
        //{
            Advertisement.Show();
            //AdReady = 0;
        //}
    }

    

    public void ShowRewardedAd()
    {
        Advertisement.Show("Rewarded_Android");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            PlayerStatsScript.Money += 5000;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
   
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }
}
