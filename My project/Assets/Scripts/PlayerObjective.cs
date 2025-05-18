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



public class PlayerObjective : MonoBehaviour
{

    public PlayerStatus playerStatus;
    public TextMeshProUGUI Objective;

    public GameObject AIHolder; 
    private Animator AIAnimator;

    private string lastObjectiveText = "";
     string newObjective = "";
    private void Start(){

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
            newObjective = "Find all the microchips!";
        else if (playerStatus.PlayerLevel == 2 && !playerStatus.PlayPuzz1)
            newObjective = "Fine, try and solve the first puzzle!";
        else if (playerStatus.PlayerLevel == 2 && playerStatus.PlayPuzz1)
            newObjective = "Finding the microchips wont be so easy now!";
        else if (playerStatus.PlayerLevel == 3 && !playerStatus.PlayPuzz2)
            newObjective = "Turns out your not so dumb after all, solve the second puzzle!";
        else if (playerStatus.PlayerLevel == 3 && playerStatus.PlayPuzz2)
            newObjective = "No one before you could find the last few microchips!";
        else if (playerStatus.PlayerLevel == 4 && !playerStatus.PlayPuzz3)
            newObjective = "As if you could find me!";
        else if (playerStatus.PlayerLevel == 4 && playerStatus.PlayPuzz3)
            newObjective = "I will stop you on each level!";

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

  /*      // Only update if the objective has changed
  if (newObjective != lastObjectiveText)
{
    Objective.text = newObjective;
    AIAnimator.SetTrigger("PopUp");
    StartCoroutine(WaitForAnimationAndPopAway());
    lastObjectiveText = newObjective;
}

    }

    private IEnumerator WaitForAnimationAndPopAway()
{
    // Wait until the "PopUp" animation is playing
    while (!AIAnimator.GetCurrentAnimatorStateInfo(0).IsName("PopUp"))
        yield return null;

    // Wait until the "PopUp" animation is no longer playing
    while (AIAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        yield return null;

    // Now trigger the "PopAway" animation
    AIAnimator.SetTrigger("PopAway");
}*/
}
