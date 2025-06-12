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
    public Material Material;
    public GameObject playerObjectiveHolder;
    private Material clonedMaterial;

    string objective = "objective";

    private void Start()
    {

        AiInteractionSoundManager.PlaySound("Intro");

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

            // AiInteractionSoundManager.PlaySound("Puzzle1");
            objective = "A";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle2))
        {
            //AiInteractionSoundManager.PlaySound("Puzzle2");
            AiInteractionSoundManager.PlaySound("Taunt");
            objective = "B";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle3))
        {
            //AiInteractionSoundManager.PlaySound("Puzzle3");
            AiInteractionSoundManager.PlaySound("Taunt");
            objective = "C";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle4))
        {
            AiInteractionSoundManager.PlaySound("Taunt");
            objective = "D";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle5))
        {
            //AiInteractionSoundManager.PlaySound("Puzzle5");
            AiInteractionSoundManager.PlaySound("Taunt");
            objective = "E";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Puzzle6))
        {
            ///AiInteractionSoundManager.PlaySound("Puzzle6");
            AiInteractionSoundManager.PlaySound("Taunt");
            objective = "F";
        }

        else if (gamestate.Equals(PlayerStatus.GameState.Player1))
        {
            AiInteractionSoundManager.PlaySound("Intro");
            objective = "G";
        }

        else if (gamestate.Equals(PlayerStatus.GameState.Player2))
        {
            AiInteractionSoundManager.PlaySound("Microchip1");
            objective = "H";
        }
        else if (gamestate.Equals(PlayerStatus.GameState.Player3))
        {
            AiInteractionSoundManager.PlaySound("Microchip2");
            objective = "I";
        }

        else if (gamestate.Equals(PlayerStatus.GameState.EndGame))
        {
            AiInteractionSoundManager.PlaySound("EndGame");
            objective = "J";
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
            if (targetHeight == 0.5f)
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
            if (targetHeight < 0.5f)
            {
                Objective.text = objective;
            }
            yield return new WaitForSeconds(0.05f);
        }



    }
}