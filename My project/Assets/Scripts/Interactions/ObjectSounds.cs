using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        if (name.StartsWith("cloth"))
        {
            ObjectsSoundManager.PlaySound("cloth");
        }
        if (name.StartsWith("metal"))
        {
            ObjectsSoundManager.PlaySound("metal");
        }
        if (name.StartsWith("plastic"))
        {
            ObjectsSoundManager.PlaySound("plastic");
        }
        if (name.StartsWith("food"))
        {
            ObjectsSoundManager.PlaySound("food");
        }
        if (name.StartsWith("paper"))
        {
            ObjectsSoundManager.PlaySound("paper");
        }
    }
}
