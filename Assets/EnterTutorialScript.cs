using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneTransitionAnimationScript transition;
    public Button Play;
     public Button skip;

     RectTransform GameObjectPostion;

     bool InvokeTutorial;
    void Start()
    {
        GameObjectPostion = this.gameObject.GetComponent<RectTransform>();
        InvokeTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(InvokeTutorial)
        {
            GameObjectPostion.anchoredPosition = Vector2.Lerp(GameObjectPostion.anchoredPosition,new Vector2(0,0), 5f * Time.deltaTime);
        }

        this.gameObject.GetComponent<RectTransform>().anchoredPosition = GameObjectPostion.anchoredPosition;

        skip.onClick.AddListener(SkipTutorial);
        Play.onClick.AddListener(PlayTutorial);
    }

    public void SkipTutorial()
    {
        transition.SceneName = "intro";
        transition.ChangeScene();
    }

    public void PlayTutorial()
    {
        transition.SceneName = "tutorialScene";
        transition.ChangeScene();
    }

    public void TutorialMenu()
    {
        InvokeTutorial = true;
    }
}
