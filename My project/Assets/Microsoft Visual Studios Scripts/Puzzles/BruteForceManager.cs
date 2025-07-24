using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BruteForceManager : PuzzleClass
{
    // Varibles that are used across puzzle 2 scripts. Intial values are stored here
    public int CorrectChoice = 0;
    public string[] CorrectCode = { "Puzzle3Blue", "Puzzle3Blue", "Puzzle3Blue", "Puzzle3Blue" };
    public GameObject[] PlayerCode;
    public GameObject[] CodeLights;
    public BruteForceCodeButtons CdeBtn;
    public Rigidbody2D camera1;

    //Referencing the scripts that are needed for player stas, and for starting and stopping the timer two 
    public PlayerStatus playerStatus;
    public PlayerObjective playerObjective;



    // used in Exit Interactions
    public void StartPuzzleBruteForce()
    {
        StartTimer();
        intializeColours(); // initializes the colours
        AiInteractionSoundManager.PlaySound("PuzzleBruteForce");


    }

    // intializes the values with random values
    void intializeColours()
    {
        CorrectChoice = 0;

        CorrectCode[0] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[1] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[2] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[3] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
    }
    public void ValidatePlayerCode()
    {
        // goes through the player sequecne and the correct sequence element by element and sees if they correspond/
        CorrectChoice = 0;
        int indexure = 0;
        foreach (var CodePiece in PlayerCode)
        {
            if (CodePiece.tag == CorrectCode[indexure])
            {
                //if the corresponding element is correct then turn the circle above it to green to show a correct choice
                CodeLights[indexure].GetComponent<Light2D>().color = Color.green;
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.green;
                CorrectChoice++;
                GameInteractionSoundManager.PlaySound("knob");
                if (CorrectChoice == 4)
                {
                    EndPuzzleSound();
                    //puzzle has been completed

                    StartCoroutine(WaitBeforeReset());
                }
            }
            else
            {   //if it was an incorrect choice, set the above circle to be red.
                GameInteractionSoundManager.PlaySound("knob");
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.red;
                CodeLights[indexure].GetComponent<Light2D>().color = Color.red;
            }


            indexure++;
        }
        PuzzleFailSound();




    }

    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        StopTimer();
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously



        //move camera to the next level
        Vector3 newPosition = camera1.transform.position;
        newPosition.x += 960;
        newPosition.y -= 540;
        camera1.transform.position = newPosition;

        //stop the timer and play the AI response
        playerStatus.CurrentGameState = PlayerStatus.GameState.Player3;



        playerObjective.UpdateObjective();

    }
}
