using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnInPuzzles : MonoBehaviour
{
    public PlayerStatus playerStatus;
    int MicroCount;
    int playerlvl1;

    void Awake()
    {
        MicroCount = playerStatus.MicrochipCount;
        playerlvl1 = playerStatus.PlayerLevel;
    }

    void Update()
    {
        if (playerlvl1 == 1 && MicroCount == 1)
        {
            SceneManager.LoadSceneAsync("Puzzle1 MatchWord");
        }
    }
}
