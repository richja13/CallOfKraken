using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCaveScene : MonoBehaviour
{
    public SceneTransitionAnimationScript transition;
    public AudioSource Music;
    public string SceneManage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Music.volume -= 0.05f;
            //GoToCaveSound.Play(1);
            transition.SceneName = SceneManage;
            transition.ChangeScene();
            //SceneManager.LoadScene("CaveIsland2");

            if(ProjectMaster.IActMissionNumber == 23)
            {
                ProjectMaster.IActMissionNumber = 24;
            }

            if(ProjectMaster.IActMissionNumber == 31)
            {
                ProjectMaster.IActMissionNumber = 32;
            }

            if(ProjectMaster.IActMissionNumber == 39)
            {
                ProjectMaster.IActMissionNumber = 40;
            }
        }
    }

}
