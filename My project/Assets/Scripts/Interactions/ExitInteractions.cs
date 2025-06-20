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


    public Texture2D ButtonCursor;
    public Texture2D NormalCursor;
    public int playerlvl;
    public bool playerlevelUpbool;

    public int playerMicroCount;

    public CaptchaManager captchaManager;
    public BruteForceManager bruteForceManager;
    public JigsawManager jigsawManager;
    public void Awake()
    {


        //playerStatus = GetComponent<PlayerStatus>();
        //print("THE PLAYERS LEVEL IS " + playerStatus.PlayerLevel);
        InitDoors();

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
        PlayerStatus.GameState gamestate = playerStatus.CurrentGameState;

        /* if (gamestate.Equals(PlayerStatus.GameState.Puzzle1))
         {

             print("NOW OPEN DOORS 1");
             foreach (var door1 in Level1Doors)
             {
                 door1.SetActive(true);
             }
         }*/
        if (gamestate.Equals(PlayerStatus.GameState.Puzzle1))
        {
            //print("NOW OPEN DOORS 2");
            foreach (var door2 in Level2Doors)
            {
                //    print("DoorName is: " + door2.name);
                door2.SetActive(true);
            }
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle2))
        {

            // print("NOW OPEN DOORS 3");
            foreach (var door3 in Level3Doors)
            {
                door3.SetActive(true);
            }
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle3))
        {

            // print("NOW OPEN DOORS 4");
            foreach (var door4 in Level4Doors)
            {
                door4.SetActive(true);
            }
        }
        else
        { //print("No doors to open for this level");
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

    }
    public void MoveCameraDown()        //this moves the camera down
    {
        float movementAmount2 = -540f;
        Vector3 newPosition2 = MainCamera.transform.position;
        newPosition2.y += movementAmount2;
        MainCamera.transform.position = newPosition2;
        //Asset [1]

    }

    public void MoveCameraLeft()        //this moves the camera left solely for puzzles 1 and 2
    {
        float movementAmount3 = -960;
        Vector3 newPosition3 = MainCamera.transform.position;
        newPosition3.x += movementAmount3;
        MainCamera.transform.position = newPosition3;
        //Asset [1]

    }
    public void MoveCameraRight()        //this moves the camera left solely for puzzles 1 and 2
    {
        float movementAmount4 = +960;
        Vector3 newPosition4 = MainCamera.transform.position;
        newPosition4.x += movementAmount4;
        MainCamera.transform.position = newPosition4;
        //Asset [1]

    }


    public void MoveCamera()                //Depending on the button name, this function will detect the name and move the camera in the stipulated direction. 
                                            //this is easier like this as this reduces the amount of code that is repeated
    {
        PlayerStatus.GameState gamestate = playerStatus.CurrentGameState;
        switch (this.name)
        {
            case "UpBtn":
                MoveCameraUp();
                GameInteractionSoundManager.PlaySound("door");
                break;
            case "DownBtn":
                MoveCameraDown();
                GameInteractionSoundManager.PlaySound("door");
                break;
            case "UpOrPuzzle1":             //Detemines if the button pressed takes the player to the puzzle or to the next room if they have completeted the puzzle
                if (gamestate.Equals(PlayerStatus.GameState.Puzzle1))
                {
                    MoveCameraLeft();

                    captchaManager.PuzzleCaptchaStart();

                    Debug.Log("Puzzle 1 started ********************");
                    //Asset [2]
                    GameInteractionSoundManager.PlaySound("puzzleEnter");

                }
                else
                {
                    MoveCameraUp();
                    GameInteractionSoundManager.PlaySound("door");
                }
                break;
            case "DownOrPuzzle2":
                if (gamestate.Equals(PlayerStatus.GameState.Puzzle2))
                {
                    MoveCameraLeft();

                    bruteForceManager.StartPuzzleBruteForce();
                    //Asset [2]
                    GameInteractionSoundManager.PlaySound("puzzleEnter");
                }
                else
                {
                    MoveCameraDown();
                    GameInteractionSoundManager.PlaySound("door");
                }
                break;
            case "UpOrPuzzle3":
                if (gamestate.Equals(PlayerStatus.GameState.Puzzle3))
                {
                    MoveCameraUp();
                    print("Puzzle 3 started ********************");
                    jigsawManager.StartJigsawPuzzle();
                    //Asset [2]
                    GameInteractionSoundManager.PlaySound("puzzleEnter");
                    break;
                }

                else
                {
                    MoveCameraUp();
                    GameInteractionSoundManager.PlaySound("door");
                    break;
                }

            default:
                Debug.Log("No camera movement assigned for this button.");
                break;


        }





    }


    public void OnButtonCursorEnter() // this is used to change the cursor when hovering over the buttons
    {
        Cursor.SetCursor(ButtonCursor, Vector2.zero, CursorMode.Auto);



    }

    public void OnButtonCursorExit()  // this is used to change the cursor back to the default when not hovering over the buttons
    {
        Cursor.SetCursor(NormalCursor, Vector2.zero, CursorMode.Auto);

    }
}

