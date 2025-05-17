using UnityEngine;

public class SoundManager : MonoBehaviour
{
/*
Title:  Add a Sound Effect Manager to Your Game - 2D Platformer Unity #26 
Author: Game Code Library
Date :  16 Feb 2024
Availibility: https://www.youtube.com/watch?v=rAX_r0yBwzQ
*/
    private static SoundManager instance;
    private static AudioSource audioSource; // Reference to the AudioSource component
    private static SoundEffectLibrary soundEffectLibrary; // Reference to the SoundEffectLibrary script

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
            soundEffectLibrary = GetComponent<SoundEffectLibrary>(); // Get the SoundEffectLibrary component attached to this GameObject
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }


    public static void PlaySound(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName); // Get a random audio clip from the SoundEffectLibrary
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip); // Play the audio clip using the AudioSource
        }
    }
}
