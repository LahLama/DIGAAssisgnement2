using UnityEngine;

public class JigsawPiece : JigsawManager
{
    void OnMouseDown()
    {
        GameInteractionSoundManager.PlaySound("knob");
        RotoatePiece();
    }

}
