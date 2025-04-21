using JetBrains.Annotations;
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

    [SerializeField] int playerlvl;
    public void Awake()
    {
        //playerStatus = GetComponent<PlayerStatus>();
        print("THE PLAYERS LEVEL IS " + playerStatus.PlayerLevel);
        InitDoors();
        playerlvl = playerStatus.PlayerLevel;

    }


    private void Update()
    {
        playerlvl = playerStatus.PlayerLevel;
        OpenDoors();
    }

    public void OpenDoors()
    {

        if (playerlvl >= 2)
        {
            foreach (var item in Level2Doors)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (playerlvl >= 3)
        {
            foreach (var item in Level3Doors)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (playerlvl >= 4)
        {
            foreach (var item in Level4Doors)
            {
                item.gameObject.SetActive(true);
            }
        }

    }
    public void InitDoors()
    {
        Level1Doors = GameObject.FindGameObjectsWithTag("Level1Door");

        foreach (var door1 in Level1Doors)
        {
            door1.SetActive(true);
        }

        Level2Doors = GameObject.FindGameObjectsWithTag("Level2Door");
        foreach (var door2 in Level2Doors)
        {

            Debug.Log("SETTING DOOR2 OFF");
            door2.gameObject.SetActive(false);
            ;
        }

        Level3Doors = GameObject.FindGameObjectsWithTag("Level3Door");
        foreach (var door3 in Level3Doors)
        {
            door3.gameObject.SetActive(false);
        }

        Level4Doors = GameObject.FindGameObjectsWithTag("Level4Door");
        foreach (var door4 in Level4Doors)
        {
            door4.gameObject.SetActive(false);
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


    }

    public void MoveCameraLeft()
    {
        float movementAmount = -1920;
        Vector3 newPosition = MainCamera.transform.position;
        newPosition.x += movementAmount;
        MainCamera.transform.position = newPosition;
    }
}



