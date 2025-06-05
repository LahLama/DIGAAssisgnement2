using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PuzzleClass : MonoBehaviour
{
    private static PuzzleClass instance;          //here

    public void EndPuzzleSound()
    {
        // This method can be used to play a sound when the puzzle ends
        GameInteractionSoundManager.PlaySound("PuzzleEnd");
    }

    public void PuzzleFailSound()
    {
        // This method can be used to play a sound when the puzzle fails
        AiInteractionSoundManager.PlaySound("Failure");
    }



}
