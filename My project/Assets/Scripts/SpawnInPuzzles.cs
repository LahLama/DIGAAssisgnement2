using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnInPuzzles : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public int MicroCount;
    public int playerlvl1;
    public GameObject Puzz1, Puzz2, Puzz3, Puzz4;
    public ExitInteractions exitInteractions;
    Rigidbody2D camera1;

    void Awake()
    {

        Rigidbody2D camera = exitInteractions.MainCamera;
        print("Player Level is: " + playerlvl1);
        print("Player Microchip count is: " + MicroCount);
    }

    void Update()
    {
        MicroCount = playerStatus.MicrochipCount;
        bool PlayPuzz1 = playerStatus.PlayPuzz1;
        bool PlayPuzz2 = playerStatus.PlayPuzz2;
        bool PlayPuzz3 = playerStatus.PlayPuzz3;
        bool PlayPuzz4 = playerStatus.PlayPuzz4;
        playerlvl1 = playerStatus.PlayerLevel;

        if (playerlvl1 == 1 && MicroCount == 1 && PlayPuzz1 == false)
        {
            Debug.Log("SPAWN PUZZLE 1");
            camera1.transform.position = new Vector2(Puzz1.transform.position.x, Puzz1.transform.position.y);

            PlayPuzz1 = true;
            Debug.Log("SPAWN PUZZLE 1");
        }
        if (playerlvl1 == 2 && MicroCount == 3)
        {
        }
        if (playerlvl1 == 3 && MicroCount == 4)
        {

        }
        if (playerlvl1 == 4 && MicroCount == 5)
        {

        }
    }


}
