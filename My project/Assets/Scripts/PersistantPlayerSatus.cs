using UnityEngine;
public class PersistentPlayerStatus : MonoBehaviour
{
    public static PersistentPlayerStatus Instance;
    public PlayerStatus playerStatus;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction between scenes
        }
        else
        {
            Destroy(gameObject); // Avoid duplicates
        }

        // Add the PlayerStatus component if it's not already attached
        if (playerStatus == null)
        {
            playerStatus = gameObject.AddComponent<PlayerStatus>();
        }
    }
}