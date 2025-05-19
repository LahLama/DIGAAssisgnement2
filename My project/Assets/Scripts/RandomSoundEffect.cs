using UnityEngine;

public class RandomSoundEffect : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    float waitTimeCountdown = 2;
    float minWaitBetweenPlays = 5;
    float maxWaitBetweenPlays = 20;
    void Update()
    {
        if (!audioSource.isPlaying)
        {

            if (waitTimeCountdown < 0f)
            {

                // add that dont play the same sound twice in a row
                SoundManager.PlaySound("RandomEffect");
                print("Random sound played at" + Time.time + " seconds");
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }

    }
}
