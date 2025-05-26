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
public class ObjectInteractoins : MonoBehaviour
{
    
    public PlayerStatus playerStatus;       // refencing the player status script for the methods
    public int AnomalyCount;
    public int MicrochipCount;
    public Material microchipMaterial;
    private Material clonedMaterial;
    Button button;

  




    void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

        AnomalyCount = playerStatus.AnomalyCount;
        MicrochipCount = playerStatus.AnomalyCount;
        
   
    }
    // each time an anomaly is clicked on it calls this method that hides it from the player view
    public void OnAnomalyInteraction()
    {
        button = GetComponent<Button>();
        button.gameObject.SetActive(false);
        SoundManager.PlaySound("AnomalySelect");
        //[[1]
        playerStatus.IncAnomalyCount();
   


    }
    // each time an microchip is clicked on it calls this method that hides it from the player view
    private void OnMouseDown()
    {

        print("Microchip Clicked");
        playerStatus.IncMicrochipCount();
        SoundManager.PlaySound("MicrochipPickUp");

        //[2]
        if (clonedMaterial == null)
        {
            clonedMaterial = Instantiate(GetComponent<SpriteRenderer>().material);
            GetComponent<SpriteRenderer>().material = clonedMaterial;
        }

        StartCoroutine(DelayForMaterialMicrochip());
        


    }
    public void OnObjectInteraction()
    {
        //move object up
        //spawn micro IFF max numbers hasnt been spawnwed
    }

    public void TempOnMouseDown()
    {
        //when the player clicks on an empty space , a chance is taken away.
        playerStatus.GameChances--;
        SoundManager.PlaySound("GameChanceMinus");
        if (playerStatus.GameChances <= 0)
        {
            StartCoroutine(WaitForAITease());
            SceneManager.LoadScene("GameOver");
            //GameOver
        }
    }

    private IEnumerator WaitForAITease()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.PlaySound("AI_GameOver");
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
