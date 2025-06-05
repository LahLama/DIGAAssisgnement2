using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4Manager : PuzzleClass
{
    [Header("Scripts")]
    public PlayerObjective playerObjective;
    public PlayerStatus playerStatus;
    public TimerScript Puzzle4Timer;
    public Puzzle5Manager puzzle5Manager;
    public ExitInteractions exitInteractions;

    [Header("Objects")]
    public TextMeshProUGUI IncorrectText;
    public Puzzle4Robot robot;

    [Header("Lists")]
    public List<string> playerSequence;
    public Button[] buttons;
    private int correctCount = 0;

    public void Puzzle4Start()
    {
        ButtonsOff();
        robot.Puzzle4RobotStart();
        StartTimer();

    }



    // Takes in the players code once they have pressed the validate button and has four states
    // Enough colours were pressed, but wrong order,
    // Enough colours were pressed and correct order,
    // Not enough colours were pressed
    // Too many colours were pressed
    public void CheckSequence()
    {

        if (playerSequence.Count == 4)
        {
            correctCount = 0;
            for (int i = 0; i < playerSequence.Count; i++)
            {
                if (playerSequence[i] == robot.CorrectSequence[i])
                {
                    correctCount++;
                    //                    print("Correct colour at position " + correctCount);
                }
                else
                {
                    IncorrectText.text = "Incorrect sequence! Please try again.";
                    //     print("Incorrect sequence!");
                    SoundManager.PlaySound("AI_CommentOnFailure");
                    robot.ShowColour();

                }
            }
            if (correctCount == 4)
            {
                Puzzle4Timer.StartTimer = false;
                EndPuzzleSound();

                playerStatus.CurrentGameState = PlayerStatus.GameState.Puzzle5;
                playerObjective.UpdateObjective();
                StartCoroutine(WaitBeforeReset());
            }

        }
        else if (playerSequence.Count < 4)
        {
            PuzzleFailSound();
            IncorrectText.text = "Not enough colours selected!";
            //  print("Not enough colours selected!");
            robot.ShowColour();
        }
        else if (playerSequence.Count > 4)
        {
            PuzzleFailSound();
            IncorrectText.text = "Too many colours selected!";
            //   print("Too many colours selected!");
            robot.ShowColour();
        }
        else
        {
            PuzzleFailSound();
            IncorrectText.text = "Please select a colour!";
            //   print("Please select a colour!");
        }

        playerSequence.Clear();

    }
    // switches the buttons to a state where you cant press them to avoid player interuption
    public void ButtonsOff()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;

        }
    }
    // switches the buttons to a state where you can press them
    public void ButtonsOn()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }


    }

    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously

        //    print("Correct sequence!");
        IncorrectText.text = "Correct sequence!";
        playerObjective.UpdateObjective();
        puzzle5Manager.Puzzle5Start();
        StopTimer();
        exitInteractions.MoveCameraUp();



    }

}
