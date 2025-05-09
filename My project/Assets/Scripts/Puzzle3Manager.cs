using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Manager : MonoBehaviour
{
    public GameObject PathLeader;
    public Transform[] Waypoints;
    public ExitInteractions exitInteractions;
    public Rigidbody2D camera1;
    public PlayerStatus playerStatus;
    int playerlvl;
    public int moveSpeed = 5;
    public int WayIndex = 0;
    public bool Puzzle3Start = false;
    public TimerScript Puzzle3Timer;



    void Update()
    {
        playerlvl = playerStatus.PlayerLevel;
        camera1 = exitInteractions.MainCamera;
        if (Puzzle3Start == true)
        {

            if (WayIndex <= Waypoints.Length - 1)
            {
                PathLeader.transform.position = Vector2.MoveTowards(PathLeader.transform.position, Waypoints[WayIndex].transform.position, moveSpeed * Time.deltaTime);
                if (PathLeader.transform.position == Waypoints[WayIndex].transform.position)
                {
                    WayIndex++;
                }
                if (WayIndex == Waypoints.Length && Puzzle3Start == true)
                {

                    Puzzle3Timer.StartTimer = false;
                    StartCoroutine(WaitBeforeReset());

                }
            }

        }
        else if (Puzzle3Start == false)
        {
            PathLeader.transform.position = Waypoints[0].transform.position;
            WayIndex = 0;
        }
    }

    public void StartPuzzle3()
    {
        if (playerStatus.PlayPuzz3 == true)
        {
            Puzzle3Timer.remianingTime = 120;//seconds
            Puzzle3Timer.StartTimer = true;
            playerStatus.PlayerLevel = 3;
        }
    }

    public void OnClick()
    {
        Puzzle3Start = !Puzzle3Start;
        //https://www.youtube.com/watch?v=am3IitICcyA

        PathLeader.transform.position = Waypoints[0].transform.position;
        WayIndex = 0;
        Debug.Log(Puzzle3Start);



    }

    IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously


        playerlvl = 3;
        Puzzle3Start = false;
        playerStatus.PlayPuzz3 = true;
        Vector3 newPosition = camera1.transform.position;
        newPosition.x += 1920;
        newPosition.y += 1080;
        camera1.transform.position = newPosition;

    }
}