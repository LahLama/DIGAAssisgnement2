using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Aseprite;
public class Puzzle5Manager : MonoBehaviour
{

    public List<Transform> puzzlePieces;
    int piecesTotal;
    private void OnMouseDown()
    {
        transform.Rotate(0f, 0f, 90f);
        PuzzleComplete();
    }

    void Awake()
    {
        List<float> PuzzleRotations = new List<float> { 0, 90, 180, 270 };
        foreach (Transform puzzleRot in puzzlePieces)
        {
            puzzleRot.Rotate(0f, 0f, PuzzleRotations[Random.Range(1, 3)]);
        }
        piecesTotal = puzzlePieces.Count;
          print("::::::::::::::" + piecesTotal);
    }

    void PuzzleComplete()
    {
        int correctPieces = 0;

        foreach (Transform piece in puzzlePieces)
        {
            if (piece.rotation == Quaternion.Euler(0, 0, 90))
            {
                correctPieces++;
                print("%%%%%%%%%%%%%%%" + correctPieces);
            }
        }
        if (correctPieces == piecesTotal)
        {
            Debug.Log("Puzzle Solved!");
        }
    }


}
