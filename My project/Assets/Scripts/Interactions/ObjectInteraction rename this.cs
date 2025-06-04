using System.Collections;
using UnityEngine;
// Everything but sound effects Made by Dorothy


/*
 [1] Fall . mixkit. [Sound Effect] https://mixkit.co/free-sound-effects/ Date Accessed: 08 / 05 / 2025 
 [2] Cup On Table Sfx. mixkit. [Sound Effect] https://mixkit.co/free-sound-effects/ Date Accessed: 08 / 05 / 2025
 */

public class ObjectInteraction : MonoBehaviour
{


    [Header("Animation Settings")]
    private float animationHeight = 75f; // How high the object moves up
    private float animationDuration = 1.5f; // Duration to move up or down

    private bool isAnimating = false;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (this.gameObject.tag == "Anomaly")
        {
            print("Anomaly Clicked");
        }
        else if (this.gameObject.tag == "Ornament")
        {
            print("Ornament Clicked");
        }
        else
        {
            print("Object Clicked");
        }
        isAnimating = true;
         Debug.Log("Clicked on: " + gameObject.name);
        //TrySpawnObjectOnceBehind();
        if (isAnimating == true)
        {
            StartCoroutine(AnimateVerticalMovement());
        }
        //this.interactable = false;

            // Sounds are played depending on thier properties, this limits the amount of code we need to implement as there will be a random sound played each tie
            // giving the illusion of different sounding objects
            //[1]
            if (name.StartsWith("soft"))
            {
                SoundManager.PlaySound("soft");
            }
        //[2]
        if (name.StartsWith("glass"))
        {
            SoundManager.PlaySound("glass");
        }
        // No sound for these yet.
        if (name.StartsWith("metal"))
        {
            SoundManager.PlaySound("metal");
        }
        if (name.StartsWith("tough"))
        {
            SoundManager.PlaySound("tough");
        }
        if (name.StartsWith("silver"))
        {
            SoundManager.PlaySound("silver");
        }
    }

    private IEnumerator AnimateVerticalMovement()
    {
        isAnimating = false;
        Vector3 targetPosition = originalPosition + Vector3.up * animationHeight;

        // Move up
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

        // Move down
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;

        isAnimating = true;
    }

}