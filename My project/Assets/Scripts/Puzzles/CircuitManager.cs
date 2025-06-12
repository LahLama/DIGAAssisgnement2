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

public class CircuitManager : PuzzleClass
{
    //refencing the scripts needed

    public ExitInteractions exitInteractions;
    public PlayerStatus playerStatus;
    public ReplicateCodeManager replicateCodeManager;
    public PlayerObjective playerObjective;


    //Varibles needed
    public GameObject PathLeader;
    public Transform[] Waypoints;
    public Rigidbody2D camera1;

    public int moveSpeed = 5;
    public int WayIndex = 0;
    public bool Puzzle3Start = false;




    void Update()
    {

        camera1 = exitInteractions.MainCamera;
        if (Puzzle3Start == true)
        {

            if (WayIndex <= Waypoints.Length - 1)
            {
                Vector3 targetPosition = new Vector3(Waypoints[WayIndex].transform.position.x, Waypoints[WayIndex].transform.position.y, PathLeader.transform.position.z);
                Vector2 newPos2D = Vector2.MoveTowards(
                    new Vector2(PathLeader.transform.position.x, PathLeader.transform.position.y),
                    new Vector2(targetPosition.x, targetPosition.y),
                    moveSpeed * Time.deltaTime
                );
                PathLeader.transform.position = new Vector3(newPos2D.x, newPos2D.y, PathLeader.transform.position.z);
                // Check if the PathLeader reached the target x/y (ignore z)
                if (Vector2.Distance(new Vector2(PathLeader.transform.position.x, PathLeader.transform.position.y), new Vector2(targetPosition.x, targetPosition.y)) < 0.01f)
                {
                    WayIndex++;
                }
                if (WayIndex == Waypoints.Length && Puzzle3Start == true)
                {
                    // Puzzle has been completed

                    GameInteractionSoundManager.StopSound();
                    EndPuzzleSound();
                    playerStatus.CurrentGameState = PlayerStatus.GameState.Puzzle6;
                    playerObjective.UpdateObjective();
                    StartCoroutine(WaitBeforeReset());

                }
            }

        }
    }

    public void ResetPathLeader()
    {
        PuzzleFailSound();
        PathLeader.transform.position = new Vector3(Waypoints[0].transform.position.x, Waypoints[0].transform.position.y, PathLeader.transform.position.z);
        WayIndex = 0;
        Puzzle3Start = false; // resets the puzzle status

    }
    public void StartCircuitPuzzle()
    {
        AiInteractionSoundManager.PlaySound("PuzzleCircuit");
        StartTimer();
    }

    public void OnClick()
    {

        GameInteractionSoundManager.PlaySound("spark");
        //[1]
        // sets the path leader to the intial position
        ResetPathLeader();
        // Sets the puzzle status to the opposite of what it was
        Puzzle3Start = !Puzzle3Start;


    }

    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously


        //upgrades player to level 3

        Puzzle3Start = false;

        // Puzzle 3 has been played

        //moves camera up with exinteractions method and starts the next puzzle
        StopTimer();
        exitInteractions.MoveCameraRight();


        // Add ai voice line here

    }
}