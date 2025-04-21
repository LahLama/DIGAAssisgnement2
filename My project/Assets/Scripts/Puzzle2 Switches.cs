using System;
using UnityEngine;

public class Puzzle2Switches : MonoBehaviour
{
    // AN ISSUE -- Because of the log, the switchs should all be in a Disallow State. This can be good.
    // most games also have it like this.

    //false = Disallow
    //true = allow
    bool SwitchStatus = false;
    public void OnMouseDown()
    {
        SwitchStatus = !SwitchStatus;

        if (SwitchStatus == false)
        {
            this.gameObject.tag = "SwitchDisallow";
            this.transform.Rotate(0, 0, 90f);
            print(this.gameObject.tag);
        }
        else if (SwitchStatus == true)
        {
            this.gameObject.tag = "SwitchAllow";
            this.transform.Rotate(0, 0, 90f);
            print(this.gameObject.tag);
        }
    }
}
