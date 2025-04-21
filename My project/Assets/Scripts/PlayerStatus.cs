
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int PlayerLevel;
    void Awake()
    {
        PlayerLevel = 1;
    }

    public void IncPlayerLevel()
    {
        PlayerLevel++;
        print(PlayerLevel);
    }


    public void AnomalyInteraction()
    {
        //

    }




    public void ObjectInteraction()
    {


    }




}
