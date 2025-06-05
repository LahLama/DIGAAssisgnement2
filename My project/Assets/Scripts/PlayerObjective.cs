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
        AiInteractionSoundManager.PlaySound("Intro");
        Objective.text = "Intro";
        AIAnimator = AIHolder.GetComponent<Animator>();
        Objective.text = "";
        AIAnimator.SetTrigger("PopUp");
        StartCoroutine(WaitForAnimationAndPopAway());
    }

    public void UpdateObjective()
    {
        PlayerStatus.GameState gamestate = playerStatus.CurrentGameState;

        if (gamestate.Equals(PlayerStatus.GameState.Puzzle1))
        {
            AiInteractionSoundManager.PlaySound("Puzzle1");
            Objective.text = "Puzzle 1";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle2))
        {
            AiInteractionSoundManager.PlaySound("Puzzle2");
            Objective.text = "Puzzle 2";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle3))
        {
            AiInteractionSoundManager.PlaySound("Puzzle3");
            Objective.text = "Puzzle 3";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle4))
        {
            AiInteractionSoundManager.PlaySound("Puzzle4");
            Objective.text = "Puzzle 4";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle5))
        {
            AiInteractionSoundManager.PlaySound("Puzzle5");
            Objective.text = "Puzzle 5";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle6))
        {
            AiInteractionSoundManager.PlaySound("Puzzle6");
            Objective.text = "Puzzle 6";
        }


        else if (gamestate.Equals(PlayerStatus.GameState.Player2))
        {
            AiInteractionSoundManager.PlaySound("Microchip1");
            Objective.text = "Microchip 1";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Player3))
        {
            AiInteractionSoundManager.PlaySound("Microchip2");
            Objective.text = "Microchip 2";
        }

        else if (gamestate.Equals(PlayerStatus.GameState.EndGame))
        {
            AiInteractionSoundManager.PlaySound("EndGame");
            Objective.text = "End Game";
        }
        else
        {
            AiInteractionSoundManager.PlaySound("Intro");
            Objective.text = "Intro";
        }

    }

    private IEnumerator WaitForAnimationAndPopAway()
    {
        yield return new WaitForSeconds(3.2f);        //Three seconds is the delay of the animation
        AIAnimator.SetTrigger("PopAway");
        Objective.text = newObjective;
    }
}