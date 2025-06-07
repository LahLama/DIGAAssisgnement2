using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        if (name.StartsWith("soft"))
        {
            SoundManager.PlaySound("soft");
        }
        //[2]
        if (name.StartsWith("glass"))
        {
            SoundManager.PlaySound("glass");
        }
        // No sound for these yet.
        if (name.StartsWith("metal"))
        {
            SoundManager.PlaySound("metal");
        }
        if (name.StartsWith("plastic"))
        {
            SoundManager.PlaySound("plastic");
        }
        if (name.StartsWith("food"))
        {
            SoundManager.PlaySound("food");
        }
        if (name.StartsWith("wood"))
        {
            SoundManager.PlaySound("wood");
        }
    }
}
