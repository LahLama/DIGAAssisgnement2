
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int PlayerLevel;
    public int MicrochipCount;
    public bool PlayPuzz1 = false, PlayPuzz2 = false, PlayPuzz3 = false, PlayPuzz4 = false;

    void Awake()
    {
        PlayerLevel = 1;
        MicrochipCount = 0;
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
