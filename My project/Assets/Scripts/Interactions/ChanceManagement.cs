using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChanceManagement : MonoBehaviour
{
    public PlayerStatus playerStatus;       // refencing the player status script for the methods
    public TextMeshProUGUI ChanceText; // refencing the chance text UI element
    public void OnMouseDown()
    {
        if (this.gameObject.CompareTag("MinusChanceObject"))
        {
            print("Chance Clicked");
            //when the player clicks on an empty space , a chance is taken away.
            playerStatus.GameChances--;
            ChanceText.text = playerStatus.GameChances.ToString();
            SoundManager.PlaySound("GameChanceMinus");
            if (playerStatus.GameChances <= 0)
            {
                StartCoroutine(WaitForAITease());
                SceneManager.LoadScene("GameOver");
                //GameOver
            }
        }
        else if (this.gameObject.CompareTag("Anomaly"))
        {
            print("Anomaly Clicked");
            if (playerStatus.GameChances < 5)
            {
                playerStatus.GameChances++;
                ChanceText.text = playerStatus.GameChances.ToString();
            }
        }
    }
    
    private IEnumerator WaitForAITease()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.PlaySound("AI_GameOver");
    }
}
