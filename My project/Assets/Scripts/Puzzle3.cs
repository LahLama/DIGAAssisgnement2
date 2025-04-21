using UnityEngine;


public class Puzzle3 : MonoBehaviour
{

    public Puzzle3CodeButtons CdeBtn;
    public int CorrectChoice = 0;
    public int Codechances = 5;
    public PlayerStatus playerStatus;

    public string[] CorrectCode = { "x", "x", "x", "x" };

    public GameObject[] PlayerCode;

    public GameObject[] CodeLights;

    public ExitInteractions exitInteractions;
    public Rigidbody2D camera1;
    public PlayerStatus playerStatusP3;
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


    void Update()
    {
        playerlvl = playerStatusP3.PlayerLevel;
        camera1 = exitInteractions.MainCamera;
    }

    public void ValidatePlayerCode()
    {

        CorrectChoice = 0;
        int indexure = 0;
        foreach (var CodePiece in PlayerCode)
        {
            if (CodePiece.tag == CorrectCode[indexure])
            {
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.green;
                CorrectChoice++;
                if (CorrectChoice == CorrectCode.Length)
                {
                    playerlvl = 3;
                    float movementAmount = -1920;
                    Vector3 newPosition = camera1.transform.position;
                    newPosition.x += movementAmount;
                    camera1.transform.position = newPosition;
                    playerStatus.PlayPuzz2 = true;
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
