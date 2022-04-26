using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCaveScript : MonoBehaviour
{
    public SceneTransitionAnimationScript transition;
    public AudioSource Music;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Music.volume -= 0.05f;
            //GoToCaveSound.Play(1);
            transition.SceneName = "CaveIsland2";
            transition.ChangeScene();
            //SceneManager.LoadScene("CaveIsland2");
        }
    }

}
