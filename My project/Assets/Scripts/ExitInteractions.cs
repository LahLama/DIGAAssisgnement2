using JetBrains.Annotations;
using TMPro;
using UnityEngine;


public class ExitInteractions : MonoBehaviour
{
    public Rigidbody2D MainCamera;

    public GameObject[] Level1Doors;
    public GameObject[] Level2Doors;
    public GameObject[] Level2DoorsDeativate;
    public GameObject[] Level3Doors;


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

        if (playerlvl == 2)
        {
            foreach (var item in Level2Doors)
            {
                item.SetActive(true);
            }
        }

    }
    public void InitDoors()
    {
        Level1Doors = GameObject.FindGameObjectsWithTag("Level1Door");

        foreach (var item in Level1Doors)
        {
            item.SetActive(true);
        }

        Level2Doors = GameObject.FindGameObjectsWithTag("Level2Door");
        foreach (var item in Level2DoorsDeativate)
        {
            Debug.Log("Item: " + item.name);
            Debug.Log("SETTING DOOR2 OFF");
            item.SetActive(false);
            Debug.Log("Item: " + item.name);
        }

        Level3Doors = GameObject.FindGameObjectsWithTag("Level3Door");
        foreach (var item in Level3Doors)
        {
            item.SetActive(true);
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



