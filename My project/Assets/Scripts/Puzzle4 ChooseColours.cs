using System.Collections.Generic;
using UnityEngine;

public class Puzzle4ChooseColours : MonoBehaviour
{
    public Puzzle4Manager puzzle4Manager;
    public void OnClick()
    {
        switch (name)
        {
            case "Red":
                puzzle4Manager.playerSequence.Add("Red");
                break;
            case "Blue":
                puzzle4Manager.playerSequence.Add("Blue");
                break;
            case "Green":
                puzzle4Manager.playerSequence.Add("Green");
                break;
            case "Yellow":
                puzzle4Manager.playerSequence.Add("Yellow");
                break;
            default:
                // print("THIS HAS NO COLOUR");
                break;
        }
        print("player seq count is: " + puzzle4Manager.playerSequence.Count);


    }


}
