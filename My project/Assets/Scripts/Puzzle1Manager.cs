using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;


public class Puzzle1Manager : MonoBehaviour
{
    //public ExitInteractions exitInteractions;
    //add an array of 4 letter words that can be choosen randomly from.

    //References all the external scripts
    public ExitInteractions exitInteractions;
    public PlayerStatus playerStatus;
    public PlayerObjective playerObjective;


    //references the gameobjects needed
    public Rigidbody2D camera1;
    public GameObject IncorrectText;
    public TextMeshProUGUI ChangeText;
    public TextMeshProUGUI ChangeNum;
    public TimerScript Puzzle1Timer;

// array of the words that could appear, their real words, the assosiated number combination
    public string[] words = { "___", "d___", "pl__", "l_v_" };
    public string[] RealWords = { "test", "ward", "help", "evil" };
    public string[] numbers = { "1321", "0586", "0039", "0403" };
    public string correctCode = "test";
    public string input;

    // This starts the timer and the game. It is called in ExitInteractions
    public void StartPuzzle1Timer()
    {
        // -------------- Timer ----------------------------
        Debug.Log("Puzzle 1 started");
        Puzzle1Timer.remianingTime = 120;//seconds
        Puzzle1Timer.StartTimer = true;
        // ------------------------------------------------

        // hides the text that says incorrect please try again
        IncorrectText.SetActive(false);

        // ------------ Random Word Chooser ------------------
        int randomValue = Random.Range(0, words.Length);
        print("Random Value: " + randomValue);
        correctCode = RealWords[randomValue];
        ChangeText.text = words[randomValue];
        ChangeNum.text = numbers[randomValue];
        // -------------------------------------------------

    }
    public void ReadStringInput(string input)
    {
        if (input.ToLower() == correctCode)
        {
            print("PUZZLE COMPLETED");

            // moves the camera to the right and up so it can be on to the next room.
            Vector3 newPosition = camera1.transform.position;
            newPosition.x += 960;
            newPosition.y += 540;
            camera1.transform.position = newPosition;

            //stops the timer
            Puzzle1Timer.StartTimer = false;
            playerStatus.PlayPuzz1 = true;

            // Plays the AI voice reacting to the puzzle behind completed
                playerObjective.UpdateObjective();


        }
        else
        {
            // Case where the word entered does not match the word needed.
            print("Word does not match: " + correctCode);
            IncorrectText.SetActive(true);
            SoundManager.PlaySound("AI_CommentOnFailure");
            //Chances for 3 chances
        }
        /*
        foreach (var index in GuessedWords)
        {
            print(index);   
        }*/
    }
}
