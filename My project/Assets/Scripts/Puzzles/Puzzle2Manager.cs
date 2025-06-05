using System.Collections;
using UnityEngine;

public class Puzzle2Manager : PuzzleClass
{
    // Varibles that are used across puzzle 2 scripts. Intial values are stored here
    public int CorrectChoice = 0;
    public int Codechances = 5;
    bool CanTalk = true;
    public string[] CorrectCode = { "x", "x", "x", "x" };
    public GameObject[] PlayerCode;
    public GameObject[] CodeLights;
    public Puzzle2CodeButtons CdeBtn;
    public Rigidbody2D camera1;
    bool startTimer;

    //Referencing the scripts that are needed for player stas, and for starting and stopping the timer two 
    public PlayerStatus playerStatus;
    public TimerScript Puzzle2Timer;
    public PlayerObjective playerObjective;



    // used in Exit Interactions
    public void StartPuzzle2()
    {
        StartTimer();
        intializeColours(); // initializes the colours

    }

    // intializes the values with random values
    void intializeColours()
    {
        Codechances = 5;
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
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.green;
                CorrectChoice++;
                SoundManager.PlaySound("ButtonClick");
                if (CorrectChoice == 4)
                {
                    EndPuzzleSound();
                    Puzzle2Timer.StartTimer = false;
                    //puzzle has been completed
                    playerStatus.CurrentGameState = PlayerStatus.GameState.Player3;

                    StartCoroutine(WaitBeforeReset());
                }
            }
            else
            {   //if it was an incorrect choice, set the above circle to be red.
                SoundManager.PlaySound("ButtonClick");
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.red;
            }
            print(Codechances);

            indexure++;
        }
        if (CanTalk)
        {
            PuzzleFailSound();
            Codechances--;
        }
        // STILL TO BE IMPLEMENTED
        if (Codechances <= 0)
        {
            print("PUZZLE FAILED");
        }
    }

    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously


        StopTimer();
        //move camera to the next level
        Vector3 newPosition = camera1.transform.position;
        newPosition.x += 960;
        newPosition.y -= 540;
        camera1.transform.position = newPosition;

        //stop the timer and play the AI response


        playerObjective.UpdateObjective();
        CanTalk = false;

    }
}
