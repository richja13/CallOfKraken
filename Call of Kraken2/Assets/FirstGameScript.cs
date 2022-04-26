using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstGameScript : MonoBehaviour
{

    static int FirstGame; 
    bool tutorial;
    public SceneTransitionAnimationScript Change;
    // Start is called before the first frame update

    void Awake()
    {
        FirstGame = PlayerPrefs.GetInt("FirstGame");
    }

    void Start()
    {
          Debug.Log(PlayerPrefs.GetInt("FirstGame"));
        if(FirstGame == 0)
        {
            tutorial = true;
            PlayerPrefs.SetInt("FirstGame", 1);
        }
        else
        {
            tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(FirstGame == 0)
        {
            tutorial = true;
        }
        else
        {
            tutorial = false;
        }

       Debug.Log(tutorial);
    }

    public void GoToIntro()
    {
        if(tutorial)
        {
            Change.SceneName = "tutorialScene";
            Change.ChangeScene();
        }
        else
        {
            Change.SceneName = "topDown";
            Change.ChangeScene();
        }
    }
}
