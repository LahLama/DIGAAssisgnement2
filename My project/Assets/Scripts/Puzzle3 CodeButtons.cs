using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3CodeButtons : MonoBehaviour

{


    //https://discussions.unity.com/t/how-to-getcomponent-image-color-alpha/159531/2

    Image CodeBlock;

    public string[] CodeOptions = { "Puzzle3Red", "Puzzle3Green", "Puzzle3Blue", "Puzzle3Yellow" };
    public Color[] CodeOptionsColor = { Color.red, Color.green, Color.blue, Color.yellow };
    public int ChoiceIndex = 0;


    public void OnClick()
    {
        if (ChoiceIndex == CodeOptionsColor.Length)
        {
            ChoiceIndex = 0;
            CodeBlock.color = CodeOptionsColor[ChoiceIndex];
            gameObject.tag = CodeOptions[ChoiceIndex];
            ChoiceIndex++;
        }
        else
        {

            CodeBlock = GetComponent<Image>();
            Color CurrentColor = CodeBlock.color;
            CodeBlock.color = CodeOptionsColor[ChoiceIndex];
            gameObject.tag = CodeOptions[ChoiceIndex];
            ChoiceIndex++;
            print(gameObject.tag);
        }
    }
}
