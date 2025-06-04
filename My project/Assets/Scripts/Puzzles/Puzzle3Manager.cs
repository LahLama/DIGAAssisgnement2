using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[1]
Title:  Unity Follow path or points 
Author: Clip Collection Vault
Date :   10 May 2022
Availibility: https://www.youtube.com/watch?v=am3IitICcyA
*/

public class Puzzle3Manager : PuzzleClass
{
    //refencing the scripts needed

    public ExitInteractions exitInteractions;
    public PlayerStatus playerStatus;
    public TimerScript Puzzle3Timer;
    public Puzzle4Manager puzzle4Manager;
    public PlayerObjective playerObjective;


    //Varibles needed
    public GameObject PathLeader;
    public Transform[] Waypoints;
    public Rigidbody2D camera1;

    int playerlvl;
    public int moveSpeed = 5;
    public int WayIndex = 0;
    public bool Puzzle3Start = false;




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
                    // Puzzle has been completed
                    playerObjective.UpdateObjective();
                    GameInteractionSoundManager.StopSound();
                    Puzzle3Timer.StartTimer = false;
                    EndPuzzleSound();
                    StartCoroutine(WaitBeforeReset());

                }
            }

        }
    }

    public void ResetPathLeader()
    {
        PathLeader.transform.position = Waypoints[0].transform.position;
        WayIndex = 0;

        Puzzle3Start = false;
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
        // Sets the puzzle status to the opposite of what it was
        Puzzle3Start = !Puzzle3Start;
        GameInteractionSoundManager.PlaySound("spark");
        //[1]
        // sets the path leader to the intial position
        PathLeader.transform.position = Waypoints[0].transform.position;
        WayIndex = 0;
        Debug.Log(Puzzle3Start);



    }

    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously


        //upgrades player to level 3
        playerlvl = 3;
        Puzzle3Start = false;

        // Puzzle 3 has been played
        playerStatus.PlayPuzz3 = true;
        //moves camera up with exinteractions method and starts the next puzzle

        exitInteractions.MoveCameraUp();
        // Add ai voice line here
        puzzle4Manager.Puzzle4Start();

    }
}