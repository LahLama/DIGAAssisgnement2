using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Puzzle3Manager : MonoBehaviour
{
    public GameObject PathLeader;
    public Transform[] Waypoints;
    public ExitInteractions exitInteractions;
    public Rigidbody2D camera1;
    public PlayerStatus playerStatus;
    int playerlvl;
    public int moveSpeed = 5;
    public int WayIndex = 0;
    public bool Puzzle3Start = false;
    public TimerScript timer;
    bool startTimer;
    float remianingTime;



    void Update()
    {



        remianingTime = timer.remianingTime;
        startTimer = timer.StartTimer;
        playerlvl = playerStatus.PlayerLevel;
        camera1 = exitInteractions.MainCamera;
        if (Puzzle3Start == true)
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
        else if (Puzzle3Start == false)
        {
            PathLeader.transform.position = Waypoints[0].transform.position;
            WayIndex = 0;
        }


    }

    void StartPuzzle2()
    {
        if (playerStatus.PlayPuzz3 == true)
        {
            Puzzle3Start = true;
            playerStatus.PlayPuzz2 = true;
            playerStatus.PlayerLevel = 3;

        }
        else
        {
            Debug.Log("Puzzle 1 not completed yet.");
        }
    }

    public void OnClick()
    {
        Puzzle3Start = !Puzzle3Start;

        if (WayIndex == Waypoints.Length)
        {
            PathLeader.transform.position = Waypoints[0].transform.position;
            playerlvl = 3;
            playerStatus.PlayPuzz3 = true;


            Vector3 newPosition = camera1.transform.position;
            newPosition.x += 1920;
            newPosition.y += 1080;
            camera1.transform.position = newPosition;

            ;

        }
        Debug.Log("START TIMER HERE. by calling the function after setting a bool");
        //https://www.youtube.com/watch?v=am3IitICcyA

        PathLeader.transform.position = Waypoints[0].transform.position;
        WayIndex = 0;
        Debug.Log(Puzzle3Start);



    }








}
