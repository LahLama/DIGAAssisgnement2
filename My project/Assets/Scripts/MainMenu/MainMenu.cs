using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        MusicManager.Instance.PlayMusic("Main Menu");
    }

    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("True James Room");
        MusicManager.Instance.PlayMusic("True James Room");
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
