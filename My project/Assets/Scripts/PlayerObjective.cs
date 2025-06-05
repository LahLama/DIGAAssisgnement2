using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
/*
Title: Create UI ANIMATIONS without ❌CODING❌! - Unity UI tutorial 
Author: Coco Code
Date :  24 March 2024
Availibility: https://www.youtube.com/watch?v=br9YzpiBeIw
*/
/*
[1] Online Microsoft Sam TTS Generator. [AI Voice Generator] .https://www.tetyys.com/SAPI4/  Date Accessed: 18 / 05 / 2025
*/

public class PlayerObjective : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public TextMeshProUGUI Objective;
    public GameObject AIHolder;
    private Animator AIAnimator;


    private string lastObjectiveText = "";
    string newObjective = "";

    private void Start()
    {
        AIAnimator = AIHolder.GetComponent<Animator>();
        Objective.text = "";
        AIAnimator.SetTrigger("PopUp");
        StartCoroutine(WaitForAnimationAndPopAway());
        newObjective = "There is no way you can find all the microchips!";
    }

    public void UpdateObjective()
    {
        PlayerStatus.GameState gamestate = playerStatus.CurrentGameState;

        if (gamestate.Equals(PlayerStatus.GameState.Puzzle1))
        {
            AiInteractionSoundManager.PlaySound("Puzzle1");
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle2))
        {
            AiInteractionSoundManager.PlaySound("Puzzle2");
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle3))
        {
            AiInteractionSoundManager.PlaySound("Puzzle3");
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle4))
        {
            AiInteractionSoundManager.PlaySound("Puzzle4");
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle5))
        {
            AiInteractionSoundManager.PlaySound("Puzzle5");
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle6))
        {
            AiInteractionSoundManager.PlaySound("Puzzle6");
        }

        else if (gamestate.Equals(PlayerStatus.GameState.Player1))
        {
            AiInteractionSoundManager.PlaySound("Intro");
        }

        else if (gamestate.Equals(PlayerStatus.GameState.Player2))
        {
            AiInteractionSoundManager.PlaySound("Microchip1");
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Player3))
        {
            AiInteractionSoundManager.PlaySound("Microchip2");
        }

    }












    /*newObjective = lastObjectiveText;
        /*
                if (playerStatus.PlayerLevel == 1)
                {
                    newObjective = "There is no way you can find all the microchips!";
                    AiInteractionSoundManager.PlaySound("Intro");
                }
                else if (playerStatus.PlayerLevel == 2 && playerStatus.PuzzleLevel == 1)
                {
                    newObjective = "As if you can hack into my system software!";
                    AiInteractionSoundManager.PlaySound("Puzzle1");
                }
                else if (playerStatus.PlayerLevel == 2 && playerStatus.Puzzle1Finished)
                {
                    newObjective = "Finding the microchips wont be so easy now!";
                    AiInteractionSoundManager.PlaySound("Microchip1");
                }
                else if (playerStatus.PlayerLevel == 3 && !playerStatus.Puzzle2Finished)
                {
                    newObjective = "Security is on high, only a dumb human would try to brute force this!";
                    AiInteractionSoundManager.PlaySound("Puzzle2");
                }
                else if (playerStatus.PlayerLevel == 3 && playerStatus.Puzzle2Finished)
                {
                    newObjective = "Finding the microchips won't be so easy now!";
                    AiInteractionSoundManager.PlaySound("Microchip2");
                }
                else if (playerStatus.PlayerLevel == 4 && !playerStatus.Puzzle3Finished)
                {
                    newObjective = "As if you could find me!";
                    AiInteractionSoundManager.PlaySound("Microchip3");
                }
                else if (playerStatus.PlayerLevel == 4 && playerStatus.Puzzle3Finished)
                {
                    newObjective = "I will stop you on each level!";
                    AiInteractionSoundManager.PlaySound("Puzzle3");
                }
        
        // Only update if the objective has changed
        if (newObjective != lastObjectiveText)
        {
            AIAnimator.SetTrigger("PopUp");
            StartCoroutine(WaitForAnimationAndPopAway());
}
    }*/

    private IEnumerator WaitForAnimationAndPopAway()
    {
        yield return new WaitForSeconds(3.2f);        //Three seconds is the delay of the animation
        AIAnimator.SetTrigger("PopAway");
        Objective.text = newObjective;
    }
}