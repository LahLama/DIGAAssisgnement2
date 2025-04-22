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

    public int playerlvl;
    public bool playerlevelUpbool;

    public int playerMicroCount;
    public void Awake()
    {
        //playerStatus = GetComponent<PlayerStatus>();
        //print("THE PLAYERS LEVEL IS " + playerStatus.PlayerLevel);
        InitDoors();
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
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
        Level1Doors = GameObject.FindGameObjectsWithTag("Level1Door");
        Level2Doors = GameObject.FindGameObjectsWithTag("Level2Door");
        Level3Doors = GameObject.FindGameObjectsWithTag("Level3Door");
        Level4Doors = GameObject.FindGameObjectsWithTag("Level4Door");


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
        if (this.name == "UpBtn")
        {
            float movementAmount = 1080f;
            Vector3 newPosition = MainCamera.transform.position;
            newPosition.y += movementAmount;
            MainCamera.transform.position = newPosition;
        }
        if (this.name == "DownBtn")
        {
            float movementAmount = -1080f;
            Vector3 newPosition = MainCamera.transform.position;
            newPosition.y += movementAmount;
            MainCamera.transform.position = newPosition;
        }
        if (this.name == "RightBtn")
        {
            float movementAmount = 1920f;
            Vector3 newPosition = MainCamera.transform.position;
            newPosition.x += movementAmount;
            MainCamera.transform.position = newPosition;
        }
        if (this.name == "LeftBtn")
        {
            float movementAmount = -1920;
            Vector3 newPosition = MainCamera.transform.position;
            newPosition.x += movementAmount;
            MainCamera.transform.position = newPosition;
        }
        if (this.name == "LeftOrPuzzle1Btn")
        {
            if (playerStatus.PlayPuzz1 == true)
            {
                float movementAmount = -1920 * 2;
                Vector3 newPosition = MainCamera.transform.position;
                newPosition.x += movementAmount;
                MainCamera.transform.position = newPosition;
            }
            else
            {
                float movementAmount = -1920;
                Vector3 newPosition = MainCamera.transform.position;
                newPosition.x += movementAmount;
                MainCamera.transform.position = newPosition;
            }

        }
        if (this.name == "LeftOrPuzzle2Btn")

        {
            if (playerStatus.PlayPuzz2 == true)
            {
                float movementAmount = -1920 * 2;
                Vector3 newPosition = MainCamera.transform.position;
                newPosition.x += movementAmount;
                MainCamera.transform.position = newPosition;
            }
            else
            {
                float movementAmount = -1920;
                Vector3 newPosition = MainCamera.transform.position;
                newPosition.x += movementAmount;
                MainCamera.transform.position = newPosition;
            }

        }


        if (this.name == "UpORPuzzle3Btn")
        {
            if (playerStatus.PlayPuzz3 == true)
            {
                float movementAmount = 1080 * 2;
                Vector3 newPosition = MainCamera.transform.position;
                newPosition.y += movementAmount;
                MainCamera.transform.position = newPosition;
            }
            else
            {
                float movementAmount = 1080;
                Vector3 newPosition = MainCamera.transform.position;
                newPosition.y += movementAmount;
                MainCamera.transform.position = newPosition;
            }

        }
        if (this.name == "RightBackBtn")
        {
            float movementAmount = 2 * 1920;
            Vector3 newPosition = MainCamera.transform.position;
            newPosition.x += movementAmount;
            MainCamera.transform.position = newPosition;
        }
        if (this.name == "DownBackBtn")
        {
            float movementAmount = 2 * -1080;
            Vector3 newPosition = MainCamera.transform.position;
            newPosition.y += movementAmount;
            MainCamera.transform.position = newPosition;
        }


    }


}

