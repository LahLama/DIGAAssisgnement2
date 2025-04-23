using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;


public class Puzzle0 : MonoBehaviour
{
    //public ExitInteractions exitInteractions;
    //add an array of 4 letter words that can be choosen randomly from.
    public ExitInteractions exitInteractions;
    public Rigidbody2D camera1;
    public PlayerStatus playerStatus;
    public GameObject IncorrectText;
    public TimerScript Puzzle1Timer;
    bool startTimer;
    float remianingTime;
    int playerlvl;
    public string correctCode = "test";
    public string input;

    public List<string> GuessedWords = new List<string>();


    void Update()
    {
        remianingTime = Puzzle1Timer.remianingTime;
        startTimer = Puzzle1Timer.StartTimer;
        playerlvl = playerStatus.PlayerLevel;
        camera1 = exitInteractions.MainCamera;
    }

    public void IsCorrect()
    {
        remianingTime = 20;//seconds
        Puzzle1Timer.StartTimer = true;
        IncorrectText.SetActive(false);


    }
    public void ReadStringInput(string s)
    {
        input = s;
        GuessedWords.Add(input);
        if (input.ToLower() == correctCode)
        {
            print("PUZZLE COMPLETED");
            playerlvl = 2;

            float movementAmount = -1920;
            Vector3 newPosition = camera1.transform.position;
            newPosition.x += movementAmount;
            camera1.transform.position = newPosition;
            Puzzle1Timer.StartTimer = false;
            playerStatus.PlayPuzz1 = true;

        }
        else
        {
            print("Word does not match: " + correctCode);
            IncorrectText.SetActive(true);
            //Chances for 3 chances
        }
        /*
        foreach (var index in GuessedWords)
        {
            print(index);   
        }*/
    }
}
