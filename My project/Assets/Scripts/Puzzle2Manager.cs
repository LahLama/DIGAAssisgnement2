using UnityEngine;


public class Puzzle2Manager : MonoBehaviour
{
    // Varibles that are used across puzzle 2 scripts. Intial values are stored here
    public int CorrectChoice = 0;
    public int Codechances = 5;
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
    
    // intializes the values with random values
    void Awake()
    {
        Codechances = 5;
        CorrectChoice = 0;

        CorrectCode[0] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[1] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[2] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[3] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
    }

// used in Exit Interactions
    public void StartPuzzle2()
    {
        Puzzle2Timer.remianingTime = 120;//seconds
        Puzzle2Timer.StartTimer = true;
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
                if (CorrectChoice == 4)
                {
                    //puzzle has been completed
                    playerStatus.PlayPuzz2 = true;

                    //move camera to the next level
                    Vector3 newPosition = camera1.transform.position;
                    newPosition.x += 960;
                    newPosition.y -= 540;
                    camera1.transform.position = newPosition;

                    //stop the timer and play the AI response
                    Puzzle2Timer.StartTimer = false;
                    SoundManager.PlaySound("AI_puzzleComplete2");
                    playerObjective.UpdateObjective();

                }
            }
            else
            {   //if it was an incorrect choice, set the above circle to be red.

                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.red;
            }
            print(Codechances);

            indexure++;
        }
        Codechances--;

        // STILL TO BE IMPLEMENTED
        if (Codechances <= 0)
        {
            print("PUZZLE FAILED");
        }
    }
}
