using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ReplicateCodeChooseColours : MonoBehaviour
{
    public ReplicateCodeManager replicateCodeManager;
    public ReplicateCodeRobot replicateCodeRobot;


    public void OnClick()
    {
        GameInteractionSoundManager.PlaySound("knob");
        // Depending on what the player clicks , it will add that colour to the sequence and temporarily disable the buttons
        replicateCodeManager.IncorrectText.text = "";
        switch (name)
        {
            case "PuzzleRed":
                replicateCodeManager.playerSequence.Add("Red");
                replicateCodeRobot.spriteRenderer.sprite = replicateCodeRobot.CodeOptionsImageNames[0];
                replicateCodeRobot.GetComponent<Light2D>().color = Color.red;
                StartCoroutine(Delay());
                break;
            case "PuzzleBlue":
                replicateCodeManager.playerSequence.Add("Blue");
                replicateCodeRobot.spriteRenderer.sprite = replicateCodeRobot.CodeOptionsImageNames[1];
                replicateCodeRobot.GetComponent<Light2D>().color = Color.blue;
                StartCoroutine(Delay());
                break;
            case "PuzzleGreen":
                replicateCodeManager.playerSequence.Add("Green");
                replicateCodeRobot.spriteRenderer.sprite = replicateCodeRobot.CodeOptionsImageNames[2];
                replicateCodeRobot.GetComponent<Light2D>().color = Color.green;
                StartCoroutine(Delay());
                break;
            case "PuzzleYellow":
                replicateCodeManager.playerSequence.Add("Yellow");
                replicateCodeRobot.spriteRenderer.sprite = replicateCodeRobot.CodeOptionsImageNames[3];
                replicateCodeRobot.GetComponent<Light2D>().color = Color.yellow;
                StartCoroutine(Delay());
                break;
            default:
                // print("THIS HAS NO COLOUR");
                break;
        }
        //print("player seq count is: " + ReplicateCodeManager.playerSequence.Count);


    }

    private IEnumerator Delay()
    {
        replicateCodeManager.ButtonsOff();
        yield return new WaitForSeconds(0.5f);
        replicateCodeRobot.spriteRenderer.sprite = replicateCodeRobot.CodeOptionsImageNames[4];
        replicateCodeRobot.GetComponent<Light2D>().color = Color.white;
        replicateCodeManager.ButtonsOn();

    }


}
