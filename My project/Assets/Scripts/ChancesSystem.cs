using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ChancesSystem : MonoBehaviour
{
    public GameObject[] chances; // [0] [1] [2]
    private int life;         //3
    public PlayerStatus playerStatus;

    public void AAAAAAAAAAA()
    {
        print("AAAAAAAAAAAAA");
    }

    private void Start()
    {
        life = chances.Length;
    }

    void Update()
    {
        if (playerStatus.GameOver == true)
        {
            Debug.Log("Game Over !!!");
        }
    }

    public void intiChances()
    {

    }


    public void MinusChance(int d)
    {
        if (life >= 1)
        {
            (chances[life]).SetActive(false);   // [0]
            life -= d;  //1-1-0

            if (life < 1)
            {
                playerStatus.GameOver = true;
            }
        }

    }
}
