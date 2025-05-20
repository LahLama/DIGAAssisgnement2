using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/*
Title:  How to GetComponent Image, color,alpha.
Author: Busil
Date :  Feb 2016
Availibility: https://discussions.unity.com/t/how-to-getcomponent-image-color-alpha/159531


//[1] Button Sound Effect. Mixkit, [Sound Effect] .https://mixkit.co/free-sound-effects/discover/button/  Date Accessed: 18 / 05 / 2025


*/

public class Puzzle2CodeButtons : MonoBehaviour

{


    Image CodeBlock;
    //Arrays that have the colour order and tags
    public string[] CodeOptions = { "Puzzle3Blue", "Puzzle3Yellow", "Puzzle3Red", "Puzzle3Green" };
    public Color[] CodeOptionsColor = { Color.blue, Color.yellow, Color.red, Color.green };
    public int ChoiceIndex = 0;


    public void OnClick()
    {
        // Cycles through the colours and tags stipulated in the arrays above. 
        if (ChoiceIndex == CodeOptionsColor.Length)
        {//[1]
        
            ChoiceIndex = 0;
            CodeBlock.color = CodeOptionsColor[ChoiceIndex];
            gameObject.tag = CodeOptions[ChoiceIndex];
            ChoiceIndex++;
        }
        else
        {
            SoundManager.PlaySound("ButtonClick");
            CodeBlock = GetComponent<Image>();
            Color CurrentColor = CodeBlock.color;
            CodeBlock.color = CodeOptionsColor[ChoiceIndex];
            gameObject.tag = CodeOptions[ChoiceIndex];
            ChoiceIndex++;
            print(gameObject.tag);
        }
    }
}
