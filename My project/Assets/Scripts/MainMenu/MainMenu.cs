using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    private void Start()
    {
        // LoadVolume();
        // MusicManager.Instance.PlayMusic("Main Menu");
    }

    public void ButtonStartGame()
    {
<<<<<<< Updated upstream
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room");
        MusicManager.Instance.PlayMusic("Room");
=======
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
        //MusicManager.Instance.PlayMusic("Room");
>>>>>>> Stashed changes
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }

    /*public void UpdateMusicVolume(float volume)
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
     }*/
}
