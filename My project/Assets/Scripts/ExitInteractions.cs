using TMPro;
using UnityEngine;
/* Assest Refencing
[1] Creaking Door . mixkit. [sound effect] .https://mixkit.co/free-sound-effects/doors/ 08 / 05 / 2025
-------------------------------
[2] Time Machine Sound Effect. mixkit. [Sound Effect] https://mixkit.co/free-sound-effects/time-machine/ : Date Accessed: 08 / 05 / 2025
-------------------------------
*/

public class ExitInteractions : MonoBehaviour
{
    public Rigidbody2D MainCamera;
// This allows physical attributing of the level doors in unity engine
    public GameObject[] Level1Doors;
    public GameObject[] Level2Doors;
    public GameObject[] Level3Doors;
    public GameObject[] Level4Doors;

// refences the scripts need to check the player status for each puzzle
    public PlayerStatus playerStatus;
    public Puzzle1Manager puzzle1Manager;
    public Puzzle2Manager puzzle2Manager;
    public Puzzle3Manager puzzle3Manager;
    public Puzzle4Manager puzzle4Manager;

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


    private void Update()                           // this checks if the player has leveled up, if so it will update the doors to open for the respective level
    {
        playerlevelUpbool = playerStatus.PlayerLevelUpBool;
        if (playerlevelUpbool == true)
        {
            OpenDoors();
        }

    }

    public void OpenDoors()                     //this activates specific doors based on the players level
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
    public void InitDoors()     //this makes all the doors except for the doors on the first level inaccessible
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

    public void MoveCameraUp()      //this move the camera up 
    {
        float movementAmount1 = 540f;
        Vector3 newPosition1 = MainCamera.transform.position;
        newPosition1.y += movementAmount1;
        MainCamera.transform.position = newPosition1;
        //Asset [1]
        SoundManager.PlaySound("DoorOpen");
    }
    public void MoveCameraDown()        //this moves the camera down
    {
        float movementAmount2 = -540f;
        Vector3 newPosition2 = MainCamera.transform.position;
        newPosition2.y += movementAmount2;
        MainCamera.transform.position = newPosition2;
        //Asset [1]
        SoundManager.PlaySound("DoorOpen");
    }
    
    public void MoveCameraLeft()        //this moves the camera left solely for puzzles 1 and 2
    {
        float movementAmount3 = -960;
        Vector3 newPosition3 = MainCamera.transform.position;
        newPosition3.x += movementAmount3;
        MainCamera.transform.position = newPosition3;
        //Asset [1]
        SoundManager.PlaySound("DoorOpen");
    }

    public void MoveCamera()                //Depending on the button name, this function will detect the name and move the camera in the stipulated direction. 
                                            //this is easier like this as this reduces the amount of code that is repeated
    {
        switch (this.name)
        {
            case "UpBtn":
                MoveCameraUp();
                break;
            case "DownBtn":
                MoveCameraDown();
                break;  
            case "UpOrPuzzle1":             //Detemines if the button pressed takes the player to the puzzle or to the next room if they have completeted the puzzle
                if (playerStatus.PlayPuzz1 == false)
                {
                    MoveCameraLeft();

                    puzzle1Manager.StartPuzzle1Timer();
                    Debug.Log("Puzzle 1 started ********************");
                    //Asset [2]
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
                   //Asset [2]
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
                    MoveCameraUp();
                    playerStatus.PlayPuzz3 = true;
                    //Asset [2]
                    SoundManager.PlaySound("PuzzleOpen");

                    puzzle4Manager.Puzzle4Start();
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

