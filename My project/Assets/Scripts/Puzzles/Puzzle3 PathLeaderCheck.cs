using UnityEngine;

public class Puzzle3PathLeaderCheck : MonoBehaviour
{

    public Puzzle3Manager _Puzzle3Script;

    void OnTriggerEnter2D(Collider2D PathSwitch)
    {
        {
            if (PathSwitch.tag == "SwitchAllow")
            {
                //Debug.Log("can PASS");

            }
            if (PathSwitch.tag == "SwitchDisallow")
            {
                //Debug.Log("NOO YOU CANT PASS");
                // Debug.Log("MINUS A CHANCE HERE");
                GameInteractionSoundManager.StopSound();
                _Puzzle3Script.ResetPathLeader();

            }
        }
    }
}
