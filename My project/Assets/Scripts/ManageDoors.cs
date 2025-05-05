using UnityEngine;

public class ManageDoors : MonoBehaviour
{


    public GameObject[] Level1Doors;
    public GameObject[] Level2Doors;
    public GameObject[] Level3Doors;
    public GameObject[] Level4Doors;


    public PlayerStatus playerStatus;

    public int playerlvl;
    public bool playerlevelUpbool;

    public void Awake()
    {

        InitDoors();
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        playerlvl = playerStatus.PlayerLevel;

    }
    private void Update()
    {


        if (playerlevelUpbool == true)
        {
            OpenDoors();
        }
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
    public void OpenDoors()

    {


        playerlvl = playerStatus.PlayerLevel;
        if (playerlvl >= 1)
        {
            foreach (var door1 in Level1Doors)
            {
                door1.SetActive(true);
            }
        }
        if (playerlvl >= 2)
        {

            print("NOW OPEN DOORS 2");
            foreach (var door2 in Level2Doors)
            {
                print("Door2 is: " + door2);
                door2.SetActive(true);
            }
        }
        if (playerlvl >= 3)
        {
            foreach (var door3 in Level3Doors)
            {
                door3.SetActive(true);
            }
        }
        if (playerlvl >= 4)
        {

            foreach (var door4 in Level4Doors)
            {
                door4.SetActive(true);
            }
        }
        playerlevelUpbool = false;

    }

}
