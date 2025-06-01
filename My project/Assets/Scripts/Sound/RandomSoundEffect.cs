using UnityEngine;

public class RandomSoundEffect : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    float waitTimeCountdown = 10;
    float minWaitBetweenPlays = 10;
    float maxWaitBetweenPlays = 50;
    void Update()
    {

        // checks if the audio player is playing, if not it will choose a random time,wait that long 
        // and then play a random sound from the random sound effect group
        if (audioSource == null)
            return;
        if (!audioSource.isPlaying)
        {

            if (waitTimeCountdown < 0f)
            {

                // add that dont play the same sound twice in a row
                SoundManager.PlaySound("RandomEffect");
                //                print("Random sound played at" + Time.time + " seconds");
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }

    }
}
