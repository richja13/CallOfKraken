using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTutorialScript : MonoBehaviour
{
    public GameObject ThisObject;
    public int Stage;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseWindow()
    {
        ThisObject.SetActive(false);
       // TutorialScript.TutorialStages = Stage;
    }
}
