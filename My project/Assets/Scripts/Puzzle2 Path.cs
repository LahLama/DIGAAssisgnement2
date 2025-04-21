using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Puzzle2Path : MonoBehaviour
{
    public GameObject PathLeader;
    public Transform[] Waypoints;
    public int moveSpeed = 5;
    public int WayIndex = 0;
    public bool Puzzle2Start = false;
    void Update()
    {
        if (Puzzle2Start == true)
        {

            if (WayIndex <= Waypoints.Length - 1)
            {
                PathLeader.transform.position = Vector2.MoveTowards(PathLeader.transform.position, Waypoints[WayIndex].transform.position, moveSpeed * Time.deltaTime);


                if (PathLeader.transform.position == Waypoints[WayIndex].transform.position)
                {
                    WayIndex++;
                }
            }

        }
        else if (Puzzle2Start == false)
        {
            PathLeader.transform.position = Waypoints[0].transform.position;
            WayIndex = 0;
        }

        if (WayIndex == Waypoints.Length)
        {
            Debug.Log("PUZZLE COMPLETED!!!!!!");

        }
    }

    public void OnClick()
    {
        Debug.Log("START TIMER HERE. by calling the function after setting a bool");
        //https://www.youtube.com/watch?v=am3IitICcyA
        Puzzle2Start = !Puzzle2Start;
        PathLeader.transform.position = Waypoints[0].transform.position;
        WayIndex = 0;
        Debug.Log(Puzzle2Start);

    }








}
