using UnityEngine;


public class Puzzle2Manager : MonoBehaviour
{

    public Puzzle2CodeButtons CdeBtn;
    public int CorrectChoice = 0;
    public int Codechances = 5;
    public string[] CorrectCode = { "x", "x", "x", "x" };

    public GameObject[] PlayerCode;

    public GameObject[] CodeLights;

    public ExitInteractions exitInteractions;
    public Rigidbody2D camera1;
    public PlayerStatus playerStatus;
    public TimerScript Puzzle2Timer;
    bool startTimer;
    float remianingTime;
    int playerlvl;
    void Awake()
    {
        Codechances = 5;
        CorrectChoice = 0;

        CorrectCode[0] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[1] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[2] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
        CorrectCode[3] = CdeBtn.CodeOptions[UnityEngine.Random.Range(0, 4)];
    }

    public void StartPuzzle2()
    {
        Puzzle2Timer.remianingTime = 20;//seconds
        Puzzle2Timer.StartTimer = true;
    }

    void Update()
    {



    }

    public void ValidatePlayerCode()
    {
        remianingTime = 20;//seconds
        CorrectChoice = 0;
        int indexure = 0;
        foreach (var CodePiece in PlayerCode)
        {
            if (CodePiece.tag == CorrectCode[indexure])
            {
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.green;
                CorrectChoice++;
                if (CorrectChoice == 4)
                {
                    playerlvl = 3;
                    Vector3 newPosition = camera1.transform.position;
                    newPosition.x += 1920;
                    newPosition.y -= 1080;
                    camera1.transform.position = newPosition;
                    playerStatus.PlayPuzz2 = false;
                    Puzzle2Timer.StartTimer = false;
                }
            }
            else
            {
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.red;
            }
            print(Codechances);

            indexure++;
        }
        Codechances--;
        if (Codechances <= 0)
        {
            print("PUZZLE FAILED");
        }
    }
}
