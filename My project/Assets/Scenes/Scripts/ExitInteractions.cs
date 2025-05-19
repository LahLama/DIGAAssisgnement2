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
    public Puzzle3Manager puzzle3Manager;

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

    public void MoveCameraUp()
    {
        float movementAmount1 = 540f;
        Vector3 newPosition1 = MainCamera.transform.position;
        newPosition1.y += movementAmount1;
        MainCamera.transform.position = newPosition1;
        //https://mixkit.co/free-sound-effects/doors/
        SoundManager.PlaySound("DoorOpen");
    }
    public void MoveCameraDown()
    {
        float movementAmount2 = -540f;
        Vector3 newPosition2 = MainCamera.transform.position;
        newPosition2.y += movementAmount2;
        MainCamera.transform.position = newPosition2;
        //https://mixkit.co/free-sound-effects/doors/
        SoundManager.PlaySound("DoorOpen");
    }

    public void MoveCameraLeft()
    {
        float movementAmount3 = -960;
        Vector3 newPosition3 = MainCamera.transform.position;
        newPosition3.x += movementAmount3;
        MainCamera.transform.position = newPosition3;
        //https://mixkit.co/free-sound-effects/doors/
        SoundManager.PlaySound("DoorOpen");
    }
    public void MoveCamera()
    {


        switch (this.name)
        {
            case "UpBtn":
                MoveCameraUp();
                break;
            case "DownBtn":
                MoveCameraDown();
                break;
            case "UpOrPuzzle1":
                if (playerStatus.PlayPuzz1 == false)
                {
                    MoveCameraLeft();

                    puzzle1Manager.StartPuzzle1Timer();
                    Debug.Log("Puzzle 1 started ********************");
                    //https://mixkit.co/free-sound-effects/time-machine/
                    SoundManager.PlaySound("PuzzleOpen");

                }
                else
                {
                    MoveCameraUp();
                }
                break;
            case "DownOrPuzzle2":
                if (playerStatus.PlayPuzz2 == false)
                {
                    MoveCameraLeft();

                    puzzle2Manager.StartPuzzle2();
                    //https://mixkit.co/free-sound-effects/time-machine/
                    SoundManager.PlaySound("PuzzleOpen");
                }
                else
                {
                    MoveCameraDown();
                }
                break;
            case "UpOrPuzzle3":
                if (playerStatus.PlayPuzz3 == false)
                {
                    MoveCameraLeft();
                    playerStatus.PlayPuzz3 = true;
                    //https://mixkit.co/free-sound-effects/time-machine/
                    SoundManager.PlaySound("PuzzleOpen");
                    puzzle3Manager.StartPuzzle3();
                }
                else
                {
                    MoveCameraUp();
                }
                break;
            default:
                Debug.Log("No camera movement assigned for this button.");
                break;


        }




    }
}

