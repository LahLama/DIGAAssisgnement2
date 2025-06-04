using Unity.VisualScripting;
using UnityEngine;

public class Puzzle6CellClick : MonoBehaviour
{
    public Puzzle6Manager puzzle6Manager;
    private bool isClicked = false;
    void OnMouseDown()
    {
        GameInteractionSoundManager.PlaySound("knob");
        isClicked = !isClicked; // Toggle the clicked state
        print("Clicked on: " + gameObject.name);
        if (isClicked)
        {
            puzzle6Manager.PlayerCells.Add(gameObject);
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (!isClicked)
        {
            if (puzzle6Manager.PlayerCells.Contains(gameObject))
            {
                puzzle6Manager.PlayerCells.Remove(gameObject);
            }
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
