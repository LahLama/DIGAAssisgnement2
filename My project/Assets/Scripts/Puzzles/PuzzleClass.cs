using System.Collections;
using UnityEngine;

public class PuzzleClass : MonoBehaviour
{
    public void EndPuzzleSound()
    {
        // This method can be used to play a sound when the puzzle ends
        GameInteractionSoundManager.PlaySound("PuzzleEnd");
    }

}
