using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4Manager : PuzzleClass
{
    public PlayerObjective playerObjective;

    public TextMeshProUGUI IncorrectText;
    public ExitInteractions exitInteractions;
    public Puzzle4Robot robot;
    public List<string> playerSequence;
    public TimerScript Puzzle4Timer;
    public Puzzle5Manager puzzle5Manager;
    private int correctCount = 0;

    public Button[] buttons;


    public void Puzzle4Start()
    {
        ButtonsOff();
        robot.Puzzle4RobotStart();
        Puzzle4Timer.remianingTime = 120;//seconds
        Puzzle4Timer.StartTimer = true;

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
                    print("Correct colour at position " + correctCount);
                }
                else
                {
                    IncorrectText.text = "Incorrect sequence! Please try again.";
                    print("Incorrect sequence!");
                    SoundManager.PlaySound("AI_CommentOnFailure");
                    robot.ShowColour();

                }
            }
            if (correctCount == 4)
            {
                Puzzle4Timer.StartTimer = false;
                EndPuzzleSound();
                StartCoroutine(WaitBeforeReset());
            }

        }
        else if (playerSequence.Count < 4)
        {
            IncorrectText.text = "Not enough colours selected!";
            print("Not enough colours selected!");
            robot.ShowColour();
        }
        else if (playerSequence.Count > 4)
        {
            IncorrectText.text = "Too many colours selected!";
            print("Too many colours selected!");
            robot.ShowColour();
        }
        else
        {
            IncorrectText.text = "Please select a colour!";
            print("Please select a colour!");
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

        print("Correct sequence!");
        IncorrectText.text = "Correct sequence!";
        playerObjective.UpdateObjective();
        puzzle5Manager.Puzzle5Start();
        exitInteractions.MoveCameraUp();


    }

}
