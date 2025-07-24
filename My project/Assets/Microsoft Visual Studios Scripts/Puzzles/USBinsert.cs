using UnityEngine;
using System.Collections;

public class USBinsert : PuzzleClass
{

    //RaycastHit2D USBPort = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 1.5f);
    //raycasting cant be used here because raycast is not optimal for detecting mouse position in 2D space.

    private Vector3 mousePosition;
    public ExitInteractions exitInteractions;
    public GameObject AnimatingObj;
    public GameObject StaticObj;
    public GameObject AnimatedAI;
    public GameObject StaticAi;
    public PlayerStatus playerStatus;
    public PlayerObjective playerObjective;

    new void Awake()
    {
        AnimatingObj.SetActive(false); // Deactivates the USB puzzle object
        AnimatedAI.GetComponent<SpriteRenderer>().material.SetFloat("_CutOff_Height", 0.79f);

    }

    public void USBPuzzleStart()
    {
        StartTimer();
        AiInteractionSoundManager.PlaySound("PuzzleUSB");
        // Initialize the USB puzzle, if needed
        Debug.Log("USB Puzzle Initialized");
        AnimatingObj.SetActive(true);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGERED");

        StaticObj.SetActive(true); // Deactivates the static USB object
        StaticAi.GetComponent<SpriteRenderer>().material.SetFloat("_CutOff_Height", 0.75f);
        AnimatingObj.SetActive(false); // Activates the animating USB object
        this.transform.position = new(0, 0, -20); // Deactivates the USB insert object
        StartCoroutine(WaitBeforeReset());

    }


    void OnMouseDrag()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(mousePosition.x, mousePosition.y);
        rb.MovePosition(targetPos);

        //Debug.DrawRay(gameObject.transform.position, Vector2.right * 1.5f, Color.cyan);
    }


    IEnumerator WaitBeforeReset() // this is a delay timer that simulates a delay and does other tasks after said delay
    {
        StopTimer();


        AiInteractionSoundManager.PlaySound("seq10");
        yield return new WaitForSeconds(4);     //we have to add it here cause coroutines happen asyncourously

        exitInteractions.MoveCameraLeft();



    }

}
