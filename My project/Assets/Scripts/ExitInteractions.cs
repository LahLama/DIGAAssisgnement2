using TMPro;
using UnityEngine;


public class ExitInteractions : MonoBehaviour
{
    public Rigidbody2D MainCamera;

    public GameObject[] Level1Doors;
    public GameObject[] Level2Doors;
    public GameObject[] Level3Doors;
    public GameObject[] Level4Doors;


    public PlayerStatus playerStatus;
    public Puzzle1Manager puzzle1Manager;
    public Puzzle2Manager puzzle2Manager;

    public int playerlvl;
    public bool playerlevelUpbool;

    public int playerMicroCount;
    public void Awake()
    {
        //playerStatus = GetComponent<PlayerStatus>();
        //print("THE PLAYERS LEVEL IS " + playerStatus.PlayerLevel);
        InitDoors();
        playerlvl = playerStatus.PlayerLevel;
        //    playerMicroCount = playerStatus.MicrochipCount;
        playerlevelUpbool = playerStatus.PlayerLevelUpBool;


    }


    private void Update()
    {
        playerlevelUpbool = playerStatus.PlayerLevelUpBool;
        if (playerlevelUpbool == true)
        {
            OpenDoors();
        }

    }

    public void OpenDoors()
    {
        playerlvl = playerStatus.PlayerLevel;
        if (playerlvl >= 1)
        {
            //print("NOW OPEN DOORS 1");
            foreach (var door1 in Level1Doors)
            {
                door1.SetActive(true);
            }
        }
        if (playerlvl >= 2)
        {
            //print("NOW OPEN DOORS 2");
            foreach (var door2 in Level2Doors)
            {
                //print("DoorName is: " + door2.name);
                door2.SetActive(true);
            }
        }
        if (playerlvl >= 3)
        {

            // print("NOW OPEN DOORS 3");
            foreach (var door3 in Level3Doors)
            {
                door3.SetActive(true);
            }
        }
        if (playerlvl >= 4)
        {

            // print("NOW OPEN DOORS 4");
            foreach (var door4 in Level4Doors)
            {
                door4.SetActive(true);
            }
        }
        playerlevelUpbool = false;

    }
    public void InitDoors()
    {

        foreach (var door2 in Level2Doors)
        {
            door2.SetActive(false);
        }

        foreach (var door3 in Level3Doors)
        {
            door3.SetActive(false);
        }

        foreach (var door4 in Level4Doors)
        {
            door4.SetActive(false);
        }
    }

    public void MoveCamera()
    {


        switch (this.name)
        {
            case "UpBtn":
                float movementAmount1 = 1080f;
                Vector3 newPosition1 = MainCamera.transform.position;
                newPosition1.y += movementAmount1;
                MainCamera.transform.position = newPosition1;
                break;
            case "DownBtn":
                float movementAmount2 = -1080f;
                Vector3 newPosition2 = MainCamera.transform.position;
                newPosition2.y += movementAmount2;
                MainCamera.transform.position = newPosition2;
                break;
            case "UpOrPuzzle1":
                if (playerStatus.PlayPuzz1 == false)
                {
                    float movementAmount3 = -1920f;
                    Vector3 newPosition3 = MainCamera.transform.position;
                    newPosition3.x += movementAmount3;
                    MainCamera.transform.position = newPosition3;
                    playerStatus.PlayPuzz1 = true;
                    puzzle1Manager.StartPuzzle1Timer();

                }
                else
                {
                    float movementAmount4 = 1080f;
                    Vector3 newPosition4 = MainCamera.transform.position;
                    newPosition4.y += movementAmount4;
                    MainCamera.transform.position = newPosition4;
                }
                break;
            case "DownOrPuzzle2":
                if (playerStatus.PlayPuzz2 == false)
                {
                    float movementAmount5 = -1920f;
                    Vector3 newPosition5 = MainCamera.transform.position;
                    newPosition5.x += movementAmount5;
                    MainCamera.transform.position = newPosition5;
                    playerStatus.PlayPuzz2 = true;
                    puzzle2Manager.StartPuzzle2();
                }
                else
                {
                    float movementAmount6 = -1080f;
                    Vector3 newPosition6 = MainCamera.transform.position;
                    newPosition6.y += movementAmount6;
                    MainCamera.transform.position = newPosition6;
                }
                break;
            case "UpOrPuzzle3":
                if (playerStatus.PlayPuzz3 == false)
                {
                    float movementAmount7 = -1920f;
                    Vector3 newPosition7 = MainCamera.transform.position;
                    newPosition7.x += movementAmount7;
                    MainCamera.transform.position = newPosition7;
                    playerStatus.PlayPuzz3 = true;
                }
                else
                {
                    float movementAmount8 = 1080f;
                    Vector3 newPosition8 = MainCamera.transform.position;
                    newPosition8.y += movementAmount8;
                    MainCamera.transform.position = newPosition8;
                }
                break;
            default:
                Debug.Log("No camera movement assigned for this button.");
                break;


        }


    }
}

