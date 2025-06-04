using UnityEngine;

public class PuzzlePiece : Puzzle5Manager
{
    void OnMouseDown()
    {
        GameInteractionSoundManager.PlaySound("knob");
        RotoatePiece();
    }

}
