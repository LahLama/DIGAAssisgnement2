
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int PlayerLevel;
    public int MicrochipCount;
    public int[] MicrosPerLevel = { 2, 3, 4 };//{ 6, 6 + 5, 6 + 5 + 4 };
    public bool PlayPuzz1 = false, PlayPuzz2 = false, PlayPuzz3 = false, PlayPuzz4 = false;
    public bool PlayerLevelUpBool = false;
    public Canvas CheatButtons;

    void Update()
    {
        MicroPlayerUp();
        if (Input.GetKeyDown(KeyCode.L))
        {

            CheatButtons.gameObject.SetActive(!CheatButtons.isActiveAndEnabled);
        }
    }
    void Awake()
    {
        PlayerLevel = 1;
        MicrochipCount = 0;


    }


    public void MicroPlayerUp()
    {
        if (MicrochipCount == MicrosPerLevel[0]) { PlayerLevel = 2; print("PLAYER IS NOW AT LEVEL: " + PlayerLevel + PlayerLevelUpBool); PlayerLevelUpBool = true; }
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
        print(MicrochipCount);
    }




}
