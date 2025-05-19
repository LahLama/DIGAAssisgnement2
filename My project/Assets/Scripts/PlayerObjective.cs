using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class PlayerObjective : MonoBehaviour
{

    public PlayerStatus playerStatus;
    public TextMeshProUGUI Objective;
    void Update()
    {

        //level 1 - before puzzle 1
        //level 2 - after puzzle 1
        //level 2 - before puzzle 2
        //level 3 - after puzzle 2
        //level 3 - before puzzle 3


        if (playerStatus.PlayerLevel == 1)
        {
            Objective.text = "Find all the microchips!";

        }

        else if (playerStatus.PlayerLevel == 2 && playerStatus.PlayPuzz1 == false)
        {
            Objective.text = "SOLVE PUZZLE 1 TO UNLOCK THE DOOR";

        }
        else if (playerStatus.PlayerLevel == 2 && playerStatus.PlayPuzz1 == true)
            Objective.text = "Find all the microchips!";


        else if (playerStatus.PlayerLevel == 3 && playerStatus.PlayPuzz2 == false)
        {
            Objective.text = "SOLVE PUZZLE 2 TO UNLOCK THE DOOR";

        }
        else if (playerStatus.PlayerLevel == 3 && playerStatus.PlayPuzz2 == true)
            Objective.text = "Find all the microchips!";

        else if (playerStatus.PlayerLevel == 4 && playerStatus.PlayPuzz3 == false)
        {
            Objective.text = "SOLVE PUZZLE 3 TO UNLOCK THE DOOR";

        }
        else if (playerStatus.PlayerLevel == 4 && playerStatus.PlayPuzz3 == true)
            Objective.text = "Complete the puzzles!";

    }
}
