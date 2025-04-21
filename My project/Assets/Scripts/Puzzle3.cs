using UnityEngine;


public class Puzzle3 : MonoBehaviour
{

    public Puzzle3CodeButtons CdeBtn;
    public int CorrectChoice = 0;
    public int Codechances = 5;

    public string[] CorrectCode = { "x", "x", "x", "x" };

    public GameObject[] PlayerCode;

    public GameObject[] CodeLights;
    void Awake()
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

        CorrectChoice = 0;
        int indexure = 0;
        foreach (var CodePiece in PlayerCode)
        {
            if (CodePiece.tag == CorrectCode[indexure])
            {
                print("SWITCH ON LIGHT AT " + indexure);
                CodeLights[indexure].GetComponent<SpriteRenderer>().color = Color.green;
                CorrectChoice++;
                if (CorrectChoice == CorrectCode.Length)
                {
                    print("PUZZLE WON");
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
