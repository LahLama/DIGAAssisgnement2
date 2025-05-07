using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI ChangeText;
    public TextMeshProUGUI ChangeNum;
    public TimerScript Puzzle1Timer;

    public string[] words = { "___", "d___", "pl__", "l_v_" };
    public string[] RealWords = { "test", "ward", "help", "evil" };
    public string[] numbers = { "1321", "0586", "0039", "0403" };
    public string correctCode = "test";
    public string input;

    public List<string> GuessedWords = new List<string>();

    public void StartPuzzle1Timer()
    {
        Debug.Log("Puzzle 1 started");
        playerStatus.PlayPuzz1 = true;
        Puzzle1Timer.remianingTime = 20;//seconds
        Puzzle1Timer.StartTimer = true;
        IncorrectText.SetActive(false);
        int randomValue = Random.Range(0, words.Length);
        print("Random Value: " + randomValue);
        correctCode = RealWords[randomValue];
        ChangeText.text = words[randomValue];
        ChangeNum.text = numbers[randomValue];


    }
    public void ReadStringInput(string s)
    {
        input = s;
        GuessedWords.Add(input);
        if (input.ToLower() == correctCode)
        {
            print("PUZZLE COMPLETED");

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
