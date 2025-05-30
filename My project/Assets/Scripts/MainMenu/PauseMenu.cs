using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    
        void Update()
        {// Checks if the current room is the game room and if the escape key is down, if both are true it will pause the game
            {
            if (SceneManager.GetActiveScene().buildIndex == 1 ) 
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
        //removes the pause screen menu
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        //adds the pause screen menu scene in a way where the scene overlays the current (room) scene
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //this takes you back to the start screen
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
        //this quits the game
        SceneManager.LoadScene("StartScreen");
        Debug.Log("Quitting game...");
    }

}
