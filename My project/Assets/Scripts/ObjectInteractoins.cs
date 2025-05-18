using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Asset Refencing
[1] Error Sound Effects. mixkit. [Sound Effect] https://mixkit.co/free-sound-effects/error/ Date Accessed: 08 / 05 / 2025
-----------------------------------------------
[2] High Tech Sound Effects . mixkit. [Sound Effect] .https://mixkit.co/free-sound-effects/high-tech/ Date Accessed: 08 / 05 / 2025
-----------------------------------------------*/
public class ObjectInteractoins : MonoBehaviour
{
    
    public PlayerStatus playerStatus;       // refencing the player status script for the methods
    public int AnomalyCount;
    public int MicrochipCount;
    Button button;


    void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

        AnomalyCount = playerStatus.AnomalyCount;
        MicrochipCount = playerStatus.AnomalyCount;

    }
    // each time an anomaly is clicked on it calls this method that hides it from the player view
    public void OnAnomalyInteraction()
    {
        button = GetComponent<Button>();
        button.gameObject.SetActive(false);
        SoundManager.PlaySound("AnomalySelect");
        //[[1]
        playerStatus.IncAnomalyCount();


    }
// each time an microchip is clicked on it calls this method that hides it from the player view
    public void OnMicrochipInteraction()
    {
        button = GetComponent<Button>();
        playerStatus.IncMicrochipCount();
        SoundManager.PlaySound("MicrochipPickUp");
        //[2]
        button.gameObject.SetActive(false);

    }
    public void OnObjectInteraction()
    {
        //move object up
        //spawn micro IFF max numbers hasnt been spawnwed
    }

    public void OnChanceMinus()
    {
        //when the player clicks on an empty space , a chance is taken away.
        playerStatus.GameChances--;
        SoundManager.PlaySound("GameChanceMinus");
        if (playerStatus.GameChances <= 0)
        {
            SceneManager.LoadScene("GameOver");
            //GameOver
        }
    }


}
