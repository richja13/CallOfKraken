using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] background;
    private float[] parralaxScales;
    public float smoothing = 1f;
    private Transform cam;
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position; 
        parralaxScales = new float[background.Length];
        
        for(int i = 0; i < background.Length;i++)
        {
            parralaxScales[i] = background[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < background.Length;i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parralaxScales[i];

            float BackgroundTargetPosX = background[i].position.x + parallax;

            Vector3 backgroundTargetPosition = new Vector3(BackgroundTargetPosX, background[i].position.y , background[i].position.z);

            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
