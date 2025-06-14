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
    public Material Material;
    public GameObject playerObjectiveHolder;
    private Material clonedMaterial;

    string objective = "objective";

    private void Start()
    {

        AiInteractionSoundManager.PlaySound("Intro");
        Objective.text = "Oh great, again... Let's see if you can find the microchips";
        //AIAnimator = AIHolder.GetComponent<Animator>();
        //AIAnimator.SetTrigger("PopUp");
        // StartCoroutine(WaitForAnimationAndPopAway());
    }

    public void UpdateObjective()
    {
        // Example usage: if (grandchild != null) { ... }
        if (clonedMaterial == null)
        {
            clonedMaterial = Instantiate(playerObjectiveHolder.GetComponent<Image>().material);
            playerObjectiveHolder.GetComponent<Image>().material = clonedMaterial;
        }

        StartCoroutine(DelayForObjectDestroy());


        PlayerStatus.GameState gamestate = playerStatus.CurrentGameState;

        if (gamestate.Equals(PlayerStatus.GameState.Puzzle1))
        {

            AiInteractionSoundManager.PlaySound("seq1");
            objective = "Humans can't be this smart. Let me test something";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle2))
        {
            AiInteractionSoundManager.PlaySound("seq3");

            objective = "Let's see if you are 100% a human because dumb human would try and brute force this next puzzle.";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle3))
        {
            //AiInteractionSoundManager.PlaySound("Puzzle3");
            AiInteractionSoundManager.PlaySound("seq5");
            objective = "That was a bit surprising...The way forward is mixed and meddelled up. YOU won't be able to FIND me!";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle4))
        {
            AiInteractionSoundManager.PlaySound("seq6");
            objective = "You've actually walked all your way here to your own demise? You might have found me, but you won't be able to catch me! ";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle5))
        {
            //AiInteractionSoundManager.PlaySound("Puzzle5");
            AiInteractionSoundManager.PlaySound("seq7");
            objective = "No! Get out of my circuitry you are going to open something!";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle6))
        {
            ///AiInteractionSoundManager.PlaySound("Puzzle6");
            AiInteractionSoundManager.PlaySound("seq9");
            objective = "Get your filthy USB away from me!";
        }

        else if (gamestate.Equals(PlayerStatus.GameState.Player1))
        {
            AiInteractionSoundManager.PlaySound("Intro");

        }

        else if (gamestate.Equals(PlayerStatus.GameState.Player2))
        {
            AiInteractionSoundManager.PlaySound("seq2");
            objective = "Okay, it seems like you are human. This time it won't be so easy!";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Player3))
        {
            AiInteractionSoundManager.PlaySound("seq4");
            objective = "Search as much as you want. The cat has hidden them perfectly";
        }

        else if (gamestate.Equals(PlayerStatus.GameState.EndGame))
        {
            AiInteractionSoundManager.PlaySound("seq11");
            objective = "Leave my code alone...I am perfect...You never were...Please don't end me...I'm sorry...";
        }
        StartCoroutine(DelayForObjectRebuild());

    }

    /*private IEnumerator WaitForAnimationAndPopAway()
    {
        //yield return new WaitForSeconds(3.2f);        //Three seconds is the delay of the animation
        // AIAnimator.SetTrigger("PopAway");
        //objective = newObjective;
    }*/


    private IEnumerator DelayForObjectDestroy()
    {

        float targetHeight = 0f;
        while (targetHeight <= 1f)
        {
            clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
            targetHeight += 0.1f;
            if (targetHeight == 0.4f)
            {
                Objective.text = "";
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator DelayForObjectRebuild()
    {

        yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds before starting the fade out
        float targetHeight = 1f;
        while (targetHeight > 0f)
        {
            clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
            targetHeight -= 0.1f;
            if (targetHeight < 0.2f)
            {
                Objective.text = objective;
            }
            yield return new WaitForSeconds(0.05f);
        }



    }
}