
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4Robot : MonoBehaviour
{

    public List<string> CodeOptions = new List<string> { "Red", "Blue", "Green", "Yellow" };

    public List<string> CorrectSequence = new List<string> { "Red", "Red", "Red", "Red" };
    public Puzzle4Manager puzzle4Manager;

    void Start()
    {
        CorrectSequence[0] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[1] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[2] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[3] = CodeOptions[(int)Random.Range(0, 4)];
        ShowColour();

    }


    public void ShowColour()
    {
        puzzle4Manager.ButtonsOff();
        StartCoroutine(ShowColourDelay());


    }

    private IEnumerator ShowColourDelay()
    {

        foreach (var item in CorrectSequence)
        {
            if (item == "Red")
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log("Red");
            }
            else if (item == "Blue")
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                Debug.Log("Blue");
            }
            else if (item == "Green")
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                Debug.Log("Green");
            }
            else if (item == "Yellow")
            {
                this.GetComponent<SpriteRenderer>().color = Color.yellow;
                Debug.Log("Yellow");
            }



            // Wait for 1 seconds before showing the next color
            yield return new WaitForSeconds(1f);
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);

        }
        puzzle4Manager.ButtonsOn();
    }




}
