using System.Collections;
using UnityEngine;

public class DestroyAi : MonoBehaviour
{

    public Material AnomMaterial;
    private Material clonedMaterial;
    public float takeAwayHeightstep;
    public float stepTime;
    public int destroyStage = 0;

    private void Awake()
    {
        stepTime = 0.05f;
        takeAwayHeightstep = 0.1f;
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

        //ornaments are manahed in PointnClick.cs
        //        print("Microchip Clicked");

        GameInteractionSoundManager.PlaySound("anomaly");

        //[2]
        if (clonedMaterial == null)
        {
            clonedMaterial = Instantiate(GetComponent<SpriteRenderer>().material);
            GetComponent<SpriteRenderer>().material = clonedMaterial;
        }


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
            clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
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
                clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime);
            }
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime / 2);
            }
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime / 4);
            }
            targetHeight = 0;
            stopHeight = 2f;
            while (targetHeight < stopHeight)
            {
                clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
                targetHeight += takeAwayHeightstep;
                yield return new WaitForSeconds(stepTime / 8);
            }


        }
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = true;


    }
}
