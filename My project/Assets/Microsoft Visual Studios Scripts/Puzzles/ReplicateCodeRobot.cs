
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Splines.ExtrusionShapes;

public class ReplicateCodeRobot : MonoBehaviour
{

    public List<string> CodeOptions = new List<string> { "Red", "Blue", "Green", "Yellow", "White" };

    public List<string> CorrectSequence = new List<string> { "Red", "Red", "Red", "Red" };
    public ReplicateCodeManager replicateCodeManager;
    public SpriteRenderer spriteRenderer;
    public Sprite[] CodeOptionsImageNames;


    public void ReplicateCodeRobotStart()
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
        replicateCodeManager.ButtonsOff();
        StartCoroutine(ShowColourDelay());


    }
    // Shows the colour memory with a short white colour inbetween each other to differiant if there was 2 or more of the same colour
    private IEnumerator ShowColourDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameInteractionSoundManager.PlaySound("knob");
        foreach (var item in CorrectSequence)
        {
            if (item == "Red")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[0];
                this.GetComponent<Light2D>().color = Color.red;
                //   Debug.Log("Red");
            }
            else if (item == "Blue")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[1];
                this.GetComponent<Light2D>().color = Color.blue;
                //  Debug.Log("Blue");
            }
            else if (item == "Green")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[2];
                this.GetComponent<Light2D>().color = Color.green;
                //    Debug.Log("Green");
            }
            else if (item == "Yellow")
            {
                spriteRenderer.sprite = CodeOptionsImageNames[3];
                this.GetComponent<Light2D>().color = Color.yellow;
                //    Debug.Log("Yellow");
            }



            // Wait for 1 seconds before showing the next color
            yield return new WaitForSeconds(1f);
            GameInteractionSoundManager.PlaySound("knob");
            spriteRenderer.sprite = CodeOptionsImageNames[4]; ; // Show white inbetween
            this.GetComponent<Light2D>().color = Color.white;
            yield return new WaitForSeconds(0.5f);

        }
        replicateCodeManager.ButtonsOn();
    }




}
