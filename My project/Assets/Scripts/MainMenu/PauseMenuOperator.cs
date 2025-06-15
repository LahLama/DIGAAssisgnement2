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
            if (SceneManager.GetActiveScene().name == "Room")
            {
                bool pauseMenuLoaded = false;
                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    if (SceneManager.GetSceneAt(i).name == "PauseScreen")
                    {
                        pauseMenuLoaded = true;
                        break;
                    }
                }

                if (!pauseMenuLoaded)
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
        }
    }

    public void Resume()
    {
        //removes the pause screen menu
        SceneManager.UnloadSceneAsync("PauseScreen");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        //adds the pause screen menu scene in a way where the scene overlays the current (room) scene
        SceneManager.LoadScene("PauseScreen", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void RestartGame()
    {
        //this restarts the game
        Time.timeScale = 1f;
        SceneManager.LoadScene("Room");
    }
    public void LoadMenu()
    {
        //this takes you back to the start screen
        Time.timeScale = 1f;
        SceneManager.LoadScene("Room");
    }

    public void QuitGame()
    {
        //this quits the game
        SceneManager.LoadScene("StartScreen");
        Debug.Log("Quitting game...");
    }

}
