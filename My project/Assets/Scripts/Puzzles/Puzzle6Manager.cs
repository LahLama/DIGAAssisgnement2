using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzle6Manager : MonoBehaviour
{
    public List<GameObject> NeedToClickCells; // Array to hold the cell GameObjects
    public List<GameObject> PlayerCells; // Array to hold the player cells
    int index = 0;
    public ExitInteractions exitInteractions;
    public void CheckCapthca()
    {
        if (PlayerCells.Count == 0)
        {
            Debug.Log("No cells clicked");
            return; // Exit if no cells are clicked
        }
        else
        {

            //REFERNCE -----------------------------------------------------------------------------------------------------------------------------------------------
            //https://discussions.unity.com/t/order-a-list-of-gameobjects-by-name/745736/4
            // Reset index to start checking from the first cell
            // Sort both lists by name
            var sortedNeed = NeedToClickCells.OrderBy(cell => cell.name).ToList();
            var sortedPlayer = PlayerCells.OrderBy(cell => cell.name).ToList();

            // Compare each cell by name
            for (int i = 0; i < sortedNeed.Count; i++)
            {
                if (sortedNeed[i].name != sortedPlayer[i].name)
                {
                    Debug.Log("Puzzle not complete");
                    return;
                }
            }
            Debug.Log("---------------- Puzzle complete");
            exitInteractions.MoveCameraUp();
            return;
        }
    }
}
