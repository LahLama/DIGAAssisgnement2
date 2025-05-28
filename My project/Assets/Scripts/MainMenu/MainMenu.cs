using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;   

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        LoadVolume();
        MusicManager.Instance.PlayMusic("Main Menu");
    }

    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("James Room");
        MusicManager.Instance.PlayMusic("James Room");
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

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
