using UnityEngine;

public class CircuitPathLeaderCheck : MonoBehaviour
{

    public CircuitManager _CircuitScript;

    void OnTriggerEnter2D(Collider2D PathSwitch)
    {
        {
            print("PathSwitch entered");
            if (PathSwitch.tag == "SwitchAllow")
            {
                //Debug.Log("can PASS");

            }
            if (PathSwitch.tag == "SwitchDisallow")
            {
                //Debug.Log("NOO YOU CANT PASS");
                // Debug.Log("MINUS A CHANCE HERE");
                GameInteractionSoundManager.StopSound();
                _CircuitScript.ResetPathLeader();
                _CircuitScript.PuzzleFailSound();

            }
        }
    }
}
