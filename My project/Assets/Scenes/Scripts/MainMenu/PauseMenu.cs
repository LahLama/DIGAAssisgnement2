using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    
        void Update()
        {
            if (SceneManager.GetActiveScene().name == "True James Room")
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (GameIsPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                    }

                }
            }
        }

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    public void Setting()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Setting");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartScreen");
        Debug.Log("Quitting game...");
    }

}
