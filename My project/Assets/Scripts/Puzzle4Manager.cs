using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4Manager : MonoBehaviour
{
    public PlayerObjective playerObjective;

    public TextMeshProUGUI IncorrectText;
    public ExitInteractions exitInteractions;
    public Puzzle4Robot robot;
    public List<string> playerSequence;
    public TimerScript Puzzle4Timer;

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
            for (int i = 0; i < playerSequence.Count; i++)
            {
                if (playerSequence[i] == robot.CorrectSequence[i])
                {
                    print("Correct sequence!");
                    IncorrectText.text = "Correct sequence!";
                        playerObjective.UpdateObjective();
                         Puzzle4Timer.StartTimer = false;
                        exitInteractions.MoveCameraUp();
                }
                else
                {
                    IncorrectText.text = "Incorrect sequence! Please try again.";
                    print("Incorrect sequence!");
                    SoundManager.PlaySound("AI_CommentOnFailure");
                    robot.ShowColour();
                    break;
                }
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
}
