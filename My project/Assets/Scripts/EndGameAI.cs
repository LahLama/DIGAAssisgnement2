using System.Collections;
using UnityEngine;

public class EndGameAI : MonoBehaviour
{

    private Material material;
    public ExitInteractions exitInteractions;
    public float takeAwayHeightstep;
    public float stepTime;
    public int destroyStage = 0;
    public GameObject USBai;
    public CircuitManager circuitManager;
    public USBinsert uSBinsert;
    public ReplicateCodeManager replicateCodeManager;

    private void Awake()
    {
        stepTime = 0.05f;
        takeAwayHeightstep = 0.1f;
        USBai.SetActive(false);
    }
    // each time an anomaly is clicked on it calls this method that hides it from the player view

    private void OnMouseDown()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        destroyStage++;

        switch (destroyStage)
        {
            case 1:
                exitInteractions.MoveCameraLeft();
                circuitManager.StartCircuitPuzzle();
                break;
            case 2:
                exitInteractions.MoveCameraRight();
                USBai.SetActive(true);
                uSBinsert.USBPuzzleStart();
                break;
            case 3:
                exitInteractions.MoveCameraUp();
                replicateCodeManager.ReplicateCodePuzzleStart();
                break;
            default:
                break;
        }


        //ornaments are manahed in PointnClick.cs
        //        print("Microchip Clicked");

        GameInteractionSoundManager.PlaySound("anomaly");

        //[2]

        material = GetComponent<SpriteRenderer>().material;



        StartCoroutine(DelayForMaterialMicrochip());



    }


    private IEnumerator DelayForMaterialMicrochip()
    {
        float stopHeight = 0;
        float targetHeight = 0;
        if (destroyStage == 1)
        {
            stopHeight = 0.55f;
            targetHeight = 0;
        }
        else if (destroyStage == 2)
        {
            targetHeight = 0.55f;
            stopHeight = 0.75f;

        }
        else if (destroyStage == 3)
        {
            targetHeight = 0.75f;
            stopHeight = 0.90f;
        }
        else if (destroyStage == 4)
        {
            targetHeight = 0.90f;
            stopHeight = 2f;
        }


        while (targetHeight < stopHeight)
        {
            material.SetFloat("_CutOff_Height", targetHeight);
            targetHeight += takeAwayHeightstep;
            yield return new WaitForSeconds(stepTime);
        }


        if (destroyStage == 4)
        {
            GameInteractionSoundManager.PlaySound("Explosion");
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                material.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime);
            }
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                material.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime / 2);
            }
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                material.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime / 4);
            }
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                material.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime / 8);
            }
            yield return new WaitForSeconds(1);
            exitInteractions.MoveCameraUp();
            exitInteractions.MoveCameraUp();


        }
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = true;


    }
}
