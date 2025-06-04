using System;
using UnityEngine;

public class Puzzle2Switches : MonoBehaviour
{

    //false = Disallow
    //true = allow

    public void OnMouseDown()
    {
        GameInteractionSoundManager.PlaySound("knob");
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
