using Unity.VisualScripting;
using UnityEngine;

public class CaptchaCellClick : MonoBehaviour
{
    public CaptchaManager captchaManager;
    private bool isClicked = false;
    void OnMouseDown()
    {
        GameInteractionSoundManager.PlaySound("knob");
        isClicked = !isClicked; // Toggle the clicked state
                                //        print("Clicked on: " + gameObject.name);
        if (isClicked)
        {
            captchaManager.PlayerCells.Add(gameObject);
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else if (!isClicked)
        {
            if (captchaManager.PlayerCells.Contains(gameObject))
            {
                captchaManager.PlayerCells.Remove(gameObject);
            }
            transform.localScale = new Vector3(1.35f, 1.35f, 1.35f);
        }

    }
}
