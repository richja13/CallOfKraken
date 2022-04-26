using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KRAKEN : MonoBehaviour
{
    public GameObject Player;
    public GameObject Tentacle;
    private float MoveSpeed;
    public float Distance;
    private float Time1;
    private Vector2 TentaclePosition;
    private float Timer = 240;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= 1;
        if (Timer < 0)
        {
            Timer = 240f;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            //transform.position = Player.transform.position;

            TentacleSpawner();

        }


        Distance = MoveSpeed * Time1 / 160;

        TentaclePosition = new Vector2(Player.transform.position.x + 20f, Player.transform.position.y + Distance);
        
    }

    void TentacleSpawner()
    {
        Instantiate(Tentacle, TentaclePosition ,Player.transform.rotation);
    }
}
