using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Rendering.Universal;

public class FlickeringMainRoomLights : MonoBehaviour
{
    public Light2D[]  lights2D;
    private bool isFlicklering = false;
    float waitTimeCountdown = 1;
    float minWaitBetweenPlays = 1; 
    float maxWaitBetweenPlays = 5;




    void FixedUpdate()
    {

        // start a randomtime
        // select a randomlight
        // turn off for a time ... turn on after that time

        if (isFlicklering == false)
        {
            Light2D randomLight = lights2D[Random.Range(0, lights2D.Length)];

            isFlicklering = true;
            if (waitTimeCountdown < 0f)
            {
                //set the gameobject off
                randomLight.gameObject.transform.localScale = new Vector3( 0,randomLight.gameObject.transform.localScale.y , randomLight.gameObject.transform.localScale.z);
                
                print("::::::::::" + randomLight.name);
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);


            }
            else
            {
                randomLight.gameObject.transform.localScale = new Vector3( 1,randomLight.gameObject.transform.localScale.y , randomLight.gameObject.transform.localScale.z);
                
                waitTimeCountdown -= Time.deltaTime;
            }
            isFlicklering = false;



        }

    }
}
