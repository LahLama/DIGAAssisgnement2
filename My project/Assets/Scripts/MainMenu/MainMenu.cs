using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("True James Room");
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }

}
