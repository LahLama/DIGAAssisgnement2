using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AISoundManager : MonoBehaviour
{
    public List<AudioClip> soundClips; // List of sound clips to play
    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
        PlaySound();
    }

    public void PlaySound()
    {


        foreach (AudioClip clip in soundClips)
        {
            audioSource.PlayOneShot(clip);
            break; // Exit the loop after playing the sound
        }
    }
}


