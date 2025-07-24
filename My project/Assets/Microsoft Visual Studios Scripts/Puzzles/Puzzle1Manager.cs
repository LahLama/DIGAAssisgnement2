using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;


public class Puzzle1Manager : PuzzleClass
{

    //References all the external scripts
    public ExitInteractions exitInteractions;
    public PlayerStatus playerStatus;
    public PlayerObjective playerObjective;


    //references the gameobjects needed
    public Rigidbody2D camera1;
    public GameObject IncorrectText;
    public TextMeshProUGUI ChangeText;
    public TextMeshProUGUI ChangeNum;
    public GameObject WordScrollAnimations;

    // array of the words that could appear, their real words, the assosiated number combination
    public string[] words = { "___", "d___", "pl__", "l_v_" };
    public string[] RealWords = { "test", "ward", "help", "evil" };
    public string[] numbers = { "1321", "0586", "0039", "0403" };
    public string correctCode = "test";
    public string input;

    // This starts the timer and the game. It is called in ExitInteractions

    new private void Awake()
    {
        WordScrollAnimations.SetActive(false); // Deactivates the word scroll animations
    }
    public void StartPuzzle1()
    {
        // -------------- Timer ----------------------------
        Debug.Log("Puzzle 1 started");
        StartTimer();
        WordScrollAnimations.SetActive(true); // Activates the word scroll animations
        // ------------------------------------------------

        // hides the text that says incorrect please try again
        IncorrectText.SetActive(false);

        // ------------ Random Word Chooser ------------------
        int randomValue = Random.Range(0, words.Length);
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
            //stops the timer

            EndPuzzleSound();
            playerStatus.CurrentGameState = PlayerStatus.GameState.Player2;
            StartCoroutine(WaitBeforeReset());



        }
        else
        {
            // Case where the word entered does not match the word needed.
            print("Word does not match: " + correctCode);
            IncorrectText.SetActive(true);
            PuzzleFailSound();
            //Chances for 3 chances
        }
        /*
        foreach (var index in GuessedWords)
        {
            print(index);   
        }*/
    }
    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        yield return new WaitForSeconds(2);     //we have to add it here cause coroutines happen asyncourously

        // moves the camera to the right and up so it can be on to the next room.
        StopTimer();
        Vector3 newPosition = camera1.transform.position;
        newPosition.x += 960;
        newPosition.y += 540;
        camera1.transform.position = newPosition;
        // Plays the AI voice reacting to the puzzle behind completed
        playerObjective.UpdateObjective();

        WordScrollAnimations.SetActive(false); // Deactivates the word scroll animations






    }
}
