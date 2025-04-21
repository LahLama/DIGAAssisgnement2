using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Puzzle4ChooseColours : MonoBehaviour
{
    public void OnClick()
    {
        switch (this.name)
        {
            case "Red":
                print("Red");
                break;
            case "Blue":
                print("Blue");
                break;
            case "Green":
                print("Green");
                break;
            case "Yellow":
                print("Yellow");
                break;
            default:
                print("THIS HAS NO COLOUR");
                break;
        }


    }


}
