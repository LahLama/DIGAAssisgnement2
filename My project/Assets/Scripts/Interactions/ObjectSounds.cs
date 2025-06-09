using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        if (name.StartsWith("cloth"))
        {
            CollectiblesInteractionSoundManager.PlaySound("cloth");
        }
        if (name.StartsWith("metal"))
        {
            CollectiblesInteractionSoundManager.PlaySound("metal");
        }
        if (name.StartsWith("plastic"))
        {
            CollectiblesInteractionSoundManager.PlaySound("plastic");
        }
        if (name.StartsWith("food"))
        {
            CollectiblesInteractionSoundManager.PlaySound("food");
        }
        if (name.StartsWith("paper"))
        {
            CollectiblesInteractionSoundManager.PlaySound("paper");
        }
    }
}
