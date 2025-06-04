using Unity.VisualScripting;
using UnityEngine;

public class GameInteractionSoundManager : MonoBehaviour     //here
{
    /*
    Title:  Add a Sound Effect Manager to Your Game - 2D Platformer Unity #26 
    Author: Game Code Library
    Date :  16 Feb 2024
    Availibility: https://www.youtube.com/watch?v=rAX_r0yBwzQ
    */
    private static GameInteractionSoundManager instance;          //here
    private static AudioSource audioSource; // Reference to the AudioSource component
    private static GameInteractionSoundLibrary gameInteractionSoundLibrary; // Reference to the SoundEffectLibrary script       //here

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
            gameInteractionSoundLibrary = GetComponent<GameInteractionSoundLibrary>(); // Get the SoundEffectLibrary component attached to this GameObject      //here
        }

    }


    public static void PlaySound(string soundName)
    {
        AudioClip audioClip = gameInteractionSoundLibrary.GetRandomClip(soundName); // Get a random audio clip from the SoundEffectLibrary            //here
        if (audioClip != null)
        {
            if (audioSource.isPlaying)
            {
                print("Audio is already playing, stopping the current sound before playing a new one.");
            }
            else
            {
                audioSource.PlayOneShot(audioClip); // Play the audio clip using the AudioSource
                print("Playing sound: " + soundName);
            }
        }
    }
    public void Test()
    {
        // This method is for testing purposes, you can call it to test the sound manager
        PlaySound("TestSound"); // Replace "TestSound" with the name of the sound you want to play
    }
}
