
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class Puzzle4Robot : MonoBehaviour
{

    public List<string> CodeOptions = new List<string> { "Red", "Blue", "Green", "Yellow", "White" };

    public List<string> CorrectSequence = new List<string> { "Red", "Red", "Red", "Red" };
    public Puzzle4Manager puzzle4Manager;
    public SpriteRenderer spriteRenderer;
    public Sprite[] CodeOptionsImageNames;


    public void Puzzle4RobotStart()
    {
        // Generates the random sequence for the game and then shows the colours
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        CorrectSequence[0] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[1] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[2] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[3] = CodeOptions[(int)Random.Range(0, 4)];
        ShowColour();

    }


    public void ShowColour()
    {
        // disables player input by the buttons
        puzzle4Manager.ButtonsOff();
        StartCoroutine(ShowColourDelay());


    }
    // Shows the colour memory with a short white colour inbetween each other to differiant if there was 2 or more of the same colour
    private IEnumerator ShowColourDelay()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var item in CorrectSequence)
        {
            if (item == "Red")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[0];
                Debug.Log("Red");
            }
            else if (item == "Blue")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[1];
                Debug.Log("Blue");
            }
            else if (item == "Green")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[2];
                Debug.Log("Green");
            }
            else if (item == "Yellow")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[3];
                Debug.Log("Yellow");
            }



            // Wait for 1 seconds before showing the next color
            yield return new WaitForSeconds(1f);
            spriteRenderer.sprite = CodeOptionsImageNames[4]; ; // Show white inbetween
            yield return new WaitForSeconds(0.5f);

        }
        puzzle4Manager.ButtonsOn();
    }




}
