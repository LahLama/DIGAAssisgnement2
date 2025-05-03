using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;


public class Puzzle1Manager : MonoBehaviour
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
    }

    public void StartPuzzle1Timer()
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


            Vector3 newPosition = camera1.transform.position;
            newPosition.x += 1920;
            newPosition.y += 1080;
            camera1.transform.position = newPosition;
            Puzzle1Timer.StartTimer = false;

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
