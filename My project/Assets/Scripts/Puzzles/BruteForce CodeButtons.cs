using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
/*
Title:  How to GetComponent Image, color,alpha.
Author: Busil
Date :  Feb 2016
Availibility: https://discussions.unity.com/t/how-to-getcomponent-image-color-alpha/159531


//[1] Button Sound Effect. Mixkit, [Sound Effect] .https://mixkit.co/free-sound-effects/discover/button/  Date Accessed: 18 / 05 / 2025


*/

public class BruteForceCodeButtons : MonoBehaviour

{


    Image CodeBlock;
    private Light2D light2D;
    // Arrays that have the colour order, tags, and image names
    public string[] CodeOptions = { "Puzzle3Blue", "Puzzle3Yellow", "Puzzle3Red", "Puzzle3Green" };
    private Color[] CodeOptionsColor = { Color.blue, Color.yellow, Color.red, Color.green };
    public Sprite[] CodeOptionsImageNames;
    public int ChoiceIndex = 0;

    public void OnClick()
    {
        light2D = this.GetComponent<Light2D>();
        // Cycles through the colours and tags stipulated in the arrays above. 
        if (ChoiceIndex == CodeOptionsImageNames.Length)
        {//[1]

            ChoiceIndex = 0;
            CodeBlock.sprite = CodeOptionsImageNames[ChoiceIndex];
            gameObject.tag = CodeOptions[ChoiceIndex];
            ChoiceIndex++;
        }
        else
        {
            GameInteractionSoundManager.PlaySound("knob");
            CodeBlock = GetComponent<Image>();
            gameObject.GetComponent<Light2D>().color = CodeOptionsColor[ChoiceIndex]; // Store the current color of the CodeBlock
            //Color CurrentColor = CodeBlock.color;
            //CodeBlock.color = CodeOptionsColor[ChoiceIndex];
            CodeBlock.sprite = CodeOptionsImageNames[ChoiceIndex];
            gameObject.tag = CodeOptions[ChoiceIndex];
            ChoiceIndex++;
            print(gameObject.tag);
        }
    }
}
