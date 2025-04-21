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
    int playerlvl;
    public string correctCode = "test";
    public string input;
    public List<string> GuessedWords = new List<string>();

    //Timer Start

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    void Update()
    {
        playerlvl = playerStatus.PlayerLevel;
        camera1 = exitInteractions.MainCamera;
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

            playerStatus.PlayPuzz1 = true;

        }
        else
        {
            print("Word does not match: " + correctCode);
            //Chances for 3 chances
        }
        /*
        foreach (var index in GuessedWords)
        {
            print(index);   
        }*/
    }
}
