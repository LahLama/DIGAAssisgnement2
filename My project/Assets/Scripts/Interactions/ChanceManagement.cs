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
            // GameInteractionSoundManager.PlaySound("chanceMinus");
            if (playerStatus.GameChances <= 0)
            {
                StartCoroutine(WaitForDeath());
                AiInteractionSoundManager.PlaySound("EndGame");

                //GameOver
            }
        }
        else if (this.gameObject.CompareTag("Anomaly"))
        {
            print("Anomaly Clicked");
            if (playerStatus.GameChances < 5)
            {
                //    GameInteractionSoundManager.PlaySound("chancePlus");
                playerStatus.GameChances++;
                ChanceText.text = playerStatus.GameChances.ToString();
            }

        }
        ChanceText.text = playerStatus.GameChances.ToString();
    }

    private IEnumerator WaitForDeath()
    {
        GameInteractionSoundManager.PlaySound("GameOver");
        AiInteractionSoundManager.PlaySound("EndGame");
        //stops the cursor from being used
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(6f);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("GameOver");
    }
}
