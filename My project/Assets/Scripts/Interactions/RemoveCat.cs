using UnityEngine;

public class RemoveCat : MonoBehaviour
{
    public GameObject cat; // Reference to the cat GameObject

    // This method is called to remove the cat from the scene
    public void RemoveCatFromScene()
    {
        Destroy(cat); // Destroys the cat GameObject
    }
}
