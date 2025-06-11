
using UnityEngine;

public class USBinsert : MonoBehaviour
{

    //RaycastHit2D USBPort = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 1.5f);
    //raycasting cant be used here because raycast is not optimal for detecting mouse position in 2D space.

    private Vector3 mousePosition;
    public GameObject AnimatingObj;
    public GameObject StaticObj;

    void Awake()
    {
        AnimatingObj.SetActive(false); // Deactivates the USB puzzle object
        USBPuzzleStart();
    }

    void USBPuzzleStart()
    {
        // Initialize the USB puzzle, if needed
        Debug.Log("USB Puzzle Initialized");
        AnimatingObj.SetActive(true);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGERED");

        StaticObj.SetActive(true); // Deactivates the static USB object

        AnimatingObj.SetActive(false); // Activates the animating USB object
        this.gameObject.SetActive(false); // Deactivates the USB insert object

    }


    void OnMouseDrag()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(mousePosition.x, mousePosition.y);
        rb.MovePosition(targetPos);

        Debug.DrawRay(gameObject.transform.position, Vector2.right * 1.5f, Color.cyan);
    }


}
