using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2CodeButtons : MonoBehaviour

{


    //https://discussions.unity.com/t/how-to-getcomponent-image-color-alpha/159531/2

    Image CodeBlock;

    public string[] CodeOptions = { "Puzzle3Blue", "Puzzle3Yellow", "Puzzle3Red", "Puzzle3Green" };
    public Color[] CodeOptionsColor = { Color.blue, Color.yellow, Color.red, Color.green };
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
