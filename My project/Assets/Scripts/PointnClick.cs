using UnityEngine;

public class PointnClick : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] randomPrefabs; // Prefabs to spawn
    public float spawnDistanceBehind = 1.5f;

    [Header("Animation Settings")]
    private float animationHeight = 150f; // How high the object moves up
    private float animationDuration = 1.5f; // Duration to move up or down

    private bool isAnimating = false;
    private bool hasSpawned = false;
    private Vector3 originalPosition;
    private GameObject spawnedObject = null;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        /* if (Input.GetMouseButtonDown(0) && !isAnimating)
         {
             HandleClick(0); // Left-click
         }

         if (Input.GetMouseButtonDown(1))
         {
             HandleClick(1); // Right-click
         }*/
    }

    public void OnObjectClick()
    {
        print("Object clicked");
        //TrySpawnObjectOnceBehind();
        StartCoroutine(AnimateVerticalMovement());
        //this.interactable = false;

        if (name.StartsWith("pillow"))
        {
            SoundManager.PlaySound("pillow");
        }
        if (name.StartsWith("Vase"))
        {
            SoundManager.PlaySound("vase");
        }
    }
    /*
        void HandleClick(int mouseButton)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (mouseButton == 0 && hitObject == gameObject && !hitObject.name.StartsWith("micro-chip"))
                {
                    Debug.Log("Left-clicked: Animate + Spawn (if not already)");
                    TrySpawnObjectOnceBehind();
                    StartCoroutine(AnimateVerticalMovement());
                }
                else if (mouseButton == 1 && hitObject.name.StartsWith("micro-chip"))
                {
                    Debug.Log("Right-clicked: micro-chip destroyed");
                    Destroy(hitObject);
                }
            }
        }*/

    private System.Collections.IEnumerator AnimateVerticalMovement()
    {
        isAnimating = true;
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

        isAnimating = false;
    }
    /*
        private void TrySpawnObjectOnceBehind()
        {
            if (hasSpawned || randomPrefabs.Length == 0)
                return;

            int randomIndex = Random.Range(0, randomPrefabs.Length);
            GameObject prefabToSpawn = randomPrefabs[randomIndex];

            Vector3 spawnPosition = transform.position - transform.forward * spawnDistanceBehind;
            spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            Debug.Log($"Spawned {spawnedObject.name} behind {gameObject.name}");

            hasSpawned = true;
        }*/
}