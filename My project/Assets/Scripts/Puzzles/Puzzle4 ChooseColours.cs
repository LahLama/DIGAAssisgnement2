using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4ChooseColours : MonoBehaviour
{
    public Puzzle4Manager puzzle4Manager;
    public Puzzle4Robot Puzzle4Robot;


    public void OnClick()
    {
        // Depending on what the player clicks , it will add that colour to the sequence and temporarily disable the buttons
        puzzle4Manager.IncorrectText.text = "";
        switch (name)
        {
            case "Red":
                puzzle4Manager.playerSequence.Add("Red");
                Puzzle4Robot.spriteRenderer.sprite = Puzzle4Robot.CodeOptionsImageNames[0];
                StartCoroutine(Delay());
                break;
            case "Blue":
                puzzle4Manager.playerSequence.Add("Blue");
                Puzzle4Robot.spriteRenderer.sprite = Puzzle4Robot.CodeOptionsImageNames[1];
                StartCoroutine(Delay());
                break;
            case "Green":
                puzzle4Manager.playerSequence.Add("Green");
                Puzzle4Robot.spriteRenderer.sprite = Puzzle4Robot.CodeOptionsImageNames[2];
                StartCoroutine(Delay());
                break;
            case "Yellow":
                puzzle4Manager.playerSequence.Add("Yellow");
                Puzzle4Robot.spriteRenderer.sprite = Puzzle4Robot.CodeOptionsImageNames[3];
                StartCoroutine(Delay());
                break;
            default:
                // print("THIS HAS NO COLOUR");
                break;
        }
        //print("player seq count is: " + puzzle4Manager.playerSequence.Count);


    }

    private IEnumerator Delay()
    {
        puzzle4Manager.ButtonsOff();
        yield return new WaitForSeconds(0.5f);
        Puzzle4Robot.spriteRenderer.sprite = Puzzle4Robot.CodeOptionsImageNames[4];
        puzzle4Manager.ButtonsOn();

    }


}
