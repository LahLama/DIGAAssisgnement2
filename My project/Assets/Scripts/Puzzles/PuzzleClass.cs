using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PuzzleClass : MonoBehaviour
{
    private static PuzzleClass instance;          //here

    public GameObject PuzzleTimerGO;
    public TimerScript PuzzleTimer;

    public void Awake()
    {
        StopTimer();
    }
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

    public virtual void StartTimer()
    {
        PuzzleTimerGO.SetActive(true);
        PuzzleTimer.remianingTime = 5;//seconds
        PuzzleTimer.StartTimer = true;
    }
    public void StopTimer()
    {
        PuzzleTimer.StartTimer = false;
        PuzzleTimerGO.SetActive(false);
    }



}
