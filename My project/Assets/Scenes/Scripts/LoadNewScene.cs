using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD:My project/Assets/Scenes/Scripts/LoadNewScene.cs

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] GameObject loadingBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadAsynchrously());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsynchrously()
    {
        yield return new WaitForSeconds(0.35f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Scene to go to"));

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.transform.localScale = new Vector3(progress, loadingBar.transform.localScale.y, loadingBar.transform.localScale.z);

            yield return null;
        }
    }
=======
using UnityEngine.UI;

public class LoadNewScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CountdownCoroutine());




    }

    IEnumerator CountdownCoroutine()
    {
        float duration = 5f;
        float elapsed = 0f;
        Slider slider = GetComponent<Slider>();
        slider.maxValue = duration;
        slider.value = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            slider.value = elapsed;
            yield return null;
        }

        slider.value = duration;
        SceneManager.LoadScene("Room");
    }


>>>>>>> 38841c0c39d2ecbc6da5c10c8022d85c19478d0c:My project/Assets/Scripts/LoadNewScene.cs
}
