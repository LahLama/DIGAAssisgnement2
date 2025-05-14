using System;
using UnityEngine;

public class Puzzle2Switches : MonoBehaviour
{
    // AN ISSUE -- Because of the log, the switchs should all be in a Disallow State. This can be good.
    // most games also have it like this.

    //false = Disallow
    //true = allow

    public void OnMouseDown()
    {

        if (this.tag == "SwitchDisallow")
        {
            this.transform.Rotate(0, 0, 90f);
            this.tag = "SwitchAllow";
        }
        else if (this.tag == "SwitchAllow")
        {
            this.transform.Rotate(0, 0, 90f);
            this.tag = "SwitchDisallow";
        }
        else
        {
            Debug.Log("NO TAG FOUND");
        }
    }
}
