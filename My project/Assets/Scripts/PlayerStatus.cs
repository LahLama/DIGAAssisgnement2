
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int PlayerLevel;
    public int MicrochipCount;
    public int AnomalyCount;
    public int GameChances = 5;
    public int[] MicrosPerLevel = { 5, 6, 4 };



    public bool PlayPuzz1 = false, PlayPuzz2 = false, PlayPuzz3 = false, PlayPuzz4 = false;
    public bool PlayerLevelUpBool = false;
    public Canvas CheatButtons;
    public TextMeshProUGUI MicroChipCountText;
    public TextMeshProUGUI AnomalyCountText;
    public TextMeshProUGUI PlayerLevelText;
    public TextMeshProUGUI GameChancesText;
    public



    void Awake()
    {
        PlayerLevel = 1;
        MicrochipCount = 0;
        GameChances = 5;
    }
    void Update()
    {
        MicroPlayerUp();
        if (Input.GetKeyDown(KeyCode.L))
        {
            CheatButtons.gameObject.SetActive(!CheatButtons.isActiveAndEnabled);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        MicroChipCountText.text = ": " + MicrochipCount.ToString() + "/" + MicrosPerLevel[PlayerLevel - 1].ToString();
        AnomalyCountText.text = ": " + AnomalyCount.ToString();
        PlayerLevelText.text = "Player Level: " + PlayerLevel.ToString();
        GameChancesText.text = ": " + GameChances.ToString();
    }



    public void MicroPlayerUp()
    {


        if (MicrochipCount == MicrosPerLevel[0] && PlayerLevel == 1) { PlayerLevel = 2; PlayerLevelUpBool = true; MicrochipCount = 0; GameChances = 5; }
        if (MicrochipCount == MicrosPerLevel[1] && PlayerLevel == 2) { PlayerLevel = 3; PlayerLevelUpBool = true; MicrochipCount = 0; GameChances = 5; }
        if (MicrochipCount == MicrosPerLevel[2] && PlayerLevel == 3) { PlayerLevel = 4; PlayerLevelUpBool = true; MicrochipCount = 0; GameChances = 5; }
    }
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
