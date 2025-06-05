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
        newObjective = lastObjectiveText;

        if (playerStatus.PlayerLevel == 1)
        {
            newObjective = "Find all the microchips!";
            AiInteractionSoundManager.PlaySound("Intro");
        }
        else if (playerStatus.PlayerLevel == 2 && !playerStatus.PlayPuzz1)
        {
            newObjective = "Fine, try and solve the first puzzle!";
            AiInteractionSoundManager.PlaySound("Puzzle1");
        }
        else if (playerStatus.PlayerLevel == 2 && playerStatus.PlayPuzz1)
        {
            newObjective = "Finding the microchips wont be so easy now!";
            AiInteractionSoundManager.PlaySound("Microchip1");
        }
        else if (playerStatus.PlayerLevel == 3 && !playerStatus.PlayPuzz2)
        {
            newObjective = "Turns out your not so dumb after all, solve the second puzzle!";
            AiInteractionSoundManager.PlaySound("Puzzle2");
        }
        else if (playerStatus.PlayerLevel == 3 && playerStatus.PlayPuzz2)
        {
            newObjective = "No one before you could find the last few microchips!";
            AiInteractionSoundManager.PlaySound("Microchip2");
        }
        else if (playerStatus.PlayerLevel == 4 && !playerStatus.PlayPuzz3)
        {
            newObjective = "As if you could find me!";
            AiInteractionSoundManager.PlaySound("Microchip3");
        }
        else if (playerStatus.PlayerLevel == 4 && playerStatus.PlayPuzz3)
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
    }

    private IEnumerator WaitForAnimationAndPopAway()
    {
        yield return new WaitForSeconds(3.2f);        //Three seconds is the delay of the animation
        AIAnimator.SetTrigger("PopAway");
        Objective.text = newObjective;
    }
}