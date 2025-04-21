using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Puzzle0 : MonoBehaviour
{
    //public ExitInteractions exitInteractions;
    //add an array of 4 letter words that can be choosen randomly from.
    public ExitInteractions exitInteractions;
    public string correctCode = "test";
    public string input;
    public List<string> GuessedWords = new List<string>();

    //Timer Start
    public void ReadStringInput(string s)
    {
        input = s;
        GuessedWords.Add(input);
        if (input == correctCode)
        {
            print("PUZZLE COMPLETED");
            //exitInteractions.PlayerLevel = 2;
            // print(" YOUR PLAYER LEVEL IS NOW: " + exitInteractions.PlayerLevel);
            exitInteractions.MoveCameraLeft();
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
