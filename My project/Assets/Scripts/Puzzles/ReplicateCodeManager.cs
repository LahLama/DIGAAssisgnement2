using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReplicateCodeManager : PuzzleClass
{
    [Header("Scripts")]


    public JigsawManager puzzle5Manager;
    public ExitInteractions exitInteractions;

    [Header("Objects")]
    public TextMeshProUGUI IncorrectText;
    public ReplicateCodeRobot robot;

    [Header("Lists")]
    public List<string> playerSequence;
    public Button[] buttons;
    private int correctCount = 0;

    public void ReplicateCodePuzzleStart()
    {
        AiInteractionSoundManager.PlaySound("PuzzleSourceCode");
        ButtonsOff();
        StartCoroutine(PuzzleWaitTime());
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
                    AiInteractionSoundManager.PlaySound("Failure");
                    robot.ShowColour();


                }
            }
            if (correctCount == 4)
            {
                EndPuzzleSound();


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
        StopTimer();
        AiInteractionSoundManager.PlaySound("seq12");

        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously

        //    print("Correct sequence!");
        IncorrectText.text = "Correct sequence!";
        exitInteractions.MoveCameraDown();



    }

    IEnumerator PuzzleWaitTime()
    {
        yield return new WaitForSeconds(2f);
        robot.ReplicateCodeRobotStart();
        StartTimer();

    }

}
