
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int PlayerLevel;
    public int MicrochipCount;
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
