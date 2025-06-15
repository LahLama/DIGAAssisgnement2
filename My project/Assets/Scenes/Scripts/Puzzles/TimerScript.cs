using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remianingTime;

    public bool StartTimer;

    void Awake()
    {
        remianingTime = 5;
        StartTimer = false;
    }
    public void Update()
    {
        if (StartTimer == true)
        {
            if (remianingTime > 0)
            {
                remianingTime -= Time.deltaTime;
            }
            else if (remianingTime <= 0)
            {
                remianingTime = 0;
                // TimeisUp();
                timerText.color = Color.red;
                StartTimer = false;
                StartCoroutine(WaitForDeath());

            }
            int minutes = Mathf.FloorToInt(remianingTime / 60);
            int seconds = Mathf.FloorToInt(remianingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private IEnumerator WaitForDeath()
    {

        AiInteractionSoundManager.PlaySound("EndGame");
        //stops the cursor from being used
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;





        yield return new WaitForSeconds(5f);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("GameOver");
    }
}
