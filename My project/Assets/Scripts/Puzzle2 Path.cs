using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Puzzle2Path : MonoBehaviour
{
    public GameObject PathLeader;
    public Transform[] Waypoints;
    public ExitInteractions exitInteractions;
    public Rigidbody2D camera1;
    public PlayerStatus playerStatus;
    int playerlvl;
    public int moveSpeed = 5;
    public int WayIndex = 0;
    public bool Puzzle2Start = false;
    public TimerScript timer;
    bool startTimer;
    float remianingTime;



    void Update()
    {



        remianingTime = timer.remianingTime;
        startTimer = timer.StartTimer;
        playerlvl = playerStatus.PlayerLevel;
        camera1 = exitInteractions.MainCamera;
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


    }

    public void OnClick()
    {
        Puzzle2Start = !Puzzle2Start;
        remianingTime = 20;//seconds
        timer.StartTimer = true;
        if (WayIndex == Waypoints.Length)
        {
            PathLeader.transform.position = Waypoints[0].transform.position;
            playerlvl = 3;
            playerStatus.PlayPuzz3 = true;

            float movementAmount = 1080;
            Vector3 newPosition = camera1.transform.position;
            newPosition.y += movementAmount;
            camera1.transform.position = newPosition;

        }
        Debug.Log("START TIMER HERE. by calling the function after setting a bool");
        //https://www.youtube.com/watch?v=am3IitICcyA

        PathLeader.transform.position = Waypoints[0].transform.position;
        WayIndex = 0;
        Debug.Log(Puzzle2Start);



    }








}
