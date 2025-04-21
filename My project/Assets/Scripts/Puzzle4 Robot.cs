
using UnityEngine;

public class Puzzle4Robot : MonoBehaviour
{
    public GameObject Robot;
    public string[] CodeOptions = { "Red", "Blue", "Green", "Yellow" };

    public string[] CorrectSequence = { "red", "red", "red", "red" };



    int indexure;
    void Start()
    {
        CorrectSequence[0] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[1] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[2] = CodeOptions[(int)Random.Range(0, 4)];
        CorrectSequence[3] = CodeOptions[(int)Random.Range(0, 4)];

        //ShowColourDelay();
    }


    public void ShowColour()
    {
        foreach (var item in CorrectSequence)
        {
            if (item == "Puzzle3Red")
            {
                Robot.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (item == "Puzzle3Blue")
            {
                Robot.GetComponent<SpriteRenderer>().color = Color.blue;
                print("Blue");
            }
            if (item == "Puzzle3Green")
            {
                Robot.GetComponent<SpriteRenderer>().color = Color.green;
                print("green");
            }
            if (item == "Puzzle3Yellow")
            {
                Robot.GetComponent<SpriteRenderer>().color = Color.yellow;
                print("yellow");
            }

        }
    }

    public void ShowColourDelay()
    {
        int delay = 3;

        while (delay > 0)
        {
            delay -= 1 * (int)Time.deltaTime;
            print(delay);
        }
    }


}
