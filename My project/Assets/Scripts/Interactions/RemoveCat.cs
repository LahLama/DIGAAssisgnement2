using UnityEngine;

public class RemoveCat : MonoBehaviour
{
    public GameObject cat; // Reference to the cat GameObject
    public PlayerStatus playerStatus;
    // This method is called to remove the cat from the scene


    void Update()
    {
        if (playerStatus.CurrentGameState == PlayerStatus.GameState.Puzzle2)
        {
            if (cat != null && cat.activeInHierarchy)
            {
                RemoveCatFromScene(); // Call the method to remove the cat
            }
        }
    }
    public void RemoveCatFromScene()
    {
        ObjectInteractionSoundManager.PlaySound("evilCat"); // Play the sound when the cat is removed
        Destroy(cat); // Destroys the cat GameObject
    }
}
