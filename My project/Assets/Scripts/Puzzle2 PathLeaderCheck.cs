using UnityEngine;

public class Puzzle2PathLeaderCheck : MonoBehaviour
{

    public Puzzle2Path _Puzzle2Script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //timer here
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
                Debug.Log("MINUS A CHANCE HERE");
                _Puzzle2Script.Puzzle2Start = false;

            }
        }
    }
}
