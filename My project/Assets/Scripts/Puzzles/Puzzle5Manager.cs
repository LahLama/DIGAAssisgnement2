using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Aseprite;
public class Puzzle5Manager : MonoBehaviour
{

    public List<Transform> puzzlePieces;
    public ExitInteractions exitInteractions;
    public List<float> PuzzleRotations = new List<float> { 90, 180, 270 };
    int piecesTotal;
    // Tolerance for checking rotation
    public float rotationTolerance = 0.1f;
    public void RotoatePiece()
    {
        transform.Rotate(0f, 0f, 90f);
        PuzzleComplete();
    }

    public void Puzzle5Start()
    {
        piecesTotal = puzzlePieces.Count;
        foreach (Transform puzzleRot in puzzlePieces)
        {
            puzzleRot.Rotate(0f, 0f, PuzzleRotations[(int)Random.Range(0, 3)]);
        }
    }

    void PuzzleComplete()
    {
        int correctPieces = 0;

        foreach (Transform piece in puzzlePieces)
        {
            // Get the Euler angles to access the z-rotation more reliably
            Vector3 eulerRotation = piece.localEulerAngles;
            // Check if the absolute difference between the z-rotation and 0 is within the tolerance
            if (Mathf.Abs(eulerRotation.z % 360f) < rotationTolerance || Mathf.Abs(eulerRotation.z % 360f - 360f) < rotationTolerance)
            {
                correctPieces++;
            }
        }

        if (correctPieces == 12)
        {
            Debug.Log("Puzzle Solved!");
            exitInteractions.MoveCameraUp();
        }
        else
        {
            Debug.Log("Puzzle Not Solved Yet! at: " + correctPieces);
        }
    }


}
