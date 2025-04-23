
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int PlayerLevel;
    public int MicrochipCount;
    public int AnomalyCount;
    public int[] MicrosPerLevel = { 6, 6 + 5, 6 + 5 + 4, 6 + 5 + 4 + 1 };//{ 6, 6 + 5, 6 + 5 + 4 };
    public bool PlayPuzz1 = false, PlayPuzz2 = false, PlayPuzz3 = false, PlayPuzz4 = false;
    public bool PlayerLevelUpBool = false;
    public Canvas CheatButtons;
    public TextMeshProUGUI MicroChipCountText;

    public TextMeshProUGUI AnomalyCountText;
    public TextMeshProUGUI PlayerLevelText;
    public TextMeshProUGUI ObjectiveListText;



    void Awake()
    {
        PlayerLevel = 1;
        MicrochipCount = 0;
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
            if (!IsSceneLoaded("PauseMenu"))
            {
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
        }
        ObjectiveList();

        MicroChipCountText.text = "Microchip Count: " + MicrochipCount.ToString() + "/" + MicrosPerLevel[PlayerLevel - 1].ToString();
        AnomalyCountText.text = "Anomaly Count: " + AnomalyCount.ToString();
        PlayerLevelText.text = "Player Level: " + PlayerLevel.ToString();
    }



    public void MicroPlayerUp()
    {
        if (MicrochipCount == MicrosPerLevel[0]) { PlayerLevel = 2; print("PLAYER IS NOW AT LEVEL: " + PlayerLevel); PlayerLevelUpBool = true; }
        if (MicrochipCount == MicrosPerLevel[1]) { PlayerLevel = 3; print("PLAYER IS NOW AT LEVEL: " + PlayerLevel); PlayerLevelUpBool = true; }
        if (MicrochipCount == MicrosPerLevel[2]) { PlayerLevel = 4; print("PLAYER IS NOW AT LEVEL: " + PlayerLevel); PlayerLevelUpBool = true; }
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


    public bool IsSceneLoaded(string sceneName)
    {
        // Loop through all loaded scenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }


    public void ObjectiveList()
    {
        if (PlayerLevel == 1)
        {
            ObjectiveListText.text = "Find all " + MicrosPerLevel[0].ToString() + " Microchips\n";
        }
        if (PlayerLevel == 2)
        {
            if (PlayPuzz1 == false)
            {
                ObjectiveListText.text = "Find and complete the first puzzle";
            }
            else if (PlayPuzz1 == true)
            {
                ObjectiveListText.text = "Find all " + MicrosPerLevel[1].ToString() + " Microchips\n";
            }
        }
        if (PlayerLevel == 3)
        {
            if (PlayPuzz2 == false)
            {
                ObjectiveListText.text = "Find and complete the second puzzle";
            }
            else if (PlayPuzz2 == true)
            {
                ObjectiveListText.text = "Find all " + MicrosPerLevel[2].ToString() + " Microchips\n";
            }
        }
        if (PlayerLevel == 4)
        {
            if (PlayPuzz3 == false)
            {
                ObjectiveListText.text = "Find and complete the third puzzle";
            }
            else if (PlayPuzz3 == true)
            {
                ObjectiveListText.text = "Collect the Final Microchip\n";
            }
        }

    }

}
