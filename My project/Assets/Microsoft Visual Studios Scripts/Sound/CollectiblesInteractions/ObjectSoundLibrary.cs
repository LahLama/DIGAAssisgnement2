using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;
/*
Title:  Add a Sound Effect Manager to Your Game - 2D Platformer Unity #26 
Author: Game Code Library
Date :  16 Feb 2024
Availibility: https://www.youtube.com/watch?v=rAX_r0yBwzQ
*/
public class ObjectsSoundManagerLibrary : MonoBehaviour      //here
{
    [SerializeField] private SoundEffectGroup[] soundEffectsGroups; // Array of sound effect groups
    private Dictionary<string, List<AudioClip>> soundDirectory; // Dictionary to hold sound effects categorized by their names

    void Awake()
    {
        InitalizeDictionary();
    }
    private void InitalizeDictionary()
    {
        soundDirectory = new Dictionary<string, List<AudioClip>>(); // Initialize the dictionary

        // the soundEffectsGroups array is what we edited in the inspector and the soundDirectory is the dictionary we will use to store the sound effects
        foreach (SoundEffectGroup group in soundEffectsGroups) // for each Group in the array soundEffectsGroups
        {
            soundDirectory[group.name] = group.audioClips; // Add the group name and its audio clips to the dictionary
        }
    }

    public AudioClip GetRandomClip(string name) // Method to get a random audio clip
    {
        if (soundDirectory.ContainsKey(name)) //Check if there is a audio clip in the dictionary
        {
            List<AudioClip> audioClips = soundDirectory[name]; // Get the audio clips for the given name
            if (audioClips.Count > 0) // Check if there are any audio clips in the list
            {
                return audioClips[Random.Range(0, audioClips.Count)]; // Return a random audio clip from the list
            }
        }
        return null; // Return null if no audio clip is found
    }



    [System.Serializable] // So we can see it in the inspector
    public struct SoundEffectGroup
    {
        public string name; // Name of the sound effect
        public List<AudioClip> audioClips; // Audio clip for the sound effect
    }
}
