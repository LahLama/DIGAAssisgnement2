using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4Manager : MonoBehaviour
{
    /// <summary>
    /// ADD A THING THAT SHOWS THE PLAYER THE COLOURS THEY HAVE SELECTED
    /// </summary>


    public TextMeshProUGUI IncorrectText;
    public Puzzle4Robot robot;
    public List<string> playerSequence;

    public Button[] buttons;
    public void Puzzle4Start()
    {
        ButtonsOff();
        robot.Puzzle4RobotStart();
    }
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

                }
                else
                {
                    IncorrectText.text = "Incorrect sequence! Please try again.";
                    print("Incorrect sequence!");
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

    public void ButtonsOff()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;

        }
    }

    public void ButtonsOn()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }


    }
}
