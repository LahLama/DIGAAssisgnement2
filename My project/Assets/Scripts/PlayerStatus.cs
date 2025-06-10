
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // this sets up all the varibles that will be used to used to keep track off across multiple scripts
    //;-----------------------------------------------------------------------
    private int PlayerLevel;
    public int MicrochipCount;
    public int AnomalyCount;
    public int GameChances = 5;
    public int[] MicrosPerLevel = { 5, 6, 4 };
    //;-----------------------------------------------------------------------

    //Bools to check of a puzzle has been played
    public bool PlayerLevelUpBool = false;

    // Text Gameobjects that update with the current players stats
    public Canvas CheatButtons;
    //public TextMeshProUGUI AnomalyCountText;
    public TextMeshProUGUI MicroChipCountText;
    public TextMeshProUGUI PlayerLevelText;
    public TextMeshProUGUI GameChancesText;

    public PlayerObjective playerObjective;
    public GameState CurrentGameState;



    // intiallizes all the nessercary varibles and plays the AI intro sound
    void Awake()
    {
        CurrentGameState = GameState.Player1;
        PlayerLevel = 1;
        MicrochipCount = 0;
        GameChances = 5;
    }
    void Update()
    {
        MicroPlayerUp();
        /* if (Input.GetKeyDown(KeyCode.L))
         {
             CheatButtons.gameObject.SetActive(!CheatButtons.isActiveAndEnabled);
         }*/
        // updates the microchip count up til the last entry in the array
        if (PlayerLevel <= MicrosPerLevel.Length)
        {
            MicroChipCountText.text = ": " + MicrochipCount.ToString() + "/" + MicrosPerLevel[PlayerLevel - 1].ToString();
        }
        else
        {
            MicroChipCountText.text = "NULL";
        }
        //AnomalyCountText.text = ": " + AnomalyCount.ToString();
        PlayerLevelText.text = "Player Level: " + PlayerLevel.ToString();

    }



    public void MicroPlayerUp()
    {
        //microchips determine the the player's level
        //on a level increase, the level up bool is set to true and used in other scripts
        //the microchip count is set to zero
        //the game chances for that level is set to zero
        if (MicrochipCount == MicrosPerLevel[0] && CurrentGameState == GameState.Player1) { CurrentGameState = GameState.Puzzle1; LevelupSeq(); }
        if (MicrochipCount == MicrosPerLevel[1] && CurrentGameState == GameState.Player2) { CurrentGameState = GameState.Puzzle2; LevelupSeq(); }
        if (MicrochipCount == MicrosPerLevel[2] && CurrentGameState == GameState.Player3) { CurrentGameState = GameState.Puzzle3; LevelupSeq(); }

    }
    // used by ObjectInteractions.
    private void LevelupSeq()
    {
        PlayerLevelUpBool = true;
        MicrochipCount = 0;
        GameChances = 5;
        playerObjective.UpdateObjective();
        IncPlayerLevel();
        GameChancesText.text = ": " + GameChances.ToString();


    }

    private void IncPlayerLevel()
    {
        PlayerLevel++;
        print(PlayerLevel);
    }
    public void IncMicrochipCount()
    {
        MicrochipCount++;
        //        print("Microchip: " + MicrochipCount);
        MicroChipCountText.text = ": " + MicrochipCount.ToString() + "/" + MicrosPerLevel[PlayerLevel - 1].ToString();

    }
    public void IncAnomalyCount()
    {
        AnomalyCount++;
        //    print("Anomaly: " + AnomalyCount);
    }

    public enum GameState
    {
        Player1,       //no microchips
        Puzzle1,       //collected all microchips, no puzzle
        Player2,       //finished puzzle 1
        Puzzle2,       //collect all microchips no puzzle
        Player3,       //finished puzzle 2
        Puzzle3,       //collect all microchips no puzzle
        Puzzle4,       //finished puzzle 3
        Puzzle5,      //finished puzz 4, not puzz 5
        Puzzle6,      //finished puzz 5, not puzz 6
        EndGame            //finished puzz 6, on end screen
    }
}
