using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionAnimationScript : MonoBehaviour
{
    public Animator transitionAnimation;
    public string SceneName;
    public AudioSource AudioControl;
    public AudioSource ButtonSound;
    public string Current;
    public bool topDown;
    //public GameObject LoadingScreen;
    //public Slider slider;

    // Update is called once per frame

    void Start()
    {
        Current = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        /*
        if(this.gameObject.GetComponent<RawImage>().color == Color.clear)
        {
            this.gameObject.GetComponent<RawImage>().raycastTarget = false;
        }
        else
        {
            this.gameObject.GetComponent<RawImage>().raycastTarget = true;
        }
        */
    }

    IEnumerator LoadScene()
    {
        
        transitionAnimation.SetTrigger("end");
      
        //AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

       // while(!operation.isDone)
       // {
           // float progress = Mathf.Clamp01(operation.progress/.9f);
            //LoadingScreen.SetActive(true);
           // slider.value = progress;
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneName);
        //}
    }

    public void ChangeScene()
    {
        AudioControl.Play(1);
        StartCoroutine(LoadScene());
    }

    public void ButtonClickSound()
    {
        ButtonSound.Play(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
