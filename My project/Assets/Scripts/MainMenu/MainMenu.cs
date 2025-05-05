using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room");
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }

}
