using TMPro;
using UnityEngine;


public class ExitInteractions : MonoBehaviour
{
    public Rigidbody2D MainCamera;

    public PlayerStatus playerStatus;
    public int playerlvl;
    public bool playerlevelUpbool;
    public void Awake()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        playerlvl = playerStatus.PlayerLevel;
        playerlevelUpbool = playerStatus.PlayerLevelUpBool;
    }

    private void Update()
    {
        playerlevelUpbool = playerStatus.PlayerLevelUpBool;
        playerlvl = playerStatus.PlayerLevel;
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

