using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMarySceneV2 : MonoBehaviour
{
    public GameObject Player;
    public Camera mainCam;
    public IslandCamerScript Isl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CancelAnim()
    {
        mainCam.orthographicSize = 1.21f;
        Isl.Target = Player;
    }
}
