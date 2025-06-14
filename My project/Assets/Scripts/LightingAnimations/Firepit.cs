using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Firepit : MonoBehaviour
{
    public Light2D firelight;

    private void Start()
    {
        StartCoroutine(FireplaceFlicker());
    }

    private IEnumerator FireplaceFlicker()
    {
        while (true)
        {
            firelight.intensity = Random.Range(5f, 10f);
            yield return new WaitForSeconds(0.1f); // Flicker
        }
    }
}
