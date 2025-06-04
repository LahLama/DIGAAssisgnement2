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
        if (name.StartsWith("tap"))
        {
            ObjectInteractionSoundManager.PlaySound("tap");
        }
        if (name.StartsWith("window"))
        {
            ObjectInteractionSoundManager.PlaySound("windowtap");
        }
    }
}
