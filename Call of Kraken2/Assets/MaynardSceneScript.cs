using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaynardSceneScript : MonoBehaviour
{
    Camera MainCamera;
    public Vector2 ScenePosition;
    IslandCamerScript CameraScript;
    bool OnScene;
    public DialogueManagerScript Dialog; 
    public DialogueManagerScript DialogEnd;
    public Animator MaynardAnimator;
    public GameObject Chest;
    public ParticleSystem ChestParticles;
    public GameObject MoveToPlace;
    bool CanMove;
    GameObject Player;
    public GameObject Soldier;
    public GameObject Musket;
    public GameObject Musket2;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CameraScript = MainCamera.GetComponent<IslandCamerScript>();   
        CanMove = true;
        Player = MainCamera.GetComponent<IslandCamerScript>().Target;    
        
        Soldier.GetComponent<Animator>().enabled = false;
        Musket.GetComponent<Animator>().enabled = false;
        Musket2.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(OnScene)
        {
            EnterScene();
            
            if(CanMove)
            {
                CanMove = false;
            }
        }

        if(DialogEnd.GetComponent<DialogueManagerScript>().Lol == false)
        {
            ExitScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            EnterScene();

            if(ProjectMaster.IActMissionNumber == 22)
            {
                ProjectMaster.IActMissionNumber = 23;
            }
        }
    }

    void EnterScene()
    {
        MainCamera.GetComponent<IslandCamerScript>().Target = MoveToPlace;   
        MainCamera.GetComponent<IslandCamerScript>().Y = MoveToPlace.transform.position.y; 
        Player.transform.position = new Vector2(Player.transform.position.x + 1.2f, Player.transform.position.y);
        Dialog.CallDialog();
    }

    void ExitScene()
    {
        MainCamera.GetComponent<IslandCamerScript>().Target = Player;    
        MainCamera.GetComponent<IslandCamerScript>().Y = 0.2f; 
        OnScene = false;
        MoveMaynard();
        Soldier.GetComponent<Animator>().enabled = true;
        Musket.GetComponent<Animator>().enabled = true;
        Musket2.GetComponent<Animator>().enabled = true;
    }

    void MoveMaynard()
    {
        MaynardAnimator.SetBool("Move",true);
        MaynardAnimator.GetComponent<Transform>().transform.Translate(Vector2.left/2 * Time.deltaTime);
        MaynardAnimator.GetComponent<Transform>().transform.eulerAngles = new Vector2(0, 180);
        Chest.SetActive(false);
        ChestParticles.Play();
    }
}
