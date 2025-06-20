using UnityEngine;

public class ObjectInteractions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        if (name.StartsWith("cat"))
        {
            ObjectInteractionSoundManager.PlaySound("cat");
        }
        if (name.StartsWith("EvilCat"))
        {
            ObjectInteractionSoundManager.PlaySound("evilCat");
        }
        if (name.StartsWith("tap"))
        {
            ObjectInteractionSoundManager.PlaySound("tap");
        }
        if (name.StartsWith("window"))
        {
            ObjectInteractionSoundManager.PlaySound("windowtap");
        }
        if (name.StartsWith("globe"))
        {
            ObjectInteractionSoundManager.PlaySound("globe");
        }
        if (name.Contains("clock"))
        {
            ObjectInteractionSoundManager.PlaySound("clock");
        }
        if (name.Contains("toilet"))
        {
            ObjectInteractionSoundManager.PlaySound("toilet");
        }

    }
}
