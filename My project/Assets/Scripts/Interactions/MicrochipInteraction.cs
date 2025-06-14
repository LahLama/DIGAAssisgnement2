using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
/* Asset Refencing
[1] Error Sound Effects. mixkit. [Sound Effect] https://mixkit.co/free-sound-effects/error/ Date Accessed: 08 / 05 / 2025
-----------------------------------------------
[2] High Tech Sound Effects . mixkit. [Sound Effect] .https://mixkit.co/free-sound-effects/high-tech/ Date Accessed: 08 / 05 / 2025
-----------------------------------------------
[3]
Title: How to Control SHADERS with SCRIPTS (Updated 2023)
Author: Rigor Mortis Tortoise
Date :  3 Novemeber 2023
Availibility: https://www.youtube.com/watch?v=k11wcndXrmc&t=410s
----------------------------------------------------
[4] Shader was made with help from:
Title: 10 Shaders in 10 Minutes - Unity Shader Graph
Author: Daniel Ilett
Date :  3 April 2023
Availibility: https://www.youtube.com/watch?v=vje0x1BNpp8


*/
public class MicrochipInteraction : MonoBehaviour
{

    public PlayerStatus playerStatus;       // refencing the player status script for the methods

    public int MicrochipCount;
    public Material microchipMaterial;
    private Material clonedMaterial;
    Button button;






    void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        MicrochipCount = playerStatus.MicrochipCount;


    }

    // each time an microchip is clicked on it calls this method that hides it from the player view
    private void OnMouseDown()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        //ornaments are manahed in PointnClick.cs
        //        print("Microchip Clicked");
        playerStatus.IncMicrochipCount();
        GameInteractionSoundManager.PlaySound("microchip");

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
        float targetHeight = 0f;
        while (targetHeight < 1f)
        {
            clonedMaterial.SetFloat("_CutOff_Height", targetHeight);
            targetHeight += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        this.gameObject.SetActive(false);

    }

}
