
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
// this sets up all the varibles that will be used to used to keep track off across multiple scripts
//;-----------------------------------------------------------------------
    public int PlayerLevel;
    public int MicrochipCount;
    public int AnomalyCount;
    public int GameChances = 5;
    public int[] MicrosPerLevel = { 5, 6, 4 };
//;-----------------------------------------------------------------------

//Bools to check of a puzzle has been played
    public bool PlayPuzz1 = false, PlayPuzz2 = false, PlayPuzz3 = false, PlayPuzz4 = false;
    public bool PlayerLevelUpBool = false;

// Text Gameobjects that update with the current players stats
    public Canvas CheatButtons;
    public TextMeshProUGUI MicroChipCountText;
    //public TextMeshProUGUI AnomalyCountText;
    public TextMeshProUGUI PlayerLevelText;
    public TextMeshProUGUI GameChancesText;
    public


// intiallizes all the nessercary varibles and plays the AI intro sound
    void Awake()
    {
        PlayerLevel = 1;
        MicrochipCount = 0;
        GameChances = 5;
        SoundManager.PlaySound("AI_Intro");
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
            MicroChipCountText.text = ": / ";
        }
        //AnomalyCountText.text = ": " + AnomalyCount.ToString();
        PlayerLevelText.text = "Player Level: " + PlayerLevel.ToString();
        GameChancesText.text = ": " + GameChances.ToString();
    }



    public void MicroPlayerUp()
    {
        //microchips determine the the player's level
        //on a level increase, the level up bool is set to true and used in other scripts
        //the microchip count is set to zero
        //the game chances for that level is set to zero
        if (MicrochipCount == MicrosPerLevel[0] && PlayerLevel == 1) { PlayerLevel = 2; PlayerLevelUpBool = true; MicrochipCount = 0; GameChances = 5; }
        if (MicrochipCount == MicrosPerLevel[1] && PlayerLevel == 2) { PlayerLevel = 3; PlayerLevelUpBool = true; MicrochipCount = 0; GameChances = 5; }
        if (MicrochipCount == MicrosPerLevel[2] && PlayerLevel == 3) { PlayerLevel = 4; PlayerLevelUpBool = true; MicrochipCount = 0; GameChances = 5; }
    }
    // used by ObjectInteractions.
    public void IncPlayerLevel()
    {
        PlayerLevel++;
        print(PlayerLevel);
    }
    public void IncMicrochipCount()
    {
        MicrochipCount++;
        print("Microchip: " + MicrochipCount);
    }
    public void IncAnomalyCount()
    {
        AnomalyCount++;
        print("Anomaly: " + AnomalyCount);
    }


}
