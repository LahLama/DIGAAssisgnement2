using Unity.VisualScripting;
using UnityEngine;

public class Puzzle6CellClick : CaptchaManager
{

    private bool isClicked = false;
    void OnMouseDown()
    {
        GameInteractionSoundManager.PlaySound("knob");
        isClicked = !isClicked; // Toggle the clicked state
                                //        print("Clicked on: " + gameObject.name);
        if (isClicked)
        {
            PlayerCells.Add(gameObject);
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (!isClicked)
        {
            if (PlayerCells.Contains(gameObject))
            {
                PlayerCells.Remove(gameObject);
            }
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
