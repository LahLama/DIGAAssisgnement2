using UnityEngine;

public class AreaSpecificSounds : MonoBehaviour
{
    public AudioSource FireplaceAudio;
    public void OnLivingRoomEnter()
    {
        FireplaceAudio.Play();
    }
    public void OnLivingRoomExit()
    {
        FireplaceAudio.Stop();
    }
}
